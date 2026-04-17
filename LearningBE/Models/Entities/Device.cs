using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LearningBE.Models.Entities
{
    public class Device
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Imei { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        [BsonElement("createdAt")] // Mapping tên field trong DB là chữ thường cho chuẩn Mongo
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
