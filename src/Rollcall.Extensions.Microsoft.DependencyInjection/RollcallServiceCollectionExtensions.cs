using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Rollcall.Extensions.Microsoft.DependencyInjection
{
    public static class RollcallServiceCollectionExtensions
    {
        // ---------- Scoped methods ----------

        public static IServiceCollection AddScoped<TService>(this IServiceCollection services, string name, Type implementation) where TService : class
        {
            ConfigureRollcallBase(services);
            services.AddSingleton(new NamedType<TService>(name, implementation));
            ConfigureScoped(services, typeof(TService), implementation);

            return services;
        }

        public static IServiceCollection AddScoped(this IServiceCollection services, string name, Type serviceType, Type implementation)
        {
            ConfigureRollcallBase(services);
            services.AddSingleton(MakeGenericNamedType(name, serviceType, implementation));
            ConfigureScoped(services, serviceType, implementation);

            return services;
        }

        public static IServiceCollection AddScoped<TService>(this IServiceCollection services, string name, Func<IServiceProvider, object> implementation) where TService : class
        {
            ConfigureRollcallBase(services);
            services.AddSingleton(new NamedFunc<TService>(name, implementation));
            ConfigureScoped(services, typeof(TService), implementation);

            return services;
        }

        // ---------- Singleton methods ----------

        public static IServiceCollection AddSingleton<TService>(this IServiceCollection services, string name, Type implementation) where TService : class
        {
            ConfigureRollcallBase(services);
            services.AddSingleton(new NamedType<TService>(name, implementation));
            ConfigureSingleton(services, typeof(TService), implementation);

            return services;
        }

        public static IServiceCollection AddSingleton(this IServiceCollection services, string name, Type serviceType, Type implementation)
        {
            ConfigureRollcallBase(services);
            services.AddSingleton(MakeGenericNamedType(name, serviceType, implementation));
            ConfigureSingleton(services, serviceType, implementation);

            return services;
        }

        public static IServiceCollection AddSingleton<TService>(this IServiceCollection services, string name, Func<IServiceProvider, object> implementation) where TService : class
        {
            ConfigureRollcallBase(services);
            services.AddSingleton(new NamedFunc<TService>(name, implementation));
            ConfigureSingleton(services, typeof(TService), implementation);

            return services;
        }

        // ---------- Transient methods ----------

        public static IServiceCollection AddTransient<TService>(this IServiceCollection services, string name, Type implementation) where TService : class
        {
            ConfigureRollcallBase(services);
            services.AddSingleton(new NamedType<TService>(name, implementation));
            ConfigureSingleton(services, typeof(TService), implementation);

            return services;
        }

        public static IServiceCollection AddTransient(this IServiceCollection services, string name, Type serviceType, Type implementation)
        {
            ConfigureRollcallBase(services);
            services.AddSingleton(MakeGenericNamedType(name, serviceType, implementation));
            ConfigureTransient(services, serviceType, implementation);

            return services;
        }

        public static IServiceCollection AddTransient<TService>(this IServiceCollection services, string name, Func<IServiceProvider, object> implementation) where TService : class
        {
            ConfigureRollcallBase(services);
            services.AddSingleton(new NamedFunc<TService>(name, implementation));
            ConfigureTransient(services, typeof(TService), implementation);

            return services;
        }

        // ---------- End methods ----------

        #region Private methods

        private static void ConfigureRollcallBase(IServiceCollection services)
        {
            services.TryAddScoped(typeof(IRollcallProvider), typeof(RollcallProvider));
        }

        private static void ConfigureScoped(IServiceCollection services, Type serviceType, Type implementation)
        {
            // add a scoped instance, as per normal process
            services.AddScoped(serviceType, implementation);
            // add the actual implementation so it can be pulled from DI straight
            services.AddScoped(implementation);
        }

        private static void ConfigureScoped(IServiceCollection services, Type serviceType, Func<IServiceProvider, object> implementation)
        {
            // add a scoped instance, as per normal process
            services.AddScoped(serviceType, implementation);
            // add the actual implementation so it can be pulled from DI straight
            services.AddScoped(implementation);
        }

        private static void ConfigureSingleton(IServiceCollection services, Type serviceType, Type implementation)
        {
            // add a scoped instance, as per normal process
            services.AddSingleton(serviceType, implementation);
            // add the actual implementation so it can be pulled from DI straight
            services.AddSingleton(implementation);
        }

        private static void ConfigureSingleton(IServiceCollection services, Type serviceType, Func<IServiceProvider, object> implementation)
        {
            // add a scoped instance, as per normal process
            services.AddSingleton(serviceType, implementation);
            // add the actual implementation so it can be pulled from DI straight
            services.AddSingleton(implementation);
        }

        private static void ConfigureTransient(IServiceCollection services, Type serviceType, Type implementation)
        {
            // add a scoped instance, as per normal process
            services.AddTransient(serviceType, implementation);
            // add the actual implementation so it can be pulled from DI straight
            services.AddTransient(implementation);
        }

        private static void ConfigureTransient(IServiceCollection services, Type serviceType, Func<IServiceProvider, object> implementation)
        {
            // add a scoped instance, as per normal process
            services.AddTransient(serviceType, implementation);
            // add the actual implementation so it can be pulled from DI straight
            services.AddTransient(implementation);
        }

        private static object MakeGenericNamedType(string name, Type serviceType, Type implementation)
        {
            var genericOptions = typeof(NamedType<>);
            Type[] typeArugments = { serviceType };
            var genericInstance = genericOptions.MakeGenericType(typeArugments);


            return Activator.CreateInstance(genericInstance, name, implementation);
        }

        private static object MakeGenericNamedFunc(string name, Type serviceType, Func<IServiceProvider, object> implementation)
        {
            var genericOptions = typeof(NamedFunc<>);
            Type[] typeArugments = { serviceType };
            var genericInstance = genericOptions.MakeGenericType(typeArugments);


            return Activator.CreateInstance(genericInstance, name, implementation);
        }

        #endregion

    }
}
