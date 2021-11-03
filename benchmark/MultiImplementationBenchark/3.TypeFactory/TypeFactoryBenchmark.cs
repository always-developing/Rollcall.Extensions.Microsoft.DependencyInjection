using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MultiImplementationBenchark
{
    [MemoryDiagnoser]
    public class TypeFactoryBenchmark
    {
        private readonly IHost host;

        public TypeFactoryBenchmark()
        {
            host = Host.CreateDefaultBuilder()
             .ConfigureServices((context, services) => services
               .AddTransient<TypeFactoryHandler>()
               .AddTransient<FileUploaderTypeFactory>()
               .AddTransient<AWSUploader>()
               .AddTransient<AzureUploader>()
               .AddTransient<FTPUploader>()
             ).Build();
        }

        [Benchmark]
        public void Execute()
        {
            var handler = (TypeFactoryHandler)host.Services.GetService(typeof(TypeFactoryHandler));
            handler.Execute();
        }
    }
}
