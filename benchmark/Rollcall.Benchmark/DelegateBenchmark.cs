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
    public class DelegateBenchmark
    {
        private readonly IHost host;

        public DelegateBenchmark()
        {
            host = Host.CreateDefaultBuilder()
             .ConfigureServices((context, services) => services
               .AddScoped<AWSUploader>()
               .AddScoped<AzureUploader>()
               .AddScoped<FTPUploader>()
               .AddTransient<DelegateHandler>()
               .AddTransient<DelegateResolver>(serviceProvider => providerName =>
               {
                   switch (providerName)
                   {
                       case "aws":
                           return serviceProvider.GetService<AWSUploader>();
                       case "azure":
                           return serviceProvider.GetService<AzureUploader>();
                       case "ftp":
                           return serviceProvider.GetService<FTPUploader>();
                       default:
                           throw new ArgumentException($"No uploader with name {providerName} could be found");
                   }
               })
             ).Build();
        }

        [Benchmark]
        public void Execute()
        {
            var handler = (DelegateHandler)host.Services.GetService(typeof(DelegateHandler));
            handler.Execute();
        }
    }
}
