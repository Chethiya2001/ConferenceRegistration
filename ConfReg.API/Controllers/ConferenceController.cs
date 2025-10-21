using ConfReg.Application.Abstractions;
using ConfReg.Application.DTOs.Request;
using ConfReg.Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace ConfReg.API.Controllers
{
    [ApiController]
    [Route("api/conference")]
    public class ConferenceController(IConferenceService conferenceService) : ControllerBase
    {


        [HttpGet]
        [ProducesResponseType(typeof(IList<ConferenceResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync() {
            var users =  await conferenceService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ConferenceResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var user = await conferenceService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        public async Task<IActionResult> InsertAsync([FromBody]CreateConferenceRequest createConferenceRequest)
        {
            await conferenceService.InsertAsync(createConferenceRequest);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync([FromBody] EditConferenceRequest editConferenceRequest)
        {
            await conferenceService.UpdateAsync(editConferenceRequest);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public IActionResult DeleteAsync(long id)
        {
            conferenceService.DeleteAsync(id);
            return Ok();
        }




    }
}
