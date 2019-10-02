using System.Collections.Generic;
using System.Threading.Tasks;
using CK.Tutorial.GraphQlApi.Entity;
using CK.Tutorial.GraphQlApi.Model.Request;
using CK.Tutorial.GraphQlApi.Repository;

namespace CK.Tutorial.GraphQlApi.Business
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        
        public Task<IEnumerable<Company>> GetCompanies(SearchCompany request)
        {
            return _companyRepository.GetCompanies(request);
        }

        public Task<Company> GetCompany(SearchCompany request)
        {
            return _companyRepository.GetCompany(request);
        }
    }
}