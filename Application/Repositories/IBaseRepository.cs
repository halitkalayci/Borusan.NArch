using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IBaseRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>, new()
    {
        List<TEntity> GetAll();
        TEntity? GetById(TId id);
        TEntity Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
