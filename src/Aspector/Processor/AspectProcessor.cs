using System;
using System.Reflection;
using Autofac;
using Aspector.Interface;
using Castle.DynamicProxy;
using Aspector.Attributes;

namespace Aspector.Processor
{
    public class AspectProcessor : IAspectProcessor
    {
        private readonly ILifetimeScope _lifetimeScope;

        public AspectProcessor(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public void ProcessPreAspects(IInvocation invocation)
        {
            MethodInfo methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;
            Attribute[] attributes = Attribute.GetCustomAttributes(methodInfo, typeof(BaseAttribute), true);

            if (attributes.Length > default(int))
            {
                foreach (Attribute attribute in attributes)
                {
                    var aspect = attribute as IWorkBefore;
                    if (aspect != null)
                    {
                        var baseAspectAttribute = aspect as BaseAttribute;
                        baseAspectAttribute?.SetContext(_lifetimeScope);
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
                    var aspect = attribute as IWorkAfter;
                    if (aspect != null)
                    {
                        var baseAspectAttribute = aspect as BaseAttribute;
                        baseAspectAttribute?.SetContext(_lifetimeScope);
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
                var aspect = attribute as IWorkOnError;
                if (aspect != null)
                {
                    var baseAspectAttribute = aspect as BaseAttribute;
                    baseAspectAttribute?.SetContext(_lifetimeScope);
                    aspect.Error(invocation, exception);
                }
            }
        }
    }
}