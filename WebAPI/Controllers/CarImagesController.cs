using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
                            //claims
        //[SecuredOperation("admin,product.add")]
        [HttpPost("add")]
        public IActionResult Add([FromForm] ImageAddDto imageDto)
        {
            CarImage carImage = new CarImage();
            carImage.CarId = imageDto.CarId;

            using (var memoryStream = new MemoryStream())
            {
                imageDto.Image.CopyTo(memoryStream);
                carImage.ImageData = memoryStream.ToArray();
            }

            carImage.ImageName = Guid.NewGuid().ToString();
            carImage.Date = DateTime.Now;
            carImage.ImagePath = carImage.ImageName + ".png";

            var result = _carImageService.Add(carImage);
            if (result.Success == true)
            {
                if (carImage.ImageData.Length > 0)
                {
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), @"images/" + carImage.ImageName + ".png");
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"images/");

                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    // Save the image to a file
                    System.IO.File.WriteAllBytes(imagePath, carImage.ImageData);
                }
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


        [HttpGet("get")]
        public IActionResult GetImageByName(string name)
        {
            var result = _carImageService.GetImageByName(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }

    }

}

