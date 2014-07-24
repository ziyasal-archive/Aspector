using Aspector.Interface;
using Aspector.Attributes;
using System.Collections.Generic;
using Autofac.Extras.DynamicProxy2;
using Aspector.Sample.OrderService.ConsoleClient.OrderServiceReference;

namespace Aspector.Sample.OrderService.ConsoleClient.Business
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