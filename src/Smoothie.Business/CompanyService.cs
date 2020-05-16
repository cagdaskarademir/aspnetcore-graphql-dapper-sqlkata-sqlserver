using System.Collections.Generic;
using System.Threading.Tasks;
using Smoothie.Model.Request;
using Smoothie.Entity;
using Smoothie.Repository;

namespace Smoothie.Business
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Task<IEnumerable<Company>> GetCompanies(SearchCompanies request)
        {
            return _companyRepository.GetCompanies(request);
        }

        public Task<Company> GetCompany(SearchCompany request)
        {
            return _companyRepository.GetCompany(request);
        }
    }
}