using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Queries.GetAll;
using Application.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Contexts;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BrandsController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            // Buradaki kontrolü olabildiğince dinamik olacak şekilde, pipeline yapısı ile kodlayıp "Application" katmanına taşımak.

            // Core katmanı implementasyonu, (ARAŞTIRMA) nedir? neden kullanılır?
            // nArch
            // https://github.com/kodlamaio-projects/nArchitecture.core

            var user = _httpContextAccessor.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
                throw new Exception("Giriş yapmadan bu endpointi çalıştıramazsınız.");

            CreatedBrandResponse? response = await _mediator.Send(createBrandCommand);

            return Created("", response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllBrandsQuery getAllBrandsQuery = new();

            var response = await _mediator.Send(getAllBrandsQuery);
            return Ok(response);
        }
    }
}
