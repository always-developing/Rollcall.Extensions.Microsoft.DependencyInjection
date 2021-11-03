using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MultiImplementationBenchark
{
    [MemoryDiagnoser]
    public class DistinctBenchmark
    {
        private readonly IHost host;

        public DistinctBenchmark()
        {
            host = Host.CreateDefaultBuilder()
             .ConfigureServices((context, services) => services
                .AddScoped<AWSUploader>()
                .AddScoped<AzureUploader>()
                .AddScoped<FTPUploader>()
                .AddTransient<DistinctHandler>()
                .AddScoped<IGenericUploader<AWSUploader>, GenericUploader<AWSUploader>>()
                .AddScoped<IGenericUploader<AzureUploader>, GenericUploader<AzureUploader>>()
                .AddScoped<IGenericUploader<FTPUploader>, GenericUploader<FTPUploader>>()
             ).Build();
        }

        [Benchmark]
        public void Execute()
        {
            var handler = (DistinctHandler)host.Services.GetService(typeof(DistinctHandler));
            handler.Execute();
        }
    }
}
