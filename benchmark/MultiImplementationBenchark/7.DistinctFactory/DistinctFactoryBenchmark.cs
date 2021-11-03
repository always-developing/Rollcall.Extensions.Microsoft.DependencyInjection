using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MultiImplementationBenchark
{
    [MemoryDiagnoser]
    public class DistinctFactoryBenchmark
    {
        private readonly IHost host;

        public DistinctFactoryBenchmark()
        {
            host = Host.CreateDefaultBuilder()
             .ConfigureServices((context, services) => services
                .AddScoped<AWSUploader>()
                .AddScoped<AzureUploader>()
                .AddScoped<FTPUploader>()
                .AddTransient<DistinctFactory>()
                .AddTransient<DistinctFactoryHandler>()
                .AddScoped<IGenericUploader<AWSUploader>, GenericUploader<AWSUploader>>()
                .AddScoped<IGenericUploader<AzureUploader>, GenericUploader<AzureUploader>>()
                .AddScoped<IGenericUploader<FTPUploader>, GenericUploader<FTPUploader>>()
             ).Build();
        }

        [Benchmark]
        public void Execute()
        {
            var handler = (DistinctFactoryHandler)host.Services.GetService(typeof(DistinctFactoryHandler));
            handler.Execute();
        }
    }
}
