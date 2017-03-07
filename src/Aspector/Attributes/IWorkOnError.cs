using System;
using Castle.DynamicProxy;

namespace Aspector.Attributes
{
    interface IWorkOnError
    {
        void Error(IInvocation invocation, Exception exception);
    }
}