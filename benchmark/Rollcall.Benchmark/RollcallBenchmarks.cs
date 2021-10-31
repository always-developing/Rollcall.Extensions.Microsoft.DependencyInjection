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
    public class RollcallBenchmarks
    {
        private readonly IHost host;

        public RollcallBenchmarks()
        {
            host = Host.CreateDefaultBuilder()
             .ConfigureServices((context, services) => services
                .AddTransient<RollcallHandler>()
                .AddScoped<IFileUploader>("aws", typeof(AWSUploader))
                .AddScoped<IFileUploader>("azure", typeof(AzureUploader))
                .AddScoped<IFileUploader>("ftp", typeof(FTPUploader))
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
