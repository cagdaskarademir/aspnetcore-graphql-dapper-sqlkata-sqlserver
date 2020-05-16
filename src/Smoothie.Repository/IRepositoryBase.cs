using SqlKata.Execution;

namespace Smoothie.Repository
{
    public interface IRepositoryBase<TEntity>
    {
        QueryFactory QueryFactory { get; }
    }
}