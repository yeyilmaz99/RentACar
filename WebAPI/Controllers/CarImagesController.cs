using Business.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Web;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }


        [HttpPost("add")]
        public IActionResult Add([FromForm] ImageAddDto imageDto)
        {

            CarImage carImage = new CarImage();

            carImage.CarId = imageDto.CarId;    

            carImage.Image = imageDto.Image;

            carImage.ImageName = Guid.NewGuid().ToString();

            carImage.Date = DateTime.Now;

            carImage.ImagePath = carImage.ImageName + ".png";

            if (carImage.Image.Length>0)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), @"images/" + carImage.ImageName + ".png");

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"images/");

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }


                using (var stream = System.IO.File.Create(imagePath))
                {
                    carImage.Image.CopyTo(stream);
                }
            }

            var result = _carImageService.Add(carImage);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetAllImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }

    }

}

