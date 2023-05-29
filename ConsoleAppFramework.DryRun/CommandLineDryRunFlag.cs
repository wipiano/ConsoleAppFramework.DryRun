using System.Text.RegularExpressions;

namespace ConsoleAppFramework
{
    /// <summary>
    /// Represents an <see cref="IDryRunFlag"/> determined by matching command line arguments against a regular expression.
    /// </summary>
    public class CommandLineDryRunFlag : IDryRunFlag
    {
        private static readonly Regex s_defaultRegex = new Regex(@"^--dry-run$|^--dry$|^-d$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private readonly string[] _args;
        private readonly Regex _regex;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineDryRunFlag"/> class with the specified command line arguments and regular expression.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        /// <param name="regex">The regular expression used to determine if the flag should be set.</param>
        public CommandLineDryRunFlag(string[] args, Regex regex)
        {
            _args = args;
            _regex = regex;
        }

        /// <summary>
        /// Gets a value indicating whether the flag is set, based on the matching of the command line arguments against the regular expression.
        /// </summary>
        public bool Value
        {
            get
            {
                foreach (var arg in _args)
                {
                    if (_regex.IsMatch(arg))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Creates a new <see cref="CommandLineDryRunFlag"/> with the default regular expression that matches "--dry-run", "--dry", or "-d", ignoring case.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        /// <returns>A new <see cref="CommandLineDryRunFlag"/> initialized with the given arguments and the default regular expression.</returns>K
        public static CommandLineDryRunFlag CreateDefault(string[] args) => new CommandLineDryRunFlag(args, s_defaultRegex);
    }
}
