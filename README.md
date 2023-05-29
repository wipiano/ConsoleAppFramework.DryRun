# ConsoleAppFramework.DryRun

ConsoleAppFramework.DryRun is a library that allows developers to include a "dry run" mode in their applications that uses ConsoleAppFramework. It provides a unified interface for checking whether the application is running in dry run mode based on command line arguments and/or environment variables.

## Features

- Supports command line arguments and environment variables.
- Provides a set of extension methods for conditional service registration based on the dry run flag.
- Includes an interface `IDryRunFlag` that you can implement to add support for custom dry run flag sources.

## How to use

This library provides the `UseDryRunFlag()` method. You can use it in your console application to enable the dry run mode.

For example:

```csharp
var consoleApp = ConsoleApp.CreateBuilder(args)
    .UseDryRunFlag(args)
    ...
    .Build();
```

This method checks if any of the command line arguments match the `--dry-run`, `--dry`, or `-d` patterns, ignoring case. Additionally, it checks if the `DOTNET_DRY_RUN` environment variable's value is `1` or `true`, ignoring case. If either condition is met, the application runs in dry run mode.

You can also use the `AddWithDryRunFlag<TInterface, TImpl, TDryRunImpl>()` and `TryAddWithDryRunFlag<TInterface, TImpl, TDryRunImpl>()` methods to register services that behave differently in dry run mode.

For example:

```csharp
var consoleApp = ConsoleApp.CreateBuilder(args)
    .UseDryRunFlag(args)
    .ConfigureServices(services =>
    {
        services.AddTransientWithDryRunFlag<IMyService, MyService, MyDryRunService>();
    })
    .Build();
```

In this case, `MyService` is used when the dry run flag is `false`, and `MyDryRunService` is used when the dry run flag is `true`.


## Installation

You can install the library via NuGet package manager:

```shell
dotnet add package ConsoleAppFramework.DryRun
```


## Creating a Custom IDryRunFlag

You can implement your own `IDryRunFlag` if you want to check the dry run condition from a different source. The `IDryRunFlag` interface has a single Boolean property, `Value`, that should return `true` if the dry run condition is met.

Here's an example of a custom `IDryRunFlag` that uses a configuration value:

```csharp
public class ConfigDryRunFlag : IDryRunFlag
{
    private readonly IConfiguration _config;

    public ConfigDryRunFlag(IConfiguration config)
    {
        _config = config;
    }

    public bool Value => bool.TryParse(_config["DryRun"], out var result) && result;
}
```

In this example, the `Value` property will return `true` if the "DryRun" configuration value is set to "true".

You can use `UseDryRunFlag()` overload to specify your own `IDryRunFlag` implementation. This allows you to extend or customize the conditions under which the application will enter dry-run mode.

```csharp
var consoleApp = ConsoleApp.CreateBuilder(args)
    .UseDryRunFlag(args, new ConfigDryRunFlag(config))
    .Build()
```


## Combining IDryRunFlag Instances

You can use the static methods `And()`, `Or()`, and `Not()` to combine multiple `IDryRunFlag` instances. These methods are provided in the `DryRunFlagOperators` static class.

Here's an example of how to use these methods:

```csharp
var commandLineFlag = CommandLineDryRunFlag.CreateDefault(args);
var environmentFlag = EnvironmentVariableDryRunFlag.Default;
var configFlag = new ConfigDryRunFlag(config);

var combinedFlag = commandLineFlag.Or(environmentFlag).And(configFlag.Not());

// Now, combinedFlag.Value will be true if either commandLineFlag.Value or environmentFlag.Value is true,
// and configFlag.Value is not true.
```

This can be useful if you want to check the dry run condition from multiple sources and combine them in complex ways.

## License

This library is licensed under the MIT License.