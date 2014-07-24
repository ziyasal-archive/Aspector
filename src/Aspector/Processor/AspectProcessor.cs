using System;
using Aspector.Interface;
using Autofac;
using Castle.DynamicProxy;
using Aspector.Attributes;

namespace Aspector.Processor
{
    public class AspectProcessor : IAspectProcessor
    {
        private readonly IComponentContext _componentContext;

        public AspectProcessor(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public void ProcessPreAspects(IInvocation invocation)
        {
            var methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;
            Attribute[] attributes = Attribute.GetCustomAttributes(methodInfo, typeof(IWorksBefore), true);
            if (attributes.Length > default(int))
            {
                foreach (Attribute attribute in attributes)
                {
                    var aspect = ((IWorksBefore)attribute);
                    var baseAspectAttribute = aspect as BaseAspectAttribute;
                    if (baseAspectAttribute != null)
                    {
                        baseAspectAttribute.SetContext(_componentContext);
                    }
                    aspect.Before(invocation);
                }
            }
        }

        public void ProcessPostAspects(IInvocation invocation)
        {
            var methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;
            Attribute[] attributes = Attribute.GetCustomAttributes(methodInfo, typeof(IWorksAfter), true);
            if (attributes.Length > default(int))
            {
                foreach (Attribute attribute in attributes)
                {
                    var aspect = ((IWorksAfter)attribute);
                    var baseAspectAttribute = aspect as BaseAspectAttribute;
                    if (baseAspectAttribute != null)
                    {
                        baseAspectAttribute.SetContext(_componentContext);
                    }
                    aspect.After(invocation);
                }
            }
        }

        public void ProcessExceptionAspect(IInvocation invocation, Exception exception)
        {
            var methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;
            Attribute[] attributes = Attribute.GetCustomAttributes(methodInfo, typeof(IWorksOnError), true);
            foreach (Attribute attribute in attributes)
            {
                var aspect = ((IWorksOnError)attribute);
                var baseAspectAttribute = aspect as BaseAspectAttribute;
                if (baseAspectAttribute != null)
                {
                    baseAspectAttribute.SetContext(_componentContext);
                }
                aspect.Error(invocation, exception);
            }
        }
    }
}