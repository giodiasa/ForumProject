using Forum.Application.Identity;
using Forum.Application.Interfaces;
using Forum.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private ApiResponse _response;

        public UsersController(IUserService userService)
        {
            _userService = userService;
            _response = new();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsersAsync();
            _response.Result = result;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpGet("email/{email}")]
        [Authorize]
        public async Task<IActionResult> UserByEmail(string email)
        {
            var result = await _userService.GetSingleUserByEmailAsync(email);
            _response.Result = result;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUserAsync(id);
            _response.Result = id;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromForm]UserDto model)
        {
            await _userService.UpdateUserAsync(model);
            _response.Result = model;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPatch ("{userId}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] JsonPatchDocument<UserDto> patchDocument)
        {
            await _userService.UpdateUserAsync(userId, patchDocument);
            _response.Result = userId;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);
        }
    }
}
