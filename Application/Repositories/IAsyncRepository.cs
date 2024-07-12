using Domain;

namespace Application.Repositories
{
    public interface IAsyncRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>, new()
    {
        // GetAllAsync GetAsync vs..
        Task<TEntity> AddAsync(TEntity entity);
    }
}
