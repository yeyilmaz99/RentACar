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

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MyDatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var result = from r in context.Rentals
                    join c in context.Cars on r.CarId equals c.Id
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join customer in context.Customers on r.CustomerId equals customer.Id
                    join user in context.Users on customer.UserId equals user.Id
                    select new RentalDetailDto()
                    {
                        Id = r.Id,
                        BrandName = b.BrandName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate,
                        DailyPrice = c.DailyPrice,
                        CompanyName = customer.CompanyName
                    };
                return result.ToList();
            }
        }
    }
}
