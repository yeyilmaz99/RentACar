using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carservice;

        public CarsController(ICarService carservice)
        {
            _carservice = carservice;
        }


        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _carservice.GetAll();
            if(result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }




    }
}
