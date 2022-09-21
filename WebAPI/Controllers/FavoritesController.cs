using Business.Abstract;
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

    }
}
