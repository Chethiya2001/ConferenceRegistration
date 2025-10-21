using ConfReg.Application.Abstractions;
using ConfReg.Application.DTOs.Request;
using ConfReg.Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace ConfReg.API.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController(IPaymentService paymentService) : ControllerBase
    {


        [HttpGet]
        [ProducesResponseType(typeof(IList<PaymentResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync() {
            var users =  await paymentService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PaymentResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var user = await paymentService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        public async Task<IActionResult> InsertAsync([FromBody]CreatePaymentRequest createPaymentRequest)
        {
            await paymentService.InsertAsync(createPaymentRequest);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync([FromBody] EditPaymentRequest editPaymentRequest)
        {
            await paymentService.UpdateAsync(editPaymentRequest);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public IActionResult DeleteAsync(long id)
        {
            paymentService.DeleteAsync(id);
            return Ok();
        }




    }
}
