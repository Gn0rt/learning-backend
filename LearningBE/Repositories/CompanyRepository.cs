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

    }
}
