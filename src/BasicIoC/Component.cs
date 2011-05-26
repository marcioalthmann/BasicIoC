using System;

namespace BasicIoC
{
    internal class Component
    {
        public Type BaseType { get; private set; }
        public Type ConcreteType { get; private set; }
        public LifeStyle LifeStyle { get; private set; }

        private object _instance;

        public Component(Type baseType, Type concreteType, LifeStyle lifeStyle)
        {
            BaseType = baseType;
            ConcreteType = concreteType;
            LifeStyle = lifeStyle;
        }

        public object CreateInstance()
        {
            if(LifeStyle == LifeStyle.Singleton)
            {
                if (_instance == null)
                    _instance = Activator.CreateInstance(ConcreteType);

                return _instance;
            }

            return Activator.CreateInstance(ConcreteType);
        }
    }
}