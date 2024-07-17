using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pipeline.Auth
{
    public class AuthBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>,ISecuredRequest,new()
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            bool isAuthenticated = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

            if (!isAuthenticated)
                throw new Exception();

            // Authorization...
            if(request.Roles.Any())
            {
                // kullanıcı bu rollerden en az birini karşılıyor mu?
                //TODO: Implement after role impl.
                var user = _httpContextAccessor.HttpContext.User;

            }

            return await next();
        }
    }
}
