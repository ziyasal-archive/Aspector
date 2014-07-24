using System;
using Autofac;
using Aspector.Interface;
using Aspector.Processor;
using Castle.DynamicProxy;
using System.Collections.Generic;

namespace Aspector.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DetailedLogAttribute : BaseAspectAttribute, IWorksBefore, IWorksAfter
    {
        private readonly ILogger _logger;
        private readonly IInvocationHelper _invocationHelper;
        private readonly ISerializer _serializer;

        public DetailedLogAttribute()
        {
            _logger = IoC.Resolve<ILogger>();
            _invocationHelper = IoC.Resolve<IInvocationHelper>();
            _serializer = IoC.Resolve<ISerializer>();
        }

        public virtual void Before(IInvocation invocation)
        {
            Dictionary<string, string> parameters = _invocationHelper.GetParameters(invocation);

            foreach (var parameter in parameters)
            {
                _logger.Info(string.Format("Name :{0}, Value:{1}", parameter.Key, parameter.Value));
            }

        }

        public virtual void After(IInvocation invocation)
        {
            var methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;
            _logger.Info(string.Format("Method : {0}, Return Value : {1}", methodInfo.Name, _serializer.Serialize(invocation.ReturnValue)));
        }
    }
}