using System.Collections.Generic;
using Aspector.Attributes;
using Aspector.Interface;
using Aspector.Sample.OrderService.ConsoleClient.OrderServiceReference;
using Autofac.Extras.DynamicProxy2;

namespace Aspector.Sample.OrderService.ConsoleClient
{
    [Intercept(typeof(IAspectHandler))]
    public class OrderServiceManager : WcfClientBase.ServiceClientBase<OrderServiceClient>, IOrderServiceManager
    {
        [DetailedLog]
        public bool CompleteOrder(Order order)
        {
            return PerformServiceOperation(client => client.CompleteOrder(order));
        }

        [DetailedLog]
        public bool CompleteOrders(Dictionary<int, Order> orders)
        {
            return true;
        }
    }
}