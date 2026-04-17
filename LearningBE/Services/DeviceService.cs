using MongoDB.Driver;
using LearningBE.Models.Entities;
namespace LearningBE.Services
{
    public class DeviceService
    {
        private readonly IMongoCollection<Device> _device;
        public DeviceService(IMongoDatabase database) 
        {
            _device = database.GetCollection<Device>("Devices");
        }
        public async Task<List<Device>> GetAllAsync() => await _device.Find(_ => true).ToListAsync();
        public async Task<Device> GetByIdAsync(string id) => await _device.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Device newDevice) => await _device.InsertOneAsync(newDevice);
        public async Task UpdateAsync(string id, Device device) => await _device.ReplaceOneAsync(x => x.Id == id, device);
        public async Task DeleteAsync(string id) => await _device.DeleteOneAsync(x => x.Id == id);
    }
}
