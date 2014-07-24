using System.Collections.Generic;
using Castle.DynamicProxy;

namespace Aspector.Helper
{
    public interface IInvocationHelper
    {
        Dictionary<string, string> GetParameters(IInvocation invocation);
    }
}