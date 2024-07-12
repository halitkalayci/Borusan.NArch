using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetAll
{
    public class GetAllBrandsQuery : IRequest<List<GetAllBrandItemResponse>>
    {

        public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, List<GetAllBrandItemResponse>>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public GetAllBrandsQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public Task<List<GetAllBrandItemResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
            {
                // TODO: Get All'ı async yap.
                List<Brand> brands = _brandRepository.GetAll();

                List<GetAllBrandItemResponse> response = _mapper.Map<List<GetAllBrandItemResponse>>(brands);
            }
        }
    }
}
