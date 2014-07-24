using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Aspector.Interface;
using Castle.DynamicProxy;

namespace Aspector.Processor
{
    internal class InvocationHelper : IInvocationHelper
    {
        private readonly ISerializer _serializer;

        public InvocationHelper(ISerializer serializer)
        {
            _serializer = serializer;
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