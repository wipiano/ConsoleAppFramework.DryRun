namespace ConsoleAppFramework
{
    /// <summary>
    /// Interface representing a dry run flag. 
    /// </summary>
    public interface IDryRunFlag
    {
        /// <summary>
        /// Gets the value of the dry run flag.
        /// </summary>
        bool Value { get; }
    }
}
