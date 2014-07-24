using Castle.DynamicProxy;

namespace Aspector.Interface
{
    public interface IAspectProcessor
    {
        void ProcessAspects(IInvocation invocation);
    }
}