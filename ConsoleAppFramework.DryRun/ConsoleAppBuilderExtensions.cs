using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppFramework
{
    /// <summary>
    /// Provides extension methods to use <see cref="IDryRunFlag"/> with <see cref="ConsoleAppBuilder"/>.
    /// </summary>
    public static class ConsoleAppBuilderExtensions
    {
        /// <summary>
        /// Configures the specified <see cref="ConsoleAppBuilder"/> to use the default <see cref="IDryRunFlag"/>.
        /// The default <see cref="IDryRunFlag"/> checks command line arguments and the "DOTNET_DRY_RUN" environment variable to determine the dry run status.
        /// If any of the command line arguments match the "--dry-run", "--dry", or "-d" patterns, or if the "DOTNET_DRY_RUN" environment variable's value is "1" or "true" (ignoring case), the flag is considered true.
        /// </summary>
        /// <param name="builder">The <see cref="ConsoleAppBuilder"/> to configure.</param>
        /// <param name="args">command line arguments</param>
        /// <returns>The configured <see cref="ConsoleAppBuilder"/>.</returns>
        public static ConsoleAppBuilder UseDryRunFlag(this ConsoleAppBuilder builder, string[] args) =>
            builder.UseDryRunFlag(DryRunFlag.Default(args));

        /// <summary>
        /// Configures the specified <see cref="ConsoleAppBuilder"/> to use the provided <see cref="IDryRunFlag"/>.
        /// This method adds the specified <see cref="IDryRunFlag"/> to the service collection and 
        /// registers a new <see cref="DryRunFlagFilter"/> in the global filters of the console application.
        /// </summary>
        /// <param name="builder">The <see cref="ConsoleAppBuilder"/> to configure.</param>
        /// <param name="dryRunFlag">The <see cref="IDryRunFlag"/> to use.</param>
        /// <returns>The configured <see cref="ConsoleAppBuilder"/>.</returns>
        public static ConsoleAppBuilder UseDryRunFlag(this ConsoleAppBuilder builder, IDryRunFlag dryRunFlag)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddSingleton(dryRunFlag);
                var options = services.First(descriptor => descriptor.ImplementationInstance is ConsoleAppOptions).ImplementationInstance as ConsoleAppOptions;
                options!.GlobalFilters = (options.GlobalFilters?.ToImmutableList() ?? ImmutableList<ConsoleAppFilter>.Empty)
                    .Add(new DryRunFlagFilter())
                    .ToArray();
            });

            return builder;
        }
    }
}
