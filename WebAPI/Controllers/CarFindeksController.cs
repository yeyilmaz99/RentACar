﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CarFindeksController : Controller
    {
        ICarFindeksService _carFindeksService;

        public CarFindeksController(ICarFindeksService carFindeksService)
        {
            this._carFindeksService = carFindeksService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _carFindeksService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetCarDetails(int carId)
        {
            var result = _carFindeksService.GetById(carId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




    }
}

