using LearningBE.Models.Entities;

namespace LearningBE.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<List<Company>> GetListCompanyAsync();
        Task<Company> GetCompanyByIdAsync(string id);
        Task<Company> CreateCompanyAsync(Company company);
        Task<bool> UpdateCompanyAsync(string id,  Company companyUpdate);
        Task<bool> DeleteCompanyAsync(string id);

    }
}
