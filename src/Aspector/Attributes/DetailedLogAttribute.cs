using System;
using System.Reflection;
using Aspector.Helper;
using Autofac;
using Aspector.Interface;
using Castle.DynamicProxy;
using System.Collections.Generic;

namespace Aspector.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DetailedLogAttribute : BaseAttribute, IWorkBefore, IWorkAfter
    {
        private ILogger _logger;
        private IInvocationHelper _invocationHelper;
        private ISerializer _serializer;


        public override void InitializeDependencies()
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
                _logger.Info($"Name :{parameter.Key}, Value:{parameter.Value}");
            }

        }

        public virtual void After(IInvocation invocation)
        {
            MethodInfo methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;
            _logger.Info($"Method : {methodInfo.Name}, Return Value : {_serializer.Serialize(invocation.ReturnValue)}");
        }
    }
}