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
    public class EfCarDal : EfEntityRepositoryBase<Car, MyDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join clr in context.Colors on c.ColorId equals clr.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = clr.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }

        public CarDetailDto GetCarDetail(Expression<Func<Car, bool>> filter)
        {
            using (var context = new MyDatabaseContext())
            {
                var result = from c in context.Cars.Where(filter)
                    join clr in context.Colors
                        on c.ColorId equals clr.ColorId
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                    select new CarDetailDto { 
                        CarId = c.Id,
                        BrandName = b.BrandName, 
                        ColorName = clr.ColorName, 
                        CarName = c.CarName, 
                        DailyPrice = c.DailyPrice,
                        Description = c.Description
                    };

                return result.SingleOrDefault();
            }
        }

        public List<CarDetailDto> GetCarsByBrandIdAndColorId(int colorId, int brandId)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands.Where(b => b.BrandId ==  brandId ) on c.BrandId equals b.BrandId
                    join clr in context.Colors.Where(clr => clr.ColorId == colorId) on c.ColorId equals clr.ColorId
                    select new CarDetailDto
                    {
                        CarId = c.Id,
                        CarName = c.CarName,
                        BrandName = b.BrandName,
                        ColorName = clr.ColorName,
                        DailyPrice = c.DailyPrice,
                        Description = c.Description
                    };
                return result.ToList();
            }
        }
    }
}
