using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using static System.Net.Mime.MediaTypeNames;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;
        ICarImageService _carImageService;
        ICarDetailImageService _carDetailImageService;

        public CarsController(ICarService carservice , ICarImageService carImageService, ICarDetailImageService carDetailImageService)
        {
            _carService = carservice;
            _carImageService = carImageService;
            _carDetailImageService = carDetailImageService;
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


        //[HttpPost("add")]
        //public IActionResult Add(Car car)
        //{
        //    var result = _carService.Add(car);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarAndImageDto carAndImageDto)
        {
            var result = _carService.AddCar(carAndImageDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            CarImage carImage = new CarImage();
            carImage.CarId = result.Data.Id;

            using (var memoryStream = new MemoryStream())
            {
                carAndImageDto.ImageData.CopyTo(memoryStream);
                carImage.ImageData = memoryStream.ToArray();
            }


            List<CarDetailImage> carDetailImages = new List<CarDetailImage>();
            foreach (var image in carAndImageDto.DetailImages)
            {
                using (var memoryStream = new MemoryStream())
                {
                    image.CopyTo(memoryStream);
                    carDetailImages.Add(new CarDetailImage
                    {
                        CarId = result.Data.Id,
                        ImageData = memoryStream.ToArray()
                    });
                }
            }

            var result2 = _carDetailImageService.Add(carDetailImages.ToArray());

            carImage.ImageName = Guid.NewGuid().ToString();
            carImage.Date = DateTime.Now;
            carImage.ImagePath = carImage.ImageName + ".png";

            var result1 = _carImageService.Add(carImage);
            if (result.Success & result1.Success & result.Success == true)
            {
                return Ok(result1);
            }

            return BadRequest(result1);
        }







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
