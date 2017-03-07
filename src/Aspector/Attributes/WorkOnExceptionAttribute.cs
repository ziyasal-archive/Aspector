using System;
using System.Reflection;
using Autofac;
using Aspector.Interface;
using Castle.DynamicProxy;

namespace Aspector.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class WorkOnExceptionAttribute : BaseAttribute, IWorkOnError
    {
        private ILogger _logger;

        public override void InitializeDependencies()
        {
            _logger = IoC.Resolve<ILogger>();
        }

        public virtual void Error(IInvocation invocation, Exception exception)
        {
            MethodInfo methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;
            _logger.Error($"An error occurred while executing {methodInfo.Name}", exception);
        }
    }
}