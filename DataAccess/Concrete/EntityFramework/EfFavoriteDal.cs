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
    public class EfFavoriteDal : EfEntityRepositoryBase<Favorite, MyDatabaseContext>, IFavoriteDal
    {
        public List<UserFavoriteDto> GetFavoritesDetails(Expression<Func<Favorite, bool>> filter)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var result = from fav in filter == null ? context.Favorites : context.Favorites.Where(filter)
                    join c in context.Cars on fav.CarId equals c.Id
                    join usr in context.Users on fav.UserId equals usr.Id
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join clr in context.Colors on c.ColorId equals clr.ColorId
                    select new UserFavoriteDto
                    {
                        CarId = c.Id,
                        UserId = fav.UserId,
                        BrandName = b.BrandName,
                        CarName = c.CarName,
                        DailyPrice = c.DailyPrice,
                        ColorName = clr.ColorName,
                        Description = c.Description,
                        UserName = usr.FirstName + " " + usr.LastName
                    };
                return result.ToList();
            }
        }
    }
}
