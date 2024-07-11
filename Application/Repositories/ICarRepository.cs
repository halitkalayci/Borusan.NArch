using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ICarRepository : IBaseRepository<Car, Guid>
    {
        Car? GetByPlate(string plate);
    }
}
