using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carservice)
        {
            _carService = carservice;
        }


        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _carService.GetAll();
            if(result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult Get(int id)
        {
            var result = _carService.GetById(id);
            if(result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("add")]

        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if(result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




    }
}
