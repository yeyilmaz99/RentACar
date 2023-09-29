using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MyDatabaseContext>, IRentalDal
    {
        private readonly DbContextOptions<MyDatabaseContext> _dbContextOptions;
        public EfRentalDal(DbContextOptions<MyDatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (MyDatabaseContext context = new MyDatabaseContext(_dbContextOptions))
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars on r.CarId equals c.Id
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join user in context.Users on r.UserId equals user.Id
                    select new RentalDetailDto()
                    {
                        BrandName = b.BrandName,
                        DailyPrice = c.DailyPrice,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Id = r.Id,
                        ReturnDate = r.ReturnDate,
                        RentDate = r.RentDate,
                        CarId = c.Id

                    };
                return result.ToList();
            }
        }
    }
}
