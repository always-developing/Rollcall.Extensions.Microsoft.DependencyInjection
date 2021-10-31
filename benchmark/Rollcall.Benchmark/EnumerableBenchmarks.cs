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

        [Benchmark]
        public void Execute()
        {
            var handler = (EnumerableHandler)host.Services.GetService(typeof(EnumerableHandler));
            handler.Execute();
        }
    }
}
