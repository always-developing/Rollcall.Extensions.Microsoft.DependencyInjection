using Microsoft.Extensions.DependencyInjection;
using System;

namespace MultiImplementationBenchark
{
    public static class DistinctLookupExtensions
    {
        public static IServiceCollection AddNamedUploader<T>(this IServiceCollection services, Action<UploaderBuilder<T>> builder) where T : class
        {
            var uploaderType = new UploaderTypes<T>();
            services.AddSingleton(uploaderType);
            services.AddTransient(typeof(DistinctLookupFactory<T>));

            builder.Invoke(new UploaderBuilder<T>(services, uploaderType));

            return services;
        }

        public static UploaderBuilder<T> AddTransient<T>(this UploaderBuilder<T> builder, string name, Type implementation) where T : class
        {
            builder.Types.Add(name, implementation);
            builder.Services.AddTransient(implementation);

            return builder;
        }
    }
}
