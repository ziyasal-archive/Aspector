using System;
using Aspector.Interface;
using Autofac;
using Castle.DynamicProxy;

namespace Aspector.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class WorksBeforeAttribute : BaseAspectAttribute, IWorksBefore
    {
        private readonly ILogger _logger;
        public WorksBeforeAttribute()
        {
            _logger = IoC.Resolve<ILogger>();
        }
        public virtual void Before(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;
            _logger.Info(string.Format("Method Executing :{0}", method.Name));
        }
    }
}