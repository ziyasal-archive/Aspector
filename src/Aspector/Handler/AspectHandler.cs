using System;
using Aspector.Interface;
using Castle.DynamicProxy;

namespace Aspector.Handler
{
    public class AspectHandler : IAspectHandler, IInterceptor
    {
        private readonly ILogger _logger;
        private readonly IAspectProcessor _processor;

        public AspectHandler(ILogger logger, IAspectProcessor processor)
        {
            _logger = logger;
            _processor = processor;
        }

        public void Intercept(IInvocation invocation)
        {
            _logger.Info(string.Format("BOF :{0}", invocation.Method.Name));

            _processor.ProcessAspects(invocation);

            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                _logger.Error("An error occured.", exception);
            }

            _logger.Info(string.Format("EOF :{0}", invocation.Method.Name));
        }
    }
}