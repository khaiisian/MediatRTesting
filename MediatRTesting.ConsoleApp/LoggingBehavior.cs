using MediatR;
using System.Text;

namespace MediatRTesting.ConsoleApp;

public class LoggingBehavior <TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull // <TRequest, TResponse> = works for every request type and every return type, A rule: the request can't be null.
{
    public async Task<TResponse> Handle(
        TRequest request,   // the request coming in
        RequestHandlerDelegate<TResponse> next,     // "the next handler", not run yet
        CancellationToken ct)   // stop signal (ignore for now)
    {
        Console.WriteLine($"Logging: [Before] handling {typeof(TRequest).Name}"); //typeof(TRequest).Name = the request's name

        var response = await next(); // runs current Handler, waits for its answer

        Console.WriteLine($"Logging: [After] finished {typeof(TRequest).Name}");

        return response; // pass the handler's answer back out
    }
}

//[Before]   ← runs first
//  await next()  → Handler runs here
//[After]    ← runs last

