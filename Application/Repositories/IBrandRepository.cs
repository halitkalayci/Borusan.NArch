using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IBrandRepository
    {
        List<Brand> GetAll();
        Brand? GetById(Guid id);
        Brand Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);
    }
}
