using System;
using System.Reflection;
using Autofac;
using Aspector.Interface;
using Castle.DynamicProxy;

namespace Aspector.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class WorksBeforeAttribute : BaseAttribute, IWorksBefore
    {
        private ILogger _logger;

        public override void InitializeDependencies()
        {
            _logger = IoC.Resolve<ILogger>();
        }

        public virtual void Before(IInvocation invocation)
        {
            MethodInfo methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;
            _logger.Info(string.Format("Method Executing :{0}", methodInfo.Name));
        }
    }
}