using SqlKata.Execution;

namespace CK.Tutorial.GraphQlApi.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
    {
        public RepositoryBase(QueryFactory queryFactory)
        {
            QueryFactory = queryFactory;
        }

        public QueryFactory QueryFactory { get; set; }
    }
}