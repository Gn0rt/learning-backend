using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LearningBE.Models.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
        [BsonElement("createdAt")] // Mapping tên field trong DB là chữ thường cho chuẩn Mongo
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
