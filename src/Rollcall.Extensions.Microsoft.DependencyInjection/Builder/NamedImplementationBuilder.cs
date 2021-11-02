using Microsoft.Extensions.DependencyInjection;

namespace Rollcall.Extensions.Microsoft.DependencyInjection
{
    /// <summary>
    /// The named implementation builder implementation
    /// </summary>
    /// <typeparam name="TInterface">The interface for whichmultiple implementations are being created</typeparam>
    public class NamedImplementationBuilder<TInterface> : INamedImplementationBuilder<TInterface> where TInterface : class
    {
        /// <summary>
        /// Creates an instance of NamedImplementationBuilder
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="types">The named implementations</param>
        public NamedImplementationBuilder(IServiceCollection services, NamedImplementation<TInterface> types)
        {
            Types = types;
            Services = services;
        }

        /// <inheritdoc/>
        public IServiceCollection Services { get; }

        /// <inheritdoc/>
        public NamedImplementation<TInterface> Types { get; }
    }
}
