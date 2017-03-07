using Castle.DynamicProxy;

namespace Aspector.Attributes
{
    public interface IWorkAfter
    {
        void After(IInvocation invocation);
    }
}
