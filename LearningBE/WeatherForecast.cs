using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace LearningBE
{
    public class WeatherForecast
    {
        [BsonId]// Đánh dấu đây là khóa chính
        [BsonRepresentation(BsonType.ObjectId)]// Cho phép mapping giữa kiểu string và ObjectId của MongoDB
        public string? Id { get; set; }
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
