using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace WinformsMVP
{
    public class IoCContainer
    {
        private const BindingFlags BindingFlagsAllInstanceCtors =
            BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
        private readonly IDictionary<Type, RegisteredObject> _registeredObjects = new Dictionary<Type, RegisteredObject>();
        
        public void Register<TType, TConcrete>() where TConcrete : class, TType
        {
            RegisterObject<TType, TConcrete>();
        }

        public TType Resolve<TType>()
        {
            return (TType)ResolveObject(typeof(TType));
        }

        public object Resolve(Type type)
        {
            return ResolveObject(type);
        }

        private void RegisterObject<TType, TConcrete>()
        {
            RegisterObject(typeof (TType), typeof (TConcrete));
        }

        private void RegisterObject(Type type, Type concreteType)
        {
            if (_registeredObjects.ContainsKey(type))
                _registeredObjects.Remove(type);
            var registeredObject = new RegisteredObject(concreteType);
            _registeredObjects.Add(type, registeredObject);
        }

        private object ResolveObject(Type type)
        {
            if (type == GetType())
                return this;

            if (!_registeredObjects.ContainsKey(type))
            {
                if (!type.IsInterface && !type.IsAbstract)
                    RegisterObject(type, type);
                else
                    throw new ArgumentOutOfRangeException(string.Format("The type {0} has not been registered", type.Name));
            }
            return GetInstance(_registeredObjects[type]);
        }

        private object GetInstance(RegisteredObject registeredObject)
        {
            var constructorInfo = registeredObject.ConcreteType.GetConstructors(BindingFlagsAllInstanceCtors).First();
            var parameters = constructorInfo.GetParameters().Select(parameter => ResolveObject(parameter.ParameterType));
            return registeredObject.CreateInstance(constructorInfo, parameters.ToArray());
        }

        private class RegisteredObject
        {
            public RegisteredObject(Type concreteType)
            {
                ConcreteType = concreteType;
            }

            public Type ConcreteType { get; private set; }

            public object CreateInstance(ConstructorInfo ctor, params object[] args)
            {
                var newExp = Expression.New(ctor, args.Select(Expression.Constant));
                var lambda = Expression.Lambda(typeof(Func<object>), newExp);
                var compiled = (Func<object>)lambda.Compile();

                return compiled();
            }
        }
    }
}
