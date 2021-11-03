using System;

namespace MultiImplementationBenchark
{
    public class DistinctFactory
    {
        private readonly IServiceProvider _provider;

        public DistinctFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IFileUploader Resolve(string providerName)
        {
            switch (providerName)
            {
                case "aws":
                    return _provider.GetService(typeof(IGenericUploader<AWSUploader>)) as IFileUploader;
                case "azure":
                    return _provider.GetService(typeof(IGenericUploader<AzureUploader>)) as IFileUploader;
                case "ftp":
                    return _provider.GetService(typeof(IGenericUploader<FTPUploader>)) as IFileUploader;
                default:
                    throw new ArgumentException($"No uploader with name {providerName} could be found");
            }
        }
    }
}
