using System;
using System.Linq;
using System.Reflection;
using Aspector.Interface;
using Castle.DynamicProxy;
using Aspector.Attributes;
using System.Collections.Generic;

namespace Aspector.Processor
{
    public class AspectProcessor : IAspectProcessor
    {
        private readonly ISerializer _serializer;
        private readonly ILogger _logger;

        public AspectProcessor(ISerializer serializer, ILogger logger)
        {
            _serializer = serializer;
            _logger = logger;
        }

        private void ProcessCacheAspect(IInvocation invocation)
        {
            //TODO:
        }

        private void ProcessDetailedLogAspect(IInvocation invocation)
        {
            Dictionary<string, string> parameters = GetParameters(invocation);

            foreach (var parameter in parameters)
            {
                _logger.Info(string.Format("Name :{0}, Value:{1}", parameter.Key, parameter.Value));
            }
        }

        public void ProcessAspects(IInvocation invocation)
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

        public Dictionary<string, string> GetParameters(IInvocation invocation)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            MethodInfo method = invocation.Method;

            if (method != null && method.GetParameters().Any())
            {
                for (int index = 0; index < method.GetParameters().Length; index++)
                {
                    ParameterInfo parameter = method.GetParameters()[index];
                    parameters[parameter.Name] = _serializer.Serialize(invocation.Arguments[index]);
                }
            }

            return parameters;
        }
    }
}
