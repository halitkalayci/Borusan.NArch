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
    public class CreateBrandCommand : IRequest<Unit>
    {
        // Komutun işlevini yerine getirmesi için alması gereken argümanlar.

        public string Name { get; set; }


        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Unit>
        {
            // Gerekli bağımlılıklar

            private readonly IBrandRepository _brandRepository;

            public CreateBrandCommandHandler(IBrandRepository brandRepository)
            {
                _brandRepository = brandRepository;
            }

            public async Task<Unit> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                // İlgili request ile istediğimiz işlemi yapabiliriz.
                Brand brand = new Brand()
                {
                    Name = request.Name,
                };

                await _brandRepository.AddAsync(brand);
                return Unit.Value;
            }
        }
    }
}
