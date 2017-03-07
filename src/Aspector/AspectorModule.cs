using Autofac;
using Aspector.Helper;
using Aspector.Interface;
using Aspector.Processor;

namespace Aspector
{
    public class AspectorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AspectHandler>().As<IAspectHandler>().SingleInstance();
            builder.RegisterType<AspectProcessor>().As<IAspectProcessor>().SingleInstance();
            builder.RegisterType<InvocationHelper>().As<IInvocationHelper>().SingleInstance();

            base.Load(builder);
        }
    }
}