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


         [HttpGet("getUsersFavorites")]
         public IActionResult getUsersFavorites(int userId)
         {
             var result = _favoriteService.GetUsersFavorites(userId);
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

         [HttpGet("getfavoritesdetails")]
         public IActionResult getDetails()
         {
             var result = _favoriteService.GetFavoritesDetails();
             if (result.Success)
             {
                 return Ok(result);
             }

             return BadRequest(result);
         }
    }
}
