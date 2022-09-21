using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IFavoriteService
    {
        IDataResult<List<Favorite>> GetAllFavorites(int userId);
        IResult Add(Favorite favorite);
        IResult Delete(Favorite favorite);
        IDataResult<List<UserFavoriteDto>> GetUsersFavorites(int userId);
        IDataResult<List<UserFavoriteDto>> GetFavoritesDetails();
    }
}
