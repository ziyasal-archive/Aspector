using Autofac;
using Aspector.Handler;
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
            base.Load(builder);
        }
    }
}