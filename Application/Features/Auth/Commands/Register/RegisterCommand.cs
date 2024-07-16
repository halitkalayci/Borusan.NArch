using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<RegisterResponse>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
        {
            // Dep.
            private readonly IMapper _mapper;

            public Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
            }
        }
    }
}
