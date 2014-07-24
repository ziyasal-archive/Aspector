using System;
using Aspector.Interface;
using Autofac;
using Castle.DynamicProxy;

namespace Aspector.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class WorksAfterAttribute : BaseAspectAttribute, IWorksAfter
    {
        private readonly ILogger _logger;
        public WorksAfterAttribute()
        {
            _logger = IoC.Resolve<ILogger>();
        }
        public virtual void After(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;
            _logger.Info(string.Format("Method Executed :{0}", method.Name));
        }
    }
}