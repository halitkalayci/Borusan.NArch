using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EfBrandRepository : IBrandRepository
    {
        private readonly BorusanDbContext _borusanDbContext;

        public EfBrandRepository(BorusanDbContext borusanDbContext)
        {
            _borusanDbContext = borusanDbContext;
        }

        public Brand Add(Brand brand)
        {
            var addedBrand = _borusanDbContext.Brands.Add(brand);
            _borusanDbContext.SaveChanges();
            return addedBrand.Entity;
        }

        public void Delete(Brand brand)
        {
            _borusanDbContext.Brands.Remove(brand);
            _borusanDbContext.SaveChanges();
        }

        public List<Brand> GetAll()
        {
            return _borusanDbContext.Brands.ToList();
        }

        public Brand? GetById(Guid id)
        {
            return _borusanDbContext.Brands.FirstOrDefault(i => i.Id == id);
        }

        public void Update(Brand brand)
        {
            _borusanDbContext.Brands.Update(brand);
            _borusanDbContext.SaveChanges();
        }
    }
}
