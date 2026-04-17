using LearningBE.Models.DTOs;
using LearningBE.Models.Entities;
using LearningBE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningBE.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public async Task<List<UserResponse>> Get()
        {
            return await _userService.GetListUserAsync();
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