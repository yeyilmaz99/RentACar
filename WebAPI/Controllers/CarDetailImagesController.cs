using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDetailImagesController : ControllerBase
    {
        ICarDetailImageService _carDetailImageService;
        public CarDetailImagesController(ICarDetailImageService carDetailImageService)
        {
            _carDetailImageService = carDetailImageService;
        }

        [HttpPost("add")]
        public IActionResult AddDetailPhotos([FromForm] List<IFormFile> images, int carId)
        {
            List<CarDetailImage> carDetailImages = new List<CarDetailImage>();

            foreach (var image in images)
            {
                using (var memoryStream = new MemoryStream())
                {
                    image.CopyTo(memoryStream);
                    carDetailImages.Add(new CarDetailImage
                    {
                        CarId = carId,
                        ImageData = memoryStream.ToArray()
                    });
                }
            }

            var result = _carDetailImageService.Add(carDetailImages.ToArray());
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getall")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carDetailImageService.GetAllImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }






    }

}


