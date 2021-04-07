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
    public class PaymentsController : ControllerBase
    {

        ICreditCardService _creditCardService;
        IPaymentService _paymentService;

        public PaymentsController(ICreditCardService creditCardService, IPaymentService paymentService)
        {
            _creditCardService = creditCardService;
            _paymentService = paymentService;
        }

        [HttpPost("save")]
       public  IActionResult Save(CreditCard credit ) 
        {
            var result = _creditCardService.Add(credit);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        
        }

        [HttpPost("add")]
        public IActionResult Add(Payment payment)
        {
            var result = _paymentService.Add(payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("listcards")]
        public IActionResult GetCardsByCustomerId(int customerId)
        {
            var result = _creditCardService.GetByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
