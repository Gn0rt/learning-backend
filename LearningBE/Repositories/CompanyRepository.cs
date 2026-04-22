using LearningBE.Models.Entities;
using MongoDB.Driver;

namespace LearningBE.Repositories
{
    public class CompanyRepository
    {
        private readonly IMongoCollection<Company> _companies;
        public CompanyRepository(IMongoDatabase database)
        {
            _companies = database.GetCollection<Company>("Companies");
        }

        public async Task<List<Company>> GetAll() => await _companies.Find(_ => true).ToListAsync();
        public async Task<Company> GetByIdAsync(string id) => await _companies.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Company newCom) => await _companies.InsertOneAsync(newCom);
        public async Task UpdateAsync(string id, Company company) => await _companies.ReplaceOneAsync(x => x.Id == id, company);
        public async Task DeleteAsync(string id) => await _companies.DeleteOneAsync(x => x.Id == id);
    }
}
