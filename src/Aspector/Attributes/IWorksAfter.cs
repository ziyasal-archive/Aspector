using Castle.DynamicProxy;

namespace Aspector.Attributes
{
    public interface IWorksAfter
    {
        void After(IInvocation invocation);
    }
}
