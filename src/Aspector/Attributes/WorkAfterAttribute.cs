using System;
using System.Reflection;
using Autofac;
using Aspector.Interface;
using Castle.DynamicProxy;

namespace Aspector.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class WorkAfterAttribute : BaseAttribute, IWorkAfter
    {
        private ILogger _logger;

        public override void InitializeDependencies()
        {
            _logger = IoC.Resolve<ILogger>();
        }

        public virtual void After(IInvocation invocation)
        {
            MethodInfo methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;
            _logger.Info($"Method Executed :{methodInfo.Name}");
        }
    }
}