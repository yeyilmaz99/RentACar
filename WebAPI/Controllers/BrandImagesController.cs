using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class BrandImagesController : ControllerBase
    {

        IBrandImageService _brandImageService;

        public BrandImagesController(IBrandImageService brandImageService)
        {
            _brandImageService = brandImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] BrandImageAddDto brandImageAddDto)
        {
            BrandImage brandImage = new BrandImage();
            brandImage.BrandId = brandImageAddDto.BranId;

            using (var memoryStream = new MemoryStream())
            {
                brandImageAddDto.Image.CopyTo(memoryStream);
                brandImage.ImageData = memoryStream.ToArray();
            }

            brandImage.ImageName = Guid.NewGuid().ToString();
            brandImage.Date = DateTime.Now;
            brandImage.ImagePath = brandImage.ImageName + ".png";

            var result = _brandImageService.Add(brandImage);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult GetImageByCarId(int brandId)
        {
            var result = _brandImageService.GetBrandImageById(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }



    }
}

