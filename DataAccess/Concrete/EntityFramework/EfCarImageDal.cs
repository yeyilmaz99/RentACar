using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, MyDatabaseContext>, ICarImageDal
    {
        private readonly DbContextOptions<MyDatabaseContext> _dbContextOptions;
        public EfCarImageDal(DbContextOptions<MyDatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        public List<CarImage> GetDefaultImage()
        {
            using (MyDatabaseContext context = new MyDatabaseContext(_dbContextOptions))
            {
                return context.Set<CarImage>().ToList();
            }
        }
    }
}
