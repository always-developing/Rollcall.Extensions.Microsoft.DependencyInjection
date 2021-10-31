using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rollcall.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rollcall.Extensions.Microsoft.DependencyInjection;

namespace Rollcall.Benchmark
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
                .AddScoped<AWSUploader>()
                .AddScoped<AzureUploader>()
                .AddScoped<FTPUploader>()
                .AddScoped<IFileUploader>("aws", provider => provider.GetService<AWSUploader>())
                .AddScoped<IFileUploader>("azure", provider => provider.GetService<AzureUploader>())
                .AddScoped<IFileUploader>("ftp", provider => provider.GetService<FTPUploader>())
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
