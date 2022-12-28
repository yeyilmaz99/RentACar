using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindeksController : ControllerBase
    {
        IFindeksService _findeksService;

        public FindeksController(IFindeksService findeksService)
        {
            _findeksService = findeksService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _findeksService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getByUserId")]
        public IActionResult getByUserId(int userId)
        {
            var result = _findeksService.GetById(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("checkIfSufficient")]
        public IActionResult CheckIfSuffucient(int carFP, int userId)
        {

            var result1 = _findeksService.GetById(userId);

            var result = _findeksService.CheckIfFPSufficient(carFP, result1);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpPatch("update")]
        public IActionResult Update(Findeks findeks)
        {
            var result = _findeksService.Update(findeks);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpPost("add")]
        public IActionResult Add(Findeks findeks)
        {
            var result = _findeksService.Add(findeks);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("checkIfAlreadyExists")]
        public IActionResult CheckIfAlreadyExists(int userId)
        {
            var result = _findeksService.checkIfAlreadyExist(userId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }












    }
}

