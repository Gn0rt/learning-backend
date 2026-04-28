using MongoDB.Driver;
using LearningBE.Models.Entities;
using LearningBE.Repositories;
using LearningBE.Services.Interfaces;
namespace LearningBE.Services
{
    public class CompanyService : ICompanyService
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
        public async Task<Company> CreateCompanyAsync(Company company)
        {
            company.CreatedAt = DateTime.UtcNow;
            await _companyRepo.CreateAsync(company);
            return company;
        }
        public async Task<bool> UpdateCompanyAsync(string id, Company companyUpdate)
        {
            var oldCompany = await _companyRepo.GetByIdAsync(id);
            if (oldCompany == null) return false;
            companyUpdate.Id = oldCompany.Id;
            await _companyRepo.UpdateAsync(id, companyUpdate);
            return true;
        }
        public async Task<bool> DeleteCompanyAsync(string id)
        {
            var oldCompany = await _companyRepo.GetByIdAsync(id);
            if (oldCompany == null) return false;
            await _companyRepo.DeleteAsync(id);
            return true;
        }

    }
}
