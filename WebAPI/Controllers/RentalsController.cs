using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;
        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getrentdetails")]
        public IActionResult GetRentDetails()
        {
            var result = _rentalService.GetRentalDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getrentbyid")]
        public IActionResult GetRentById(int rentId)
        {
            var result = _rentalService.GetRentalById(rentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getrentbycarid")]
        public IActionResult GetRentByCarId(int carId)
        {
            var result = _rentalService.GetRentByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("rent")]
        public IActionResult Rent(Rental rental)
        {
            var result = _rentalService.Rent(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("iscaravailable")]
        public IActionResult IsCarAvailable(int carId)
        {
            var result = _rentalService.IsCarAvailable(carId);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

       

    }
}
