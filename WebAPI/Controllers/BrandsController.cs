using Application.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Contexts;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        // Loose Coupling
        private readonly IBrandRepository _brandRepository;

        public BrandsController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Brand> brands = _brandRepository.GetAll();
            return Ok(brands);
        }
        [HttpPost]
        public IActionResult Add([FromBody] Brand brand)
        {
            Brand? addedBrand = _brandRepository.Add(brand);
            return Created("", addedBrand);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Brand brand)
        {
            _brandRepository.Update(brand);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            Brand? brand = _brandRepository.GetById(id);
            return Ok(brand);
        }
    }
}
