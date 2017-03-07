using Castle.DynamicProxy;

namespace Aspector.Attributes
{
    public interface IWorkBefore
    {
        void Before(IInvocation invocation);
    }
}