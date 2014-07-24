using System;
using Autofac;
using Ploeh.AutoFixture;
using Aspector.Interface;
using Autofac.Extras.DynamicProxy2;
using Aspector.Serialization.ServiceStack;
using Aspector.Sample.OrderService.ConsoleClient.OrderServiceReference;

namespace Aspector.Sample.OrderService.ConsoleClient
{
    public class Program
    {
        public static void Main()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule<AspectorModule>();
            builder.RegisterType<ConsoleLogger>().As<ILogger>().SingleInstance();
            builder.RegisterType<ServiceStackSerializer>().As<ISerializer>().SingleInstance();
            builder.RegisterType<OrderServiceManager>().As<IOrderServiceManager>().SingleInstance().EnableInterfaceInterceptors();

            IContainer container = builder.Build();
            ExecuteSample(container);
            Console.ReadKey();
        }

        private static void ExecuteSample(IContainer container)
        {
            IFixture fixture = new Fixture();
            IOrderServiceManager orderServiceManager = container.Resolve<IOrderServiceManager>();

            Order orderToComplete = fixture.Build<Order>().Without(order => order.ExtensionData).Create();
            bool success = orderServiceManager.CompleteOrder(orderToComplete);
            Console.WriteLine("Operation Result: {0}", success);
        }
    }
}
