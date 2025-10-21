using ConfReg.Application.Abstractions;
using ConfReg.Application.DTOs.Request;
using ConfReg.Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace ConfReg.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController(IUserService userService) : ControllerBase
    {


        [HttpGet]
        [ProducesResponseType(typeof(IList<UserResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync() {
            var users =  await userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var user = await userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        public async Task<IActionResult> InsertAsync([FromBody]CreateUserRequest createUserRequest )
        {
            await userService.InsertAsync(createUserRequest);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync([FromBody] EditUserRequest editUserRequest)
        {
            await userService.UpdateAsync(editUserRequest);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public IActionResult DeleteAsync(long id)
        {
            userService.DeleteAsync(id);
            return Ok();
        }




    }
}
