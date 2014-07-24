using Castle.DynamicProxy;

namespace Aspector.Attributes
{
    public interface IWorksBefore
    {
        void Before(IInvocation invocation);
    }
}