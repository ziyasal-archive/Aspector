using System;
using Autofac;
using Aspector.Interface;
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
            Attribute[] attributes = Attribute.GetCustomAttributes(invocation.Method, typeof(IWorksBefore), true);
            if (attributes.Length > default(int))
            {
                foreach (Attribute attribute in attributes)
                {
                    var aspect = ((IWorksBefore)attribute);
                    var baseAspectAttribute = aspect as BaseAttribute;
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
            Attribute[] attributes = Attribute.GetCustomAttributes(invocation.Method, typeof(IWorksAfter), true);
            if (attributes.Length > default(int))
            {
                foreach (Attribute attribute in attributes)
                {
                    var aspect = ((IWorksAfter)attribute);
                    var baseAspectAttribute = aspect as BaseAttribute;
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
            Attribute[] attributes = Attribute.GetCustomAttributes(invocation.Method, typeof(IWorksOnError), true);
            foreach (Attribute attribute in attributes)
            {
                var aspect = ((IWorksOnError)attribute);
                var baseAspectAttribute = aspect as BaseAttribute;
                if (baseAspectAttribute != null)
                {
                    baseAspectAttribute.SetContext(_componentContext);
                }
                aspect.Error(invocation, exception);
            }
        }
    }
}