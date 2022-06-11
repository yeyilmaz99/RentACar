using System.Threading;
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

        [HttpGet("getcarsdetails")]
        public IActionResult GetCarsDetails()
        {
            var result = _carService.GetCarsDetails();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails(int carId)
        {
            var result = _carService.GetCarDetails(carId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbybrand")]
        public IActionResult GetByBrandId(int brandId)
        {
            var result = _carService.GetCarsDetailsByBrandId(brandId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycolor")]
        public IActionResult GetByColorId(int colorId)
        {
            var result = _carService.GetCarsDetailsColorId(colorId);
            if (result.Success == true)
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
