using MongoDB.Driver;
using LearningBE.Models.Entities;
using LearningBE.Repositories;
namespace LearningBE.Services
{
    public class CompanyService
    {
        private readonly CompanyRepository _companyRepo;
        public CompanyService(CompanyRepository companyRepository)
        {
            _companyRepo = companyRepository;
        }

        public async Task<List<Company>> GetListCompanyAsync()
        {
            var companies = await _companyRepo.GetAll();
            return companies;
        }
        public async Task<Company> GetCompanyByIdAsync(string id)
        {
            var company = await _companyRepo.GetByIdAsync(id);
            return company;
        }

    }
}
