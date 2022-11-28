using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
         IFavoriteService _favoriteService;

         public FavoritesController(IFavoriteService favoriteService)
         {
             _favoriteService = favoriteService;
         }


         [HttpPost("add")]
         public IActionResult Add(Favorite favorite)
         {
             var result = _favoriteService.Add(favorite);
             if (result.Success)
             {
                 return Ok(result);
             }

             return BadRequest(result);
         }

        [HttpGet("getall")]
         public IActionResult GetAll(int userId)
         {
             var result = _favoriteService.GetAllFavorites(userId);
             if (result.Success)
             {
                 return Ok(result);
             }

             return BadRequest(result);
         }

         [HttpGet("getfavoritesbyuserid")]
         public IActionResult GetFavoritesDetailsByUserId(int id)
         {
             var result = _favoriteService.GetFavoritesByUserId(id);
             if (result.Success)
             {
                 return Ok(result);
             }

             return BadRequest(result);
         }

        [HttpGet("checkifalreadyaddedtofavorites")]

        public IActionResult CheckIfAlreadyAddedToFavorites(int carId,int userId)
        {
            var result = _favoriteService.CheckIfAlreadyAddedToFavorites(carId, userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Favorite favorite)
        {
            var result = _favoriteService.Delete(favorite);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getrecent")]

        public IActionResult GetRecentFavorites(int userId)
        {
            var result = _favoriteService.GetRecentFavoritesByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }









    }
}
