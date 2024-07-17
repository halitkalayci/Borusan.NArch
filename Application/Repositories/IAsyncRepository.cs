using Domain;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Repositories
{
    public interface IAsyncRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>, new()
    {
        // GetAllAsync GetAsync vs..
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        // i=>i.Id==1
        Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            CancellationToken cancellationToken = default);
    }
}
