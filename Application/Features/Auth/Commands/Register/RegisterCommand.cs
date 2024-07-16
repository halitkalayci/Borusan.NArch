using Application.Hashing;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
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
            private readonly IUserRepository _userRepository;

            public RegisterCommandHandler(IMapper mapper, IUserRepository userRepository)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                User user = _mapper.Map<User>(request);

                byte[] passwordSalt, passwordHash;

                HashingHelper.CreatePasswordHash(request.Password, out passwordSalt, out passwordHash);
                // Automapper + manual mapping
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                await _userRepository.AddAsync(user);

                RegisterResponse response = new() { Token = "" };

                return response;
            }
        }
    }
}
