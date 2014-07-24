using System;
using Castle.DynamicProxy;

namespace Aspector.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheAttribute : BaseAttribute, IWorksBefore, IWorksAfter
    {
        public bool AllowCache { get; set; }
        public string CacheKeyPattern { get; set; }
        public int CacheDuration { get; set; }

        public virtual void Before(IInvocation invocation)
        {

        }

        public virtual void After(IInvocation invocation)
        {

        }
    }
}
