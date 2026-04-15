using LearningBE.Models.Entities;
using LearningBE.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningBE.Controllers
{
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
        public async Task<List<User>> Get()
        {
            return await _userService.GetAllAsync();
        }

        [HttpGet("getById/{id:Length(24)}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user is null) return NotFound();
            return Ok(user);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Post(User user)
        {
            user.CreatedAt = DateTime.UtcNow;
            await _userService.CreateAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }
        [HttpPut("update/{id:length(24)}")]
        public async Task<IActionResult> Update(string id, User update)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user is null) return NotFound();
            update.Id = user.Id;
            await _userService.UpdateAsync(id, update);
            return NoContent();
        }
        [HttpDelete("delete/{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user is null) return NotFound();
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}