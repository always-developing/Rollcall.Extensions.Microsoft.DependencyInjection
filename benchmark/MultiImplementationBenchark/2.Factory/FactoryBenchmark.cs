using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MultiImplementationBenchark
{
    [MemoryDiagnoser]
    public class FactoryBenchmark
    {
        private readonly IHost host;

        public FactoryBenchmark()
        {
            host = Host.CreateDefaultBuilder()
             .ConfigureServices((context, services) => services
               .AddTransient<FactoryHandler>()
               .AddTransient<FileUploaderFactory>()
               .AddTransient<IFileUploader, AWSUploader>()
               .AddTransient<IFileUploader, AzureUploader>()
               .AddTransient<IFileUploader, FTPUploader>()
             ).Build();
        }

        [Benchmark]
        public void Execute()
        {
            var handler = (FactoryHandler)host.Services.GetService(typeof(FactoryHandler));
            handler.Execute();
        }
    }
}
