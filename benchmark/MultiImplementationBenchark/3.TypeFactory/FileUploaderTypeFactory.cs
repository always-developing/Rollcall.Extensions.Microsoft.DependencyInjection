using System;
using System.Reflection;

namespace MultiImplementationBenchark
{
    public class FileUploaderTypeFactory
    {
        private readonly IServiceProvider _provider;

        public FileUploaderTypeFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IFileUploader Resolve(string providerName)
        {
            var type = Assembly.GetAssembly(typeof(FileUploaderTypeFactory)).GetType($"{typeof(FileUploaderTypeFactory).Namespace}.{providerName}Uploader");

            if (type == null)
            {
                throw new ArgumentException($"No uploader with name {providerName} could be found");
            }

            var uploader = _provider.GetService(type);

            return uploader as IFileUploader;
        }
    }
}
