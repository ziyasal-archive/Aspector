using System;
using Autofac;

namespace Aspector.Attributes
{
    public class BaseAttribute : Attribute
    {
        public int Order { get; set; }

        protected ILifetimeScope IoC;

        public void SetContext(ILifetimeScope lifetimeScope)
        {
            IoC = lifetimeScope;
            InitializeDependencies();
        }

        public virtual void InitializeDependencies() { }
    }
}