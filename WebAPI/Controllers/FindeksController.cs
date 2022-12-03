using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class FindeksController : Controller
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
        public IActionResult GetFavoritesDetailsByUserId(int userId)
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








    }
}

