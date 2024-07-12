using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Repositories;

namespace Application.Features.Brands.Commands.Create
{
    // Unit => Fonksiyonda void ne ise request'de o.
    public class CreateBrandCommand : IRequest<CreatedBrandResponse>
    {
        // Komutun işlevini yerine getirmesi için alması gereken argümanlar.

        public string Name { get; set; }


        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
        {
            // Gerekli bağımlılıklar

            private readonly IBrandRepository _brandRepository;

            public CreateBrandCommandHandler(IBrandRepository brandRepository)
            {
                _brandRepository = brandRepository;
            }

            public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                // İlgili request ile istediğimiz işlemi yapabiliriz.
                Brand brand = new Brand()
                {
                    Name = request.Name,
                };

                Brand addedBrand = await _brandRepository.AddAsync(brand);

                CreatedBrandResponse response = new()
                {
                    Id = addedBrand.Id,
                    Name = addedBrand.Name
                };
                return response;
            }
        }
    }
}
