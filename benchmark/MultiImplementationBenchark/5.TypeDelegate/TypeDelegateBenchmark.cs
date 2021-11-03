using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace MultiImplementationBenchark
{
    [MemoryDiagnoser]
    public class TypeDelegateBenchmark
    {
        private readonly IHost host;

        public TypeDelegateBenchmark()
        {
            host = Host.CreateDefaultBuilder()
             .ConfigureServices((context, services) => services
               .AddScoped<AWSUploader>()
               .AddScoped<AzureUploader>()
               .AddScoped<FTPUploader>()
               .AddTransient<TypeDelegateHandler>()
               .AddTransient<TypeDelegateResolver>(serviceProvider => providerName =>
               {
                   var type = Assembly.GetAssembly(typeof(FileUploaderTypeFactory)).GetType($"{typeof(FileUploaderTypeFactory).Namespace}.{providerName}Uploader", false, true);
                   if (type == null)
                   {
                       throw new ArgumentException($"No uploader with name {providerName} could be found");
                   }

                   var uploader = serviceProvider.GetService(type);

                   return uploader as IFileUploader;
               })
             ).Build();
        }

        [Benchmark]
        public void Execute()
        {
            var handler = (TypeDelegateHandler)host.Services.GetService(typeof(TypeDelegateHandler));
            handler.Execute();
        }
    }
}
