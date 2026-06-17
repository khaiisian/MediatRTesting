using MediatR;

namespace MediatRTesting.ConsoleApp;

public record CreateOrder(string Product) : IRequest<int>;

public class CreateOrderHandler: IRequestHandler<CreateOrder, int>
{
    private readonly IOrderService _orderService;

    public CreateOrderHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public Task<int> Handle(CreateOrder request, CancellationToken ct)
    {
        int id = _orderService.CreateOrder(request.Product);
        return Task.FromResult(id);
    }
}
