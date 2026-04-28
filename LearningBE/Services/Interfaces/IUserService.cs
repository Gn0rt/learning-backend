using LearningBE.Models.DTOs;
using LearningBE.Models.Entities;
using System.Reflection.Metadata;

namespace LearningBE.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetListUserAsync();
        Task<UserResponse?> GetUserByIdAsync(string id);
        Task<UserResponse> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(string id, User user);
        Task<bool> DeleteAsync(string id);
    }
}
