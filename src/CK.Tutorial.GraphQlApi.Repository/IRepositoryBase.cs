using SqlKata.Execution;

namespace CK.Tutorial.GraphQlApi.Repository
{
    public interface IRepositoryBase<TEntity>
    {
        QueryFactory QueryFactory { get; }
    }
}