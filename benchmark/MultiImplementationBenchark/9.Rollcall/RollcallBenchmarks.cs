using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rollcall.Extensions.Microsoft.DependencyInjection;

namespace MultiImplementationBenchark
{
    [MemoryDiagnoser]
    public class RollcallBenchmarks
    {
        private readonly IHost host;
        
        public RollcallBenchmarks()
        {
            host = Host.CreateDefaultBuilder()
             .ConfigureServices((context, services) => services
                .AddTransient<RollcallHandler>()
                .AddNamedService<IFileUploader>(builder => builder
                    .AddTransient("aws", typeof(AWSUploader))
                    .AddTransient("azure", typeof(AzureUploader))
                    .AddTransient("ftp", typeof(FTPUploader))
                )
             ).Build();
        }

        [Benchmark]
        public void Execute()
        {
            var handler = (RollcallHandler)host.Services.GetService(typeof(RollcallHandler));
            handler.Execute();
        }
    }
}
