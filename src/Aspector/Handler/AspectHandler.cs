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
        }
    }
}