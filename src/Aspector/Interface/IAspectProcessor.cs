using System;
using Castle.DynamicProxy;

namespace Aspector.Interface
{
    public interface IAspectProcessor
    {
        void ProcessPreAspects(IInvocation invocation);
        void ProcessPostAspects(IInvocation invocation);
        void ProcessExceptionAspect(IInvocation invocation, Exception exception);
    }
}