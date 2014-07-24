using System;

namespace Aspector.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DetailedLogAttribute : BaseAspectAttribute, IWorksBefore, IWorksAfter
    {
    }
}