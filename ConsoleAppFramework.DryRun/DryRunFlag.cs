namespace ConsoleAppFramework
{
    /// <summary>
    /// Provides static methods to create and manipulate instances of <see cref="IDryRunFlag"/>.
    /// </summary>
    public static class DryRunFlag
    {
        /// <summary>
        /// Creates the default <see cref="IDryRunFlag"/> by combining a <see cref="CommandLineDryRunFlag"/> and a <see cref="EnvironmentVariableDryRunFlag"/>.
        /// The <see cref="CommandLineDryRunFlag"/> checks if any of the command line arguments match the "--dry-run", "--dry", or "-d" patterns, ignoring case.
        /// The <see cref="EnvironmentVariableDryRunFlag"/> checks if the "DOTNET_DRY_RUN" environment variable's value is "1" or "true", ignoring case.
        /// The resulting flag is true if either of these conditions is met.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        /// <returns>A new <see cref="IDryRunFlag"/> that represents the logical OR of the command line and environment variable flags.</returns>
        public static IDryRunFlag Default(string[] args) => CommandLineDryRunFlag.CreateDefault(args).Or(EnvironmentVariableDryRunFlag.Default);
    }
}
