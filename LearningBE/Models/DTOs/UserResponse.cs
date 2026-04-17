using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace LearningBE.Models.DTOs
{
    public class UserResponse
    {
        public string? Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
