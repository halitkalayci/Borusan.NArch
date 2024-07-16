using Application.Features.Brands.Commands.Create;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pipeline.Logging
{
    // Cross Cutting Concerns

    // Behavior'ın sadece istediğim requestlerde çalışmasını nasıl sağlarım??
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>, ILoggableRequest, new ()
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response = await next();
            return response;
        }
    }
}
