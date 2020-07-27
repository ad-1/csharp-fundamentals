using System;
using System.Collections.Generic;
using System.Text;

namespace Reflect
{
    public class Container
    {

        Dictionary<Type, Type> _map = new Dictionary<Type, Type>();

        public ContainerBuilder For<TSource>()
        {
            return For(typeof(TSource));
        }

        public ContainerBuilder For(Type sourceType)
        {
            return new ContainerBuilder(this, sourceType);
        }

        public object Resolve<TSource>()
        {
            return Resolve(typeof(TSource));
        }

        public object Resolve(Type sourceType)
        {
            if (_map.ContainsKey(sourceType))
            {
                var destinationType = _map[sourceType];
                return Activator.CreateInstance(destinationType);
            }
            else
            {
                throw new InvalidOperationException("Could not resolve source type " + sourceType.Name);
            }
        }

        public class ContainerBuilder
        {
            public ContainerBuilder(Container container, Type sourceType)
            {
                _container = container;
                _sourceType = sourceType;
            }

            public ContainerBuilder Use<TDestination>()
            {
                return Use(typeof(TDestination));
            }

            public ContainerBuilder Use(Type destinationType)
            {
                _container._map.Add(_sourceType, destinationType);
                return this;
            }

            Container _container;
            Type _sourceType;

        }

    }
}
