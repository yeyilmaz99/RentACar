using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, MyDatabaseContext>,IBrandDal
    {
        private readonly DbContextOptions<MyDatabaseContext> _dbContextOptions;
        public EfBrandDal(DbContextOptions<MyDatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        public List<BrandDetailDto> GetBrandsDetails(Expression<Func<Brand, bool>> filter = null)
        {
            using (var context = new MyDatabaseContext(_dbContextOptions))
            {
                var result = from b in filter == null ? context.Brands : context.Brands.Where(filter)
                             join img in context.BrandImages
                                 on b.BrandId equals img.BrandId
                             select new BrandDetailDto
                             {
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 ImageData = img.ImageData
                             };

                return result.ToList();
            }
        }
    }
}
