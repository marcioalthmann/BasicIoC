using System.Collections.Generic;
using System.Linq;

namespace BasicIoC
{
    public class Container
    {
        private readonly IList<Component> _components = new List<Component>();

        public void Register<TBaseType, TConcreteType>()
        {
            _components.Add(new Component(typeof (TBaseType), typeof (TConcreteType)));
        }

        public T Resolve<T>()
        {
            var component = _components.FirstOrDefault(c => c.BaseType == typeof (T));
            return (T) component.CreateInstance();
        }
    }
}