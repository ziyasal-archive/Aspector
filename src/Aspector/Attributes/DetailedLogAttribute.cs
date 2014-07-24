using System;
using Aspector.Helper;
using Autofac;
using Aspector.Interface;
using Castle.DynamicProxy;
using System.Collections.Generic;

namespace Aspector.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DetailedLogAttribute : BaseAttribute, IWorksBefore, IWorksAfter
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
                _logger.Info(string.Format("Name :{0}, Value:{1}", parameter.Key, parameter.Value));
            }

        }

        public virtual void After(IInvocation invocation)
        {
            _logger.Info(string.Format("Method : {0}, Return Value : {1}", invocation.Method.Name, _serializer.Serialize(invocation.ReturnValue)));
        }
    }
}