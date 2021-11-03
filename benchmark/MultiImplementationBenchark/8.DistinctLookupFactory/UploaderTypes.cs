using System;
using System.Collections.Generic;

namespace MultiImplementationBenchark
{
    public class UploaderTypes<T>
    {
        private readonly Dictionary<string, Type> _dependencyTypes;

        public UploaderTypes() => _dependencyTypes = new Dictionary<string, Type>();

        public Dictionary<string, Type> Get() => _dependencyTypes;

        public Type Get(string key) => _dependencyTypes.ContainsKey(key) ? _dependencyTypes[key] : null;

        public void Add(string key, Type typeName) => _dependencyTypes.Add(key, typeName);
    }
}
