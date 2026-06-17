using MediatR;
using MediatRTesting.ConsoleApp;
using Microsoft.Extensions.DependencyInjection;

var service = new ServiceCollection();

service.AddLogging();

service.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

var provider = service.BuildServiceProvider();
var mediator = provider.GetRequiredService<IMediator>();

Console.WriteLine("MediatR is ready.");

var response = await mediator.Send(new Ping("Hello World"));
Console.WriteLine(response);

//await mediator.Publish(new UserRegistered(Email: "test@example.com"));
