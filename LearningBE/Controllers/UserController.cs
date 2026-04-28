using LearningBE.Models.DTOs;
using LearningBE.Models.Entities;
using LearningBE.Services;
using LearningBE.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningBE.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<UserResponse>>> Get()
        {
            var result = await _userService.GetListUserAsync();
            if (result == null || result.Count == 0)
                return NotFound("No users found");
            return Ok(result);
        }

        [HttpGet("getById/{id:Length(24)}")]
        public async Task<ActionResult<UserResponse>> Get(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user is null) return NotFound();
            return Ok(user);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Post(User user)
        {
            var result = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
        [HttpPut("update/{id:length(24)}")]
        public async Task<IActionResult> Update(string id, User update)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user is null) return NotFound();
            update.Id = user.Id;
            await _userService.UpdateUserAsync(id, update);
            return NoContent();
        }
        [HttpDelete("delete/{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var success = await _userService.DeleteAsync(id);
            if (!success) return NotFound("Không tìm th?y user ?? xóa");
            return NoContent(); // Tr? v? 204
        }
    }
}