using MongoDB.Driver;
using LearningBE.Models.Entities;
namespace LearningBE.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _user;
        public UserService(IMongoDatabase database)
        {
            _user = database.GetCollection<User>("Users");
        }
        public async Task<List<User>> GetAllAsync() => await _user.Find(_ => true).ToListAsync();
        public async Task<User> GetByIdAsync(string id) => await _user.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(User newUser) => await _user.InsertOneAsync(newUser);
        public async Task UpdateAsync(string id, User user) => await _user.ReplaceOneAsync(x => x.Id == id, user);
        public async Task DeleteAsync(string id) => await _user.DeleteOneAsync(x => x.Id == id);
    }
}
