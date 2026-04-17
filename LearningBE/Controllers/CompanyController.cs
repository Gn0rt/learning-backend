using LearningBE.Models.Entities;
using LearningBE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningBE.Controllers
{
    [Authorize] // Phải có Token mới vào được đây
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _companyService;
        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> Get()
        {
            var result = await _companyService.GetAllAsync();

            return Ok(result);

        }
        [HttpGet("getById/{id:Length(24)}")]
        public async Task<ActionResult<Company>> Get(string id)
        {
            var company = await _companyService.GetByIdAsync(id);
            if (company is null) return NotFound();
            return Ok(company);
        }
        [HttpGet("getByMaXN/{maxn:int}")]
        public async Task<ActionResult<Company>> Get(int maxn)
        {
            var company = await _companyService.GetByMaXNAsync(maxn);
            if (company is null) return NotFound();
            return Ok(company);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Post(Company company)
        {
            company.CreatedAt = DateTime.UtcNow;// Gán ngày tạo ở đây cho chắc
            await _companyService.CreateAsync(company);
            return CreatedAtAction(nameof(Get), new { id = company.Id }, company);

        }
        [HttpPut("update/{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Company update)
        {
            var company = await _companyService.GetByIdAsync(id);
            if(company is null) return NotFound();
            update.Id = company.Id;
            await _companyService.UpdateAsync(id, update);
            return NoContent();
        }
        [HttpDelete("delete/{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var company = await _companyService.GetByIdAsync(id);
            if (company is null) return NotFound();

            await _companyService.DeleteAsync(id);
            return NoContent();
        }
    }
}
