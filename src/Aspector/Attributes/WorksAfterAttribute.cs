using System;
using Autofac;
using Aspector.Interface;
using Castle.DynamicProxy;

namespace Aspector.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class WorksAfterAttribute : BaseAttribute, IWorksAfter
    {
        private ILogger _logger;

        public override void InitializeDependencies()
        {
            _logger = IoC.Resolve<ILogger>();
        }

        public virtual void After(IInvocation invocation)
        {
            _logger.Info(string.Format("Method Executed :{0}", invocation.Method.Name));
        }
    }
}