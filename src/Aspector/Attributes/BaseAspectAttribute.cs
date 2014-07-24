using System;
using Autofac;

namespace Aspector.Attributes
{
    public class BaseAspectAttribute : Attribute
    {
        public int Order { get; set; }

        protected IComponentContext IoC;

        public void SetContext(IComponentContext componentContext)
        {
            IoC = componentContext;
            InitializeDependencies();
        }

        public virtual void InitializeDependencies() { }
    }
}