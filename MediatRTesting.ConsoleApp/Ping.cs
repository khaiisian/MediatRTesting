using MediatR;

public record Ping(string Message) : IRequest<string>;
//IRequest<string>; => this is a MediatR request (sendable via mediator.Send).
//< string > means When handled, it returns a string.

public class PingHandler : IRequestHandler<Ping, string> // for Ping request and return string
{
    public Task<string> Handle(Ping message, CancellationToken cancellationToken)
    {
        return Task.FromResult($"The ping message was {message.Message}");
    }
}
