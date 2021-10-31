using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rollcall.Sample;
using Microsoft.Extensions.DependencyInjection;

namespace Rollcall.Benchmark
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
