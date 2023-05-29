using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleAppFramework
{
    /// <summary>
    /// </summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Get the value of the dry run flag.
        /// </summary>
        /// <param name="serviceProvider">ServiceProvider</param>
        /// <returns>Value of the dry run flag.</returns>
        public static bool GetDryRunFlagsValue(this IServiceProvider serviceProvider)
        {
            return serviceProvider.GetRequiredService<IDryRunFlag>().Value;
        }
    }
}
