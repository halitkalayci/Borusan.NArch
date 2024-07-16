using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
        {
            private readonly IUserRepository _userRepository;

            public LoginCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                // Login
                // Lambda Expression
                User? user = await _userRepository.GetAsync(i => i.Email == request.Email);
            }
        }
    }
}
