using System;
using System.Text.RegularExpressions;

namespace ConsoleAppFramework
{
    /// <summary>
    /// Represents an <see cref="IDryRunFlag"/> determined by matching an environment variable value against a regular expression.
    /// </summary>
    public class EnvironmentVariableDryRunFlag : IDryRunFlag
    {
        private static readonly Regex s_defaultRegex = new Regex(@"^1$|^true$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly string s_defaultEnvironmentVariableName = "DOTNET_DRY_RUN";

        private readonly string _name;
        private readonly Regex _regex;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnvironmentVariableDryRunFlag"/> class with the specified environment variable name and regular expression.
        /// </summary>
        /// <param name="name">The name of the environment variable.</param>
        /// <param name="regex">The regular expression used to determine if the flag should be set.</param>
        public EnvironmentVariableDryRunFlag(string name, Regex regex)
        {
            _name = name;
            _regex = regex;
        }

        /// <summary>
        /// Gets a value indicating whether the flag is set, based on the matching of the environment variable's value against the regular expression.
        /// </summary>
        public bool Value
        {
            get
            {
                var envvar = Environment.GetEnvironmentVariable(_name);
                return envvar != null && _regex.IsMatch(envvar);
            }
        }

        /// <summary>
        /// Gets the default <see cref="EnvironmentVariableDryRunFlag"/>, initialized with the "DOTNET_DRY_RUN" environment variable.
        /// This default flag considers the dry run active if the environment variable's value is "1" or "true" (ignoring case).
        /// </summary>
        public static EnvironmentVariableDryRunFlag Default { get; } = new EnvironmentVariableDryRunFlag(s_defaultEnvironmentVariableName, s_defaultRegex);
    }
}
