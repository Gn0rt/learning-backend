using MongoDB.Driver;
using LearningBE.Models.Entities;
using LearningBE.Repositories;
using LearningBE.Models.DTOs;
using System.Linq;
using LearningBE.Services.Interfaces;
namespace LearningBE.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepo;
        public UserService(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<List<UserResponse>> GetListUserAsync()
        {
            var users = await _userRepo.GetAllAsync();
            return users.Select(u => MapToDTO(u)).ToList();
        }
        public async Task<UserResponse?> GetUserByIdAsync(string id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            return user == null ? null : MapToDTO(user);
        }
        public async Task<UserResponse> CreateUserAsync(User newUser)
        {
            newUser.CreatedAt = DateTime.UtcNow;
            await _userRepo.CreateAsync(newUser);
            return MapToDTO(newUser);
        }
        public async Task<bool> UpdateUserAsync(string id, User userUpdate)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return false;
            userUpdate.Id = user.Id;
            await _userRepo.UpdateAsync(id, userUpdate);
            return true;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var existingUser = await _userRepo.GetByIdAsync(id);
            if (existingUser == null) return false;

            await _userRepo.DeleteAsync(id);
            return true;
        }
        // Hàm phụ trợ Map từ Entity sang DTO 
        private UserResponse MapToDTO(User u) => new UserResponse
        {
            Id = u.Id,
            Fullname = u.Fullname,
            Username = u.Username,
            Email = u.Email,
            Phone = u.Phone,
            CompanyId = u.CompanyId,
            CreatedAt = u.CreatedAt
        };
    }
}
