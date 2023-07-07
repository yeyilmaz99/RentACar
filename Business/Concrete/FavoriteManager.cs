using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class FavoriteManager : IFavoriteService
    {
        IFavoriteDal _favoriteDal;

        public FavoriteManager(IFavoriteDal favoriteDal)
        {
            _favoriteDal = favoriteDal;
        }

        public IDataResult<List<Favorite>> GetAllFavorites(int userId)
        {
            return new SuccessDataResult<List<Favorite>>(_favoriteDal.GetAll(user => user.UserId == userId));
        }


        public IResult Add(Favorite favorite)
        {

            var result = BusinessRules.Run(CheckIfAlreadyAddedToFavorites(favorite.CarId, favorite.UserId));

            if (result != null)
            {
                return result;
            }

            _favoriteDal.Add(favorite);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(int userId, int carId)
        {
            var result = _favoriteDal.GetAll(user => user.UserId == userId).FindLast(c => c.CarId == carId);
            if(result != null)
            {
                _favoriteDal.Delete(result);
                return new SuccessResult(Messages.Deleted);
            }
            else
            {
                return new ErrorResult(Messages.NotDeleted);
            }

        }

        public IDataResult<List<UserFavoriteDto>> GetFavoritesByUserId(int userId)
        {
            return new SuccessDataResult<List<UserFavoriteDto>>(
                _favoriteDal.GetFavoritesDetails(f => f.UserId == userId));
        }

        public IResult CheckIfAlreadyAddedToFavorites(int carId, int userId)
        {
            var result = _favoriteDal.GetAll(user => user.UserId == userId).FindLast(c => c.CarId == carId);

            if (result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarIsAlreadyAddedToFavorites);
            

        }

        public IDataResult<IEnumerable<UserFavoriteDto>> GetRecentFavoritesByUserId(int userId)
        {
            var result = _favoriteDal.GetFavoritesDetails(user => user.UserId == userId);
            var result1 = result.Skip(Math.Max(0, result.Count() - 3));

            return new SuccessDataResult<IEnumerable<UserFavoriteDto>>(result1);
        }
    }
}
