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
            var method = invocation.MethodInvocationTarget ?? invocation.Method;
            _logger.Info(string.Format("BOF :{0}", method.Name));

            _processor.ProcessPreAspects(invocation);

            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                _processor.ProcessExceptionAspect(invocation,exception);
                _logger.Error("An error occured.", exception);
            }

            _processor.ProcessPostAspects(invocation);
            _logger.Info(string.Format("EOF :{0}", method.Name));
        }
    }
}