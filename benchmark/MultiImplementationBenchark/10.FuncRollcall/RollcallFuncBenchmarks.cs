using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rollcall.Extensions.Microsoft.DependencyInjection;

namespace MultiImplementationBenchark
{
    [MemoryDiagnoser]
    public class RollcallFuncBenchmarks
    {
        private readonly IHost host;
        
        public RollcallFuncBenchmarks()
        {
            host = Host.CreateDefaultBuilder()
             .ConfigureServices((context, services) => services
                .AddTransient<RollcallFuncHandler>()
                .AddTransient<AWSUploader>()
                .AddTransient<AzureUploader>()
                .AddTransient<FTPUploader>()
                .AddNamedService<IFileUploader>(builder => builder
                    .AddTransient("aws", sp => sp.GetService(typeof(AWSUploader)))
                    .AddTransient("azure", sp => sp.GetService(typeof(AzureUploader)))
                    .AddTransient("ftp", sp => sp.GetService(typeof(FTPUploader)))
                )
             ).Build();
        }

        [Benchmark]
        public void Execute()
        {
            var handler = (RollcallFuncHandler)host.Services.GetService(typeof(RollcallFuncHandler));
            handler.Execute();
        }
    }
}
