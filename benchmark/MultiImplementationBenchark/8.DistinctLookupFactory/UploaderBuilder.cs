using Microsoft.Extensions.DependencyInjection;

namespace MultiImplementationBenchark
{
    public class UploaderBuilder<T> where T : class
    {
        public UploaderBuilder(IServiceCollection services, UploaderTypes<T> types)
        {
            Types = types;
            Services = services;
        }

        public IServiceCollection Services { get; }

        public UploaderTypes<T> Types { get; }
    }
}
