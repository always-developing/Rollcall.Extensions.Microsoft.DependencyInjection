using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MultiImplementationBenchark
{
    [MemoryDiagnoser]
    public class DistinctLookupFactoryBenchmark
    {
        private readonly IHost host;

        public DistinctLookupFactoryBenchmark()
        {
            host = Host.CreateDefaultBuilder()
             .ConfigureServices((context, services) => services
                .AddNamedUploader<IFileUploader>(builder => builder
                    .AddTransient("aws", typeof(AWSUploader))
                    .AddTransient("azure", typeof(AzureUploader))
                    .AddTransient("ftp", typeof(FTPUploader))
                 )
                .AddTransient<DistinctLookupFactoryHandler>()
             ).Build();
        }

        [Benchmark]
        public void Execute()
        {
            var handler = (DistinctLookupFactoryHandler)host.Services.GetService(typeof(DistinctLookupFactoryHandler));
            handler.Execute();
        }
    }
}
