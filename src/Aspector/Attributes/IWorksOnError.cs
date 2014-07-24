using System;
using Castle.DynamicProxy;

namespace Aspector.Attributes
{
    interface IWorksOnError
    {
        void Error(IInvocation invocation, Exception exception);
    }
}