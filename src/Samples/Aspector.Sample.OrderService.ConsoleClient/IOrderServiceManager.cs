using System.Collections.Generic;
using Aspector.Sample.OrderService.ConsoleClient.OrderServiceReference;

namespace Aspector.Sample.OrderService.ConsoleClient
{
    public interface IOrderServiceManager
    {
        bool CompleteOrder(Order order);
        bool CompleteOrders(Dictionary<int,Order> orders);
    }
}
