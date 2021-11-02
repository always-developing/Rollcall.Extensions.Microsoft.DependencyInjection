using System;

namespace Rollcall.Extensions.Microsoft.DependencyInjection
{
    /// <summary>
    /// Provider/Factory interface to get a named implementation from the DI container
    /// </summary>
    /// <typeparam name="TInterface"></typeparam>
    public class RollcallProvider<TInterface> : IRollcallProvider<TInterface> where TInterface : class
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly NamedImplementation<TInterface> _namedTypes;

        /// <summary>
        /// Create an instance of RollcallProvider
        /// </summary>
        /// <param name="serviceProvider">The service provider implementation</param>
        /// <param name="namedImplementation">The named implementaion dictionary</param>
        public RollcallProvider(IServiceProvider serviceProvider, NamedImplementation<TInterface> namedImplementation)
        {
            _serviceProvider = serviceProvider;
            _namedTypes = namedImplementation;
        }

        /// <inheritdoc/>
        public TInterface GetService(string name)
        {
            // First try see if the implementation has been added to the dictionary
            var implementation = _namedTypes.Get(name);

            if(implementation == null)
            {
                throw new InvalidOperationException($"Unable to resolve dependency of type {typeof(TInterface).FullName} with the name '{name}'");
            }

            // the implementation should really only be a Type or a Func
            if (implementation is Type implementationType)
            {
                return _serviceProvider.GetService(implementationType) as TInterface;
            }

            if(implementation is Func<IServiceProvider, object> implementationFunc)
            {
                return implementationFunc.Invoke(_serviceProvider) as TInterface;
            }

            throw new InvalidOperationException($"Implementation of {typeof(TInterface).FullName} with the name '{name}' not a recognised type");
        }
    }
}
