using System;

namespace Aspector.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class WorksAfterAttribute : BaseAspectAttribute, IWorksAfter
    {
    }
}