using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicIoC
{
    public class Container
    {
        private readonly IList<Component> _components = new List<Component>();

        private Type _baseType;
        private Type _concreteType;
        private LifeStyle _lifeStyle;

        public Container Register<T>()
        {
            _baseType = typeof (T);
            return this;
        }

        public void To<T>(LifeStyle lifeStyle = LifeStyle.Transient)
        {
            _lifeStyle = lifeStyle;
            _concreteType = typeof (T);

            RegisterComponent();
        }

        public void ToSelf(LifeStyle lifeStyle = LifeStyle.Transient)
        {
            _lifeStyle = lifeStyle;
            _concreteType = _baseType;

            RegisterComponent();
        }

        private void RegisterComponent()
        {
            _components.Add(new Component(_baseType, _concreteType, _lifeStyle));
        }

        public T Resolve<T>()
        {
            var component = _components.FirstOrDefault(c => c.BaseType == typeof (T));
            return (T) component.CreateInstance();
        }
    }
}