using System;
using Aspector.Interface;
using Castle.DynamicProxy;
using Aspector.Attributes;
using System.Collections.Generic;

namespace Aspector.Processor
{
    public class AspectProcessor : IAspectProcessor
    {
        private readonly ILogger _logger;
        private readonly IInvocationHelper _invocationHelper;

        public AspectProcessor(ILogger logger, IInvocationHelper invocationHelper)
        {
            _logger = logger;
            _invocationHelper = invocationHelper;
        }

        public void ProcessPreAspects(IInvocation invocation)
        {
            var methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;
            if (Attribute.GetCustomAttribute(methodInfo, typeof(DetailedLogAttribute), true) != null)
            {
                ProcessDetailedLogAspect(invocation);
            }
            else if (Attribute.GetCustomAttribute(methodInfo, typeof(CacheAttribute), true) != null)
            {
                ProcessCacheAspect(invocation);
            }
        }

        public void ProcessPostAspects(IInvocation invocation)
        {
            //TODO:
        }

        public void ProcessExceptionAspect(IInvocation invocation, Exception exception)
        {
            var methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;
            Attribute attribute = Attribute.GetCustomAttribute(methodInfo, typeof(WorksOnExceptionAttribute), true);
            if (attribute != null)
            {
                _logger.Error(string.Format("An error occurred while executing {0}", methodInfo.Name), exception);
            }
        }

        private void ProcessDetailedLogAspect(IInvocation invocation)
        {
            Dictionary<string, string> parameters = _invocationHelper.GetParameters(invocation);

            foreach (var parameter in parameters)
            {
                _logger.Info(string.Format("Name :{0}, Value:{1}", parameter.Key, parameter.Value));
            }
        }

        private void ProcessCacheAspect(IInvocation invocation)
        {
            //TODO:
        }
    }
}