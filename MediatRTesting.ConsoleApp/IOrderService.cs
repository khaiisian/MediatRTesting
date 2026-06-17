namespace MediatRTesting.ConsoleApp;

public interface IOrderService
{
    int CreateOrder(string product);
}

public class OrderService : IOrderService
{
    public int CreateOrder(string product)
    {
        Console.WriteLine($"[OrderService] Saving order for {product}");
        return new Random().Next(1000, 9999);
    }
}
