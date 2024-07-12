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

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
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
