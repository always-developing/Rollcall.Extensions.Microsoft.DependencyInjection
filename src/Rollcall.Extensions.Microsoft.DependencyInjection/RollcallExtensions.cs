using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Rollcall.Extensions.Microsoft.DependencyInjection
{
    /// <summary>
    /// The extensions to provide support for Rollcall
    /// </summary>
    public static class RollcallExtensions
    {
        /// <summary>
        /// Extension of IServiceCollection which will setup base Rollcall functionality and expose a builder to add named implementations
        /// </summary>
        /// <typeparam name="TInterface">The interface to for which named implementations are being added</typeparam>
        /// <param name="services">The service collection implementation</param>
        /// <param name="builder">The named implementation builder</param>
        /// <returns></returns>
        public static IServiceCollection AddNamedType<TInterface>(this IServiceCollection services, Action<INamedImplementationBuilder<TInterface>> builder) where TInterface : class
        {
            var namedType = new NamedImplementation<TInterface>();
            services.AddSingleton(namedType);
            services.TryAddScoped(typeof(IRollcallProvider<TInterface>), typeof(RollcallProvider<TInterface>));

            builder.Invoke(new NamedImplementationBuilder<TInterface>(services, namedType));

            return services;
        }

        /// <summary>
        /// Add a named transient service of the type specified in serviceType to the specified IServiceCollection
        /// </summary>
        /// <typeparam name="TInterface">The service type interface</typeparam>
        /// <param name="builder">The named implementation builder</param>
        /// <param name="name">The name of the implementation</param>
        /// <param name="serviceType">The type of the service to register and the implementation to use</param>
        /// <returns>The named implementation builder</returns>
        public static INamedImplementationBuilder<TInterface> AddTransient<TInterface>(this INamedImplementationBuilder<TInterface> builder, string name, Type serviceType) where TInterface : class
        {
            builder.Types.Add(name, serviceType);
            builder.Services.AddTransient(serviceType);

            return builder;
        }

        /// <summary>
        /// Add a named transient service of the type specified in serviceType to the specified IServiceCollection
        /// </summary>
        /// <typeparam name="TInterface">The service type interface</typeparam>
        /// <param name="builder">The named implementation builder</param>
        /// <param name="name">The name of the implementation</param>
        /// <param name="implementationFactory"></param>
        /// <returns>The named implementation builder</returns>
        public static INamedImplementationBuilder<TInterface> AddTransient<TInterface>(this INamedImplementationBuilder<TInterface> builder, string name, Func<IServiceProvider, object> implementationFactory) where TInterface : class
        {
            builder.Types.Add(name, implementationFactory);
            builder.Services.AddTransient(implementationFactory);

            return builder;
        }

        /// <summary>
        /// Add a named scoped service of the type specified in serviceType to the specified IServiceCollection
        /// </summary>
        /// <typeparam name="TInterface">The service type interface</typeparam>
        /// <param name="builder">The named implementation builder</param>
        /// <param name="name">The name of the implementation</param>
        /// <param name="serviceType">The type of the service to register and the implementation to use</param>
        /// <returns>The named implementation builder</returns>
        public static INamedImplementationBuilder<TInterface> AddScoped<TInterface>(this INamedImplementationBuilder<TInterface> builder, string name, Type serviceType) where TInterface : class
        {
            builder.Types.Add(name, serviceType);
            builder.Services.AddScoped(serviceType);

            return builder;
        }

        /// <summary>
        /// Add a named scoped service of the type specified in serviceType to the specified IServiceCollection
        /// </summary>
        /// <typeparam name="TInterface">The service type interface</typeparam>
        /// <param name="builder">The named implementation builder</param>
        /// <param name="name">The name of the implementation</param>
        /// <param name="implementationFactory"></param>
        /// <returns>The named implementation builder</returns>
        public static INamedImplementationBuilder<TInterface> AddScoped<TInterface>(this INamedImplementationBuilder<TInterface> builder, string name, Func<IServiceProvider, object> implementationFactory) where TInterface : class
        {
            builder.Types.Add(name, implementationFactory);
            builder.Services.AddScoped(implementationFactory);

            return builder;
        }

        /// <summary>
        /// Add a named singleton service of the type specified in serviceType to the specified IServiceCollection
        /// </summary>
        /// <typeparam name="TInterface">The service type interface</typeparam>
        /// <param name="builder">The named implementation builder</param>
        /// <param name="name">The name of the implementation</param>
        /// <param name="serviceType">The type of the service to register and the implementation to use</param>
        /// <returns>The named implementation builder</returns>
        public static INamedImplementationBuilder<TInterface> AddSingleton<TInterface>(this INamedImplementationBuilder<TInterface> builder, string name, Type serviceType) where TInterface : class
        {
            builder.Types.Add(name, serviceType);
            builder.Services.AddSingleton(serviceType);

            return builder;
        }

        /// <summary>
        /// Add a named singleton service of the type specified in serviceType to the specified IServiceCollection
        /// </summary>
        /// <typeparam name="TInterface">The service type interface</typeparam>
        /// <param name="builder">The named implementation builder</param>
        /// <param name="name">The name of the implementation</param>
        /// <param name="implementationFactory"></param>
        /// <returns>The named implementation builder</returns>
        public static INamedImplementationBuilder<TInterface> AddSingleton<TInterface>(this INamedImplementationBuilder<TInterface> builder, string name, Func<IServiceProvider, object> implementationFactory) where TInterface : class
        {
            builder.Types.Add(name, implementationFactory);
            builder.Services.AddSingleton(implementationFactory);

            return builder;
        }

        /// <summary>
        /// Get a name service implementation from the IServiceProvider implementation
        /// </summary>
        /// <typeparam name="TInterface">The interface implemented by the service</typeparam>
        /// <param name="provider">The IServiceProvider implementation</param>
        /// <param name="name">The name of the service</param>
        /// <returns>The service implementation</returns>
        public static TInterface GetService<TInterface>(this IServiceProvider provider, string name) where TInterface : class
        {
            var rollcallProvider = provider.GetService<IRollcallProvider<TInterface>>();
            return rollcallProvider.GetService(name);
        }

    }
}
