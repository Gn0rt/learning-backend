using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using LearningBE;
namespace LearningBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMongoCollection<WeatherForecast> _weatherCollection;

        public WeatherForecastController(IMongoDatabase database)
        {

            // Kết nối tới collection đặt tên là "Forecasts"
            _weatherCollection = database.GetCollection<WeatherForecast>("Forecasts");
        }

        //Get all
        [HttpGet("getall")]
        public async Task<List<WeatherForecast>> Get()
        {
            return await _weatherCollection.Find(_ => true).ToListAsync();
        }

        //get by id
        [HttpGet("getById/{id:length(24)}")]
        public async Task<ActionResult<WeatherForecast>> Get(string id)
        {
            var forecast = await _weatherCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if(forecast is null) return NotFound();
            return Ok(forecast);
        }
        //create
        [HttpPost("create")]
        public async Task<IActionResult> Post(WeatherForecast forecast)
        {
            // Lưu một bản ghi mới vào MongoDB
            await _weatherCollection.InsertOneAsync(forecast);
            return CreatedAtAction(nameof(Get), new { id = forecast.Id }, forecast);
        }

        //update by id
        [HttpPut("update/{id:length(24)}")]
        public async Task<IActionResult> Update(string id, WeatherForecast updatedForecast)
        {
            var forecast = await _weatherCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if(forecast is null) return NotFound();
            updatedForecast.Id = forecast.Id; //giữ id cũ
            await _weatherCollection.ReplaceOneAsync(x => x.Id == id, updatedForecast);
            return NoContent();
        }

        //delete
        [HttpDelete("delete/{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _weatherCollection.DeleteOneAsync(x => x.Id == id);
            if(result.DeletedCount == 0) return NotFound();
            return NoContent();
        }
    }
}
