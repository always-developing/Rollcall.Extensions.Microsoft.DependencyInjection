namespace Rollcall.Extensions.Microsoft.DependencyInjection
{
    /// <summary>
    /// Provider/Factory interface to get a named implementation from the DI container
    /// </summary>
    /// <typeparam name="TInterface"></typeparam>
    public interface IRollcallProvider<TInterface> where TInterface : class
    {
        /// <summary>
        /// Get the service from the provider
        /// </summary>
        /// <param name="name">The name of the implementation</param>
        /// <returns>The implementation</returns>
        TInterface GetService(string name);
    }
}
