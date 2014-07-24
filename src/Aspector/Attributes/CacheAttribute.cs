using System;

namespace Aspector.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheAttribute :Attribute
    {
        public bool AllowCache { get; set; }
        public string CacheKeyPattern { get; set; }
        public int CacheDuration { get; set; }
    }
}
