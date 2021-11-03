# Rollcall

Provides support for named service registration through the use of extension methods on the IServiceCollection, and retrieval using a factory. 

:information_source: *This is not true named service registration, but a dynamic factory method which allows for retrieval of implementations by name.*

## Installing Rollcall

You should install Rollcall via NuGet:

## How to use Rollcall
### Configuring the dependency injection container

Use the *AddNamedService* to register the interface, with the various named implementations

```c#
host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) => services
    .AddNamedService<IFileUploader>(builder => builder
        .AddTransient("aws", typeof(AWSUploader))
        .AddTransient("azure", typeof(AzureUploader))
        .AddTransient("ftp", typeof(FTPUploader))
    )
).Build();
```

### Retrieving a named service

__Using IRollcallProvider__

Inject IRollcallProvider into the relevant class, and use the *GetService* method to retrieve the implementation by name.

```c#
public class RollcallHandler
{
    private readonly IRollcallProvider<IFileUploader> _provider;

    public RollcallHandler(IRollcallProvider<IFileUploader> provider)
    {
        _provider = provider;
    }

    public void Execute()
    {
        var providerName = "aws";

        var uploader = _provider.GetService(providerName);
        uploader.UploadFile();
    }
}
```

__Using IServiceProvider__

Use the provided extension method in IServiceProvider.

```c#
public class RollcallHandler
{
    private readonly IServiceProvider _serviceProvider;

    public RollcallHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Execute()
    {
        var providerName = "azure";

        var uploader = _serviceProvider.GetService<IFileUploader>(providerName);
        uploader.UploadFile();
    }
}
```

## Benchmarks
There are a variety of ways to handle multiple implementations of the same interface using the default .NET dependency injection implementation. <br>Depending on the use case and the complexity of your implementations (e.g. the number of dependencies the implementations have) Rollcall might not be the best solution. <br><br>
See this blog post (coming soon) with the various methods of handling multiple implementations, as well as some simple benchmarks.