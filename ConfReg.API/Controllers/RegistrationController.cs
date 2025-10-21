using ConfReg.Application.Abstractions;
using ConfReg.Application.DTOs.Request;
using ConfReg.Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace ConfReg.API.Controllers
{
    [ApiController]
    [Route("api/registration")]
    public class RegistrationController(IRegistrationService registrationService) : ControllerBase
    {


        [HttpGet]
        [ProducesResponseType(typeof(IList<RegistrationResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync() {
            var users =  await registrationService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RegistrationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var user = await registrationService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        public async Task<IActionResult> InsertAsync([FromBody]CreateRegistrationRequest createRegistrationRequest )
        {
            await registrationService.InsertAsync(createRegistrationRequest);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync([FromBody] EditRegistrationRequest editRegistrationRequest)
        {
            await registrationService.UpdateAsync(editRegistrationRequest);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public IActionResult DeleteAsync(long id)
        {
            registrationService.DeleteAsync(id);
            return Ok();
        }




    }
}
