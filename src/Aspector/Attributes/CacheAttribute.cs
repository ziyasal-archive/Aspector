using System;

namespace Aspector.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheAttribute : BaseAspectAttribute, IWorksBefore, IWorksAfter
    {
        public bool AllowCache { get; set; }
        public string CacheKeyPattern { get; set; }
        public int CacheDuration { get; set; }
    }
}
