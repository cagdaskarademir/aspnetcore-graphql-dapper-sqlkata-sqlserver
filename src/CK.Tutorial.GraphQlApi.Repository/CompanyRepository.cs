using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CK.Tutorial.GraphQlApi.Common.Extension;
using CK.Tutorial.GraphQlApi.Entity;
using CK.Tutorial.GraphQlApi.Model.Request;
using SqlKata.Execution;

namespace CK.Tutorial.GraphQlApi.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        private readonly QueryFactory _queryFactory;
        private const string TableName = "Company";
 
        public CompanyRepository(QueryFactory queryFactory) : base(queryFactory)
        {
            _queryFactory = queryFactory;
        }
        
        public async Task<IEnumerable<Company>> GetCompanies(SearchCompany request)
        {
            var query = _queryFactory
                .Query(TableName)
                .When(request.Columns.AnyItem(),
                    q => q.Select(request.Columns.ToArray()))
                .OrderBy("Id")
                .ForPage(request.Page ?? request.DefaultPage, request.PageSize ?? request.DefaultPageSize)
                .GetAsync<Company>();
                
            return await query.ConfigureAwait(false);
        }

        public async Task<Company> GetCompany(SearchCompany request)
        {
            var query = _queryFactory
                .Query(TableName)
                .When(request.Columns.AnyItem(),
                    q => q.Select(request.Columns.ToArray()))
                .OrderBy("Id")
                .FirstOrDefaultAsync<Company>();

            return await query.ConfigureAwait(false);
        }
    }
}