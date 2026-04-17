using MongoDB.Driver;
using LearningBE.Models.Entities;
namespace LearningBE.Services
{
    public class CompanyService
    {
        private readonly IMongoCollection<Company> _companies;
        public CompanyService(IMongoDatabase database)
        {
            _companies = database.GetCollection<Company>("Companies");
        }
        public async Task<List<Company>> GetAllAsync() => await _companies.Find(_ => true).ToListAsync();
        public async Task<Company> GetByIdAsync(string id) => await _companies.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<Company> GetByMaXNAsync(int maxn) => await _companies.Find(x => x.MaXN == maxn).FirstOrDefaultAsync();

        public async Task CreateAsync(Company newCompany) => await _companies.InsertOneAsync(newCompany);
        public async Task UpdateAsync(string id, Company company) => await _companies.ReplaceOneAsync(x => x.Id == id, company);
        public async Task DeleteAsync(string id) => await _companies.DeleteOneAsync(x => x.Id == id);
    }
}
