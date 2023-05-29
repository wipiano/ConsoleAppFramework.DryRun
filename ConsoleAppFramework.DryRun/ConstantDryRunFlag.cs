namespace ConsoleAppFramework
{
    /// <summary>
    /// Represents an <see cref="IDryRunFlag"/> with a constant value.
    /// </summary>
    public class ConstantDryRunFlag : IDryRunFlag
    {
        /// <summary>
        /// Gets a <see cref="ConstantDryRunFlag"/> instance that always returns true.
        /// </summary>
        public static ConstantDryRunFlag True { get; } = new ConstantDryRunFlag(true);

        /// <summary>
        /// Gets a <see cref="ConstantDryRunFlag"/> instance that always returns false.
        /// </summary>
        public static ConstantDryRunFlag False { get; } = new ConstantDryRunFlag(false);

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantDryRunFlag"/> class with the specified value.
        /// </summary>
        /// <param name="value">The value of the dry run flag.</param>
        public ConstantDryRunFlag(bool value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the value of the dry run flag.
        /// </summary>
        public bool Value { get; }
    }
}
