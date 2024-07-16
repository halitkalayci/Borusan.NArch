using Domain;
using System.Linq.Expressions;

namespace Application.Repositories
{
    public interface IAsyncRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>, new()
    {
        // GetAllAsync GetAsync vs..
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        // i=>i.Id==1
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, CancellationToken cancellationToken = default);
    }
}
