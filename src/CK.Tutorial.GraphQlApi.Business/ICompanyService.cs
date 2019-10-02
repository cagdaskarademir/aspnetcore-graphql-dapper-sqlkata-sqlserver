using System.Collections.Generic;
using System.Threading.Tasks;
using CK.Tutorial.GraphQlApi.Entity;
using CK.Tutorial.GraphQlApi.Model.Request;
using SqlKata.Execution;

namespace CK.Tutorial.GraphQlApi.Business
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetCompanies(SearchCompany request);
        Task<Company> GetCompany(SearchCompany request);
    }
}