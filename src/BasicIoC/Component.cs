using System;

namespace BasicIoC
{
    internal class Component
    {
        public Type BaseType { get; private set; }
        public Type ConcreteType { get; private set; }

        public Component(Type baseType, Type concreteType)
        {
            BaseType = baseType;
            ConcreteType = concreteType;
        }

        public object CreateInstance()
        {
            return Activator.CreateInstance(ConcreteType);
        }
    }
}