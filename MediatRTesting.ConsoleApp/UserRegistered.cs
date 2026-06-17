using MediatR;

namespace MediatRTesting.ConsoleApp;

public record UserRegistered(string Email) : INotification;

public class SendWelcomeEmail : INotificationHandler<UserRegistered>
{
    public Task Handle(UserRegistered notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[Email] Welcome sent to {notification.Email}");
        return Task.CompletedTask;
    }
}

public class LogRegisteration: INotificationHandler<UserRegistered>
{
    public Task Handle(UserRegistered notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[Audit]: Logged Registeration for {notification.Email}");
        return Task.CompletedTask;
    }
}
