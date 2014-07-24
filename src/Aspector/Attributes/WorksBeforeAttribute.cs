using System;

namespace Aspector.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class WorksBeforeAttribute : BaseAspectAttribute, IWorksBefore
    {
    }
}