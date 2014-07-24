using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            MethodInfo methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;
            Attribute[] attributes = Attribute.GetCustomAttributes(methodInfo, typeof(BaseAttribute), true);

            if (attributes.Length > default(int))
            {
                foreach (Attribute attribute in attributes)
                {
                    var aspect = attribute as IWorksBefore;
                    if (aspect != null)
                    {
                        var baseAspectAttribute = aspect as BaseAttribute;
                        if (baseAspectAttribute != null)
                        {
                            baseAspectAttribute.SetContext(_componentContext);
                        }
                        aspect.Before(invocation);
                    }
                }
            }
        }

        public void ProcessPostAspects(IInvocation invocation)
        {
            MethodInfo methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;
            Attribute[] attributes = Attribute.GetCustomAttributes(methodInfo, typeof(BaseAttribute), true);

            if (attributes.Length > default(int))
            {
                foreach (Attribute attribute in attributes)
                {
                    var aspect = attribute as IWorksAfter;
                    if (aspect != null)
                    {
                        var baseAspectAttribute = aspect as BaseAttribute;
                        if (baseAspectAttribute != null)
                        {
                            baseAspectAttribute.SetContext(_componentContext);
                        }
                        aspect.After(invocation);
                    }
                }
            }
        }

        public void ProcessExceptionAspect(IInvocation invocation, Exception exception)
        {
            MethodInfo methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;
            Attribute[] attributes = Attribute.GetCustomAttributes(methodInfo, typeof(BaseAttribute), true);
            foreach (Attribute attribute in attributes)
            {
                var aspect = attribute as IWorksOnError;
                if (aspect != null)
                {
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
}