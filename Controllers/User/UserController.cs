using IoT.DTO.Users;
using IoT.Service.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
namespace IoT.Controllers.User
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public  UserController (IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct = default)
        {
            try
            {
                var result = await _userService.GetUsersResponseAsync(ct);
                return Ok(result);
            }
            catch (OperationCanceledException ex)
            {
                return StatusCode(499, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            try
            {
                var result = await _userService.GetUserById(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                return StatusCode(499, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:guid}/hubs")]
        public async Task<IActionResult> GetWithHubs(Guid id, CancellationToken ct)
        {
            try
            {
                var result = await _userService.GetUserWithHubs(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                return StatusCode(499, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreation creation, CancellationToken ct)
        {
            try
            {
                await _userService.UserCreate(creation);
                return Ok();
            }
            catch (OperationCanceledException ex)
            {
                return StatusCode(499, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UserUpdate update, CancellationToken ct)
        {
            try
            {
                await _userService.UpdateUser(update);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(499, "Request cancelled");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> Patch(Guid id, UserPatchUpdate patch, CancellationToken ct)
        {
            try
            {
                await _userService.UpdatePatch(id, patch, ct);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                return StatusCode(499, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            try
            {
                await _userService.DeleteUser(id, ct);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                return StatusCode(499, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}


