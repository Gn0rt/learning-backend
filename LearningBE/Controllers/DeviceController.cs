using LearningBE.Services;
using Microsoft.AspNetCore.Mvc;
using LearningBE.Models.Entities;
namespace LearningBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly DeviceService _deviceService;
        public DeviceController(DeviceService devivceService)
        {
            _deviceService = devivceService;
        }

        [HttpGet("getall")]
        public async Task<List<Device>> Get()
        {
            return await _deviceService.GetAllAsync();
        }
        [HttpGet("getById/{id:length(24)}")]
        public async Task<ActionResult<Device>> Get(string id)
        {
            var device = await _deviceService.GetByIdAsync(id);
            if(device is  null) return NotFound();
            return Ok(device);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Post(Device device)
        {
            device.CreatedAt = DateTime.UtcNow;
            await _deviceService.CreateAsync(device);
            return CreatedAtAction(nameof(Get), new { id = device.Id }, device);
        }
        [HttpPut("update/{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Device deviceUp)
        {
            var device = await _deviceService.GetByIdAsync(id);
            if (device is null) return NotFound();
            deviceUp.Id = device.Id;
            await _deviceService.UpdateAsync(id, deviceUp);
            return NoContent();
        }
        [HttpDelete("delete/{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var device = await _deviceService.GetByIdAsync(id);
            if (device is null) return NotFound();
            await _deviceService.DeleteAsync(id);
            return NoContent();
        }

    }
}
