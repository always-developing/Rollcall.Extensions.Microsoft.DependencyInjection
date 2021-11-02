using System.Collections.Generic;

namespace Rollcall.Extensions.Microsoft.DependencyInjection
{
    /// <summary>
    /// Stores the DI implementation agsinst a name
    /// </summary>
    /// <typeparam name="TInterface"></typeparam>
    public class NamedImplementation<TInterface>
    {
        private  readonly Dictionary<string, object> _dependencyImplementations;

        /// <summary>
        /// Created an instance of NamedImplementation
        /// </summary>
        public NamedImplementation() => _dependencyImplementations = new Dictionary<string, object>();

        /// <summary>
        /// Get a list of the depenendcy implementations
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> Get() => _dependencyImplementations;

        /// <summary>
        /// Get a specific item from the dictionarty
        /// </summary>
        /// <param name="key">The key to search for</param>
        /// <returns>The object from the list of named implementations</returns>
        public object Get(string key) => _dependencyImplementations.ContainsKey(key) ? _dependencyImplementations[key] : null;

        /// <summary>
        /// Add an item to the named implementation dictionary
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="typeName">The type or function</param>
        public void Add(string key, object typeName) => _dependencyImplementations.Add(key, typeName);
    }
}
