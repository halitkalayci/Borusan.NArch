using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pipeline
{
    public class ExampleBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Console.WriteLine("Example Behavior Çalıştı.");

            TResponse response = await next();

            Console.WriteLine("Request çalıştı, example behavior tekrar çalıştı.");

            return response;
        }
    }
}
