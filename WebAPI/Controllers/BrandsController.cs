using System;
using System.IO;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;
        IBrandImageService _brandImageService;

        public BrandsController(IBrandService brandService, IBrandImageService brandImageService)
        {
            _brandService = brandService;
            _brandImageService = brandImageService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _brandService.GetAll();
            if(result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _brandService.GetById(id);
            if(result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm]BrandAndImageDto brandAndImageDto)
        {
            var result = _brandService.AddBrand(brandAndImageDto);

            BrandImage brandImage = new BrandImage();
            brandImage.BrandId = result.Data.BrandId;

            using (var memoryStream = new MemoryStream())
            {
                brandAndImageDto.ImageData.CopyTo(memoryStream);
                brandImage.ImageData = memoryStream.ToArray();
            }

            brandImage.ImageName = Guid.NewGuid().ToString();
            brandImage.Date = DateTime.Now;
            brandImage.ImagePath = brandImage.ImageName + ".png";

            var result2 = _brandImageService.Add(brandImage);

            if (result.Success & result2.Success == true)
            {
                return Ok(result2);
            }
            return BadRequest(result);
        }

        [HttpPatch("update")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandService.Update(brand);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandService.Delete(brand);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getdetail")]
        public IActionResult GetAllBrandsDetails()
        {
            var result = _brandService.GetBrandDetails();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
