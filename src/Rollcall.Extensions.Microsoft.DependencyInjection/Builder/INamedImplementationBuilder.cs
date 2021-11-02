using Microsoft.Extensions.DependencyInjection;

namespace Rollcall.Extensions.Microsoft.DependencyInjection
{
    /// <summary>
    /// The builder interface for adding multiple named implementations to the DI container
    /// </summary>
    /// <typeparam name="TInterface"></typeparam>
    public interface INamedImplementationBuilder<TInterface> where TInterface : class
    {
        /// <summary>
        /// The service collection implementation
        /// </summary>
        IServiceCollection Services { get; }

        /// <summary>
        /// The entity to store the names linked to the implementaion
        /// </summary>
        NamedImplementation<TInterface> Types { get; }
    }
}
