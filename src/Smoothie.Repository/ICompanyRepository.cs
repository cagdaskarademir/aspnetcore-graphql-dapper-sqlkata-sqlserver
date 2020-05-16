using System.Collections.Generic;
using System.Threading.Tasks;
using Smoothie.Entity;
using Smoothie.Model.Request;
using SqlKata.Execution;

namespace Smoothie.Repository
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanies(SearchCompanies request);
        Task<Company> GetCompany(SearchCompany request);
    }
}