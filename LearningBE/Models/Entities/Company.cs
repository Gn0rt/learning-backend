using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LearningBE.Models.Entities
{
    public class Company
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        [BsonElement("createdAt")] // Mapping tên field trong DB là chữ thường cho chuẩn Mongo
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
