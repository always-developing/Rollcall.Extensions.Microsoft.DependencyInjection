using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Rollcall.Extensions.Microsoft.DependencyInjection;

namespace Rollcall.Sample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            //await RunIEnumerable(host.Services);
            //await RunFactory(host.Services);
            //await RunDelegate(host.Services);
            //await RunDistinct(host.Services);
            //await RunRollcall(host.Services);
            await RunRollcallFunc(host.Services);

            await host.RunAsync();
        }

        private async static Task RunIEnumerable(IServiceProvider services)
        {
            Console.WriteLine("----- EnumerableHandler -----");
            
            var handler = services.GetService<EnumerableHandler>();
            handler.Execute();
        }

        private async static Task RunFactory(IServiceProvider services)
        {
            Console.WriteLine("----- FactoryHandler -----");

            var handler = services.GetService<FactoryHandler>();
            handler.Execute();
        }

        private async static Task RunDelegate(IServiceProvider services)
        {
            Console.WriteLine("----- DelegateHandler -----");

            var handler = services.GetService<DelegateHandler>();
            handler.Execute();
        }

        private async static Task RunDistinct(IServiceProvider services)
        {
            Console.WriteLine("----- DistinctHandler -----");

            var handler = services.GetService<DistinctHandler>();
            handler.Execute();
        }

        private async static Task RunRollcall(IServiceProvider services)
        {
            Console.WriteLine("----- RollcallHandler -----");

            var handler = services.GetService<RollcallHandler>();
            handler.Execute();
        }

        private async static Task RunRollcallFunc(IServiceProvider services)
        {
            Console.WriteLine("----- RollcallFuncHandler -----");

            var handler = services.GetService<RollcallFuncHandler>();
            handler.Execute();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
              .ConfigureServices((context, services) => services
                // configure handlers
                .AddTransient<EnumerableHandler>()
                .AddTransient<FactoryHandler>()
                .AddTransient<DelegateHandler>()
                .AddTransient<DistinctHandler>()
                .AddTransient<RollcallHandler>()
                .AddTransient<RollcallFuncHandler>()
                // configure any supporting classes
                .AddTransient<FileUploaderFactory>()
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
                // configured the uploaders
                //.AddScoped<IFileUploader>("aws", typeof(AWSUploader))
                //.AddScoped<IFileUploader>("azure", typeof(AzureUploader))
                //.AddScoped<IFileUploader>("ftp", typeof(FTPUploader))
                .AddScoped<IFileUploader>("aws", provider => provider.GetService<AWSUploader>())
                .AddScoped<IFileUploader>("azure", provider => provider.GetService<AzureUploader>())
                .AddScoped<IFileUploader>("ftp", provider => provider.GetService<FTPUploader>())
                .AddScoped<AWSUploader>()
                .AddScoped<AzureUploader>()
                .AddScoped<FTPUploader>()
                .AddScoped<IGenericUploader<AWSUploader>, GenericUploader<AWSUploader>>()
                .AddScoped<IGenericUploader<AzureUploader>, GenericUploader<AzureUploader>>()
                .AddScoped<IGenericUploader<FTPUploader>, GenericUploader<FTPUploader>>()
              );
    }
}




















