using System;
using System.IO;
using System.Threading;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;
        ICarImageService _carImageService;

        public CarsController(ICarService carservice , ICarImageService carImageService)
        {
            _carService = carservice;
            _carImageService = carImageService;
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
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpPost("add")]
        //public IActionResult Add([FromForm] CarAndImageDto carAndImageDto)
        //{
        //    var result = _carService.AddCar(carAndImageDto);

        //    if (!result.Success)
        //    {
        //        return BadRequest(result);
        //    }

        //    CarImage carImage = new CarImage();
        //    carImage.CarId = result.Data.Id;
        //    carImage.ImageName = Guid.NewGuid().ToString();
        //    carImage.Date = DateTime.Now;
        //    carImage.ImagePath = carImage.ImageName + ".png";

        //    if (carAndImageDto.Image != null && carAndImageDto.Image.Length > 0)
        //    {
        //        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "images", carImage.ImageName + ".png");
        //        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "images");

        //        if (!Directory.Exists(filePath))
        //        {
        //            Directory.CreateDirectory(filePath);
        //        }

        //        using (var stream = new FileStream(imagePath, FileMode.Create))
        //        {
        //            carAndImageDto.Image.CopyTo(stream);
        //        }
        //    }

        //    var result1 = _carImageService.Add(carImage);

        //    if (!result1.Success)
        //    {
        //        // Gerçekleşen hata durumunda resmi silme işlemi yapılabilir
        //        return BadRequest(result1);
        //    }

        //    return Ok(result1);
        //}







        [HttpGet("getbybrandidandcolorid")]

        public IActionResult GetByBrandIdAndColorId(int colorId,int brandId)
        {
            var result = _carService.GetCarsByBrandIdAndColorId(colorId,brandId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPatch("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}
