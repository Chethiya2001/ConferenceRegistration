using ConfReg.Application.Abstractions;
using ConfReg.Application.DTOs.Request;
using ConfReg.Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace ConfReg.API.Controllers
{
    [ApiController]
    [Route("api/membership")]
    public class MembershipController(IMembershipService membershipService) : ControllerBase
    {


        [HttpGet]
        [ProducesResponseType(typeof(IList<MembershipResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync() {
            var users =  await membershipService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MembershipResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var user = await membershipService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        public async Task<IActionResult> InsertAsync([FromBody]CreateMembershipRequest createMembershipRequest )
        {
            await membershipService.InsertAsync(createMembershipRequest);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync([FromBody] EditMembershipRequest editMembershipRequest)
        {
            await membershipService.UpdateAsync(editMembershipRequest);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public IActionResult DeleteAsync(long id)
        {
            membershipService.DeleteAsync(id);
            return Ok();
        }




    }
}
