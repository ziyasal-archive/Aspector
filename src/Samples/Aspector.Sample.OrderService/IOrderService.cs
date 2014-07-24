using System.ServiceModel;

namespace Aspector.Sample.OrderService
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        bool CompleteOrder(Order order);
    }
}
