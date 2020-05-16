using System.Collections.Generic;
using System.Threading.Tasks;
using Smoothie.Entity;
using Smoothie.Model.Request;
using SqlKata.Execution;

namespace Smoothie.Business
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetCompanies(SearchCompanies request);
        Task<Company> GetCompany(SearchCompany request);
    }
}