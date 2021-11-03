using System;

namespace MultiImplementationBenchark
{
    public class DistinctLookupFactory<T>
    {
        private readonly IServiceProvider _provider;
        private readonly UploaderTypes<T> _uploaderTypes;

        public DistinctLookupFactory(IServiceProvider provider, UploaderTypes<T> uploaderTypes)
        {
            _provider = provider;
            _uploaderTypes = uploaderTypes;
        }

        public IFileUploader Resolve(string providerName)
        {
            var type = _uploaderTypes.Get(providerName);

            return _provider.GetService(type) as IFileUploader;
        }
    }
}
