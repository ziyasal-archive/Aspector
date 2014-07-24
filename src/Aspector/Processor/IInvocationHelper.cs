using System.Collections.Generic;
using Castle.DynamicProxy;

namespace Aspector.Processor
{
    public interface IInvocationHelper
    {
        Dictionary<string, string> GetParameters(IInvocation invocation);
    }
}