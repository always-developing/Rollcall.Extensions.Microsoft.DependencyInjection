using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rollcall.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rollcall.Benchmark
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
