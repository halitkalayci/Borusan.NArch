using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Repositories;
using AutoMapper;
using Application.Pipeline.Logging;
using Application.Pipeline.Auth;

namespace Application.Features.Brands.Commands.Create
{
    // Unit => Fonksiyonda void ne ise request'de o.
    public class CreateBrandCommand : IRequest<CreatedBrandResponse>, ILoggableRequest, ISecuredRequest
    {
        // Komutun işlevini yerine getirmesi için alması gereken argümanlar.

        public string Name { get; set; }

        public string[] Roles => new string[] { "Admin" };

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
        {
            // Gerekli bağımlılıklar

            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                // İlgili request ile istediğimiz işlemi yapabiliriz.

                // X -> Brand

                // Automapper => Eğer isimler aynı ise maplemeyi otomatize eder.
                //Brand brand = new Brand()
                //{
                //    Name = request.Name,
                //};

                // Loglama kodları.

                Brand brand = _mapper.Map<Brand>(request);

                Brand addedBrand = await _brandRepository.AddAsync(brand);

                CreatedBrandResponse response = _mapper.Map<CreatedBrandResponse>(addedBrand);
                return response;
            }
        }
    }
}
