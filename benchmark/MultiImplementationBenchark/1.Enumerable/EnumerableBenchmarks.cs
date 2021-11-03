using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MultiImplementationBenchark
{
    [MemoryDiagnoser]
    public class EnumerableBenchmarks
    {
        private readonly IHost host;
        
        public EnumerableBenchmarks()
        {
            host = Host.CreateDefaultBuilder()
             .ConfigureServices((context, services) => services
               .AddTransient<EnumerableHandler>()
               .AddTransient<IFileUploader, AWSUploader>()
               .AddTransient<IFileUploader, AzureUploader>()
               .AddTransient<IFileUploader, FTPUploader>()
             ).Build();
        }

        [Benchmark(Baseline =true)]
        public void Execute()
        {
            var handler = (EnumerableHandler)host.Services.GetService(typeof(EnumerableHandler));
            handler.Execute();
        }
    }
}
