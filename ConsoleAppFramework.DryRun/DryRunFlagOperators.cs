namespace ConsoleAppFramework
{
    /// <summary>
    /// Provides extension methods to perform logical operations (NOT, OR, AND) on <see cref="IDryRunFlag"/> instances.
    /// </summary>
    public static class DryRunFlagOperators
    {
        /// <summary>
        /// Inverts the value of an IDryRunFlag instance using a logical NOT operation.
        /// </summary>
        /// <param name="flag">The IDryRunFlag to invert.</param>
        /// <returns>
        /// A new IDryRunFlag that represents the logical NOT of the input flag.
        /// </returns>
        public static IDryRunFlag Not(this IDryRunFlag flag)
        {
            return new NotImpl(flag);
        }

        /// <summary>
        /// Combines two IDryRunFlag instances using a logical OR operation.
        /// </summary>
        /// <param name="left">The first IDryRunFlag instance.</param>
        /// <param name="right">The second IDryRunFlag instance.</param>
        /// <returns>
        /// A new IDryRunFlag that represents the logical OR of the input flags.
        /// </returns>
        public static IDryRunFlag Or(this IDryRunFlag left, IDryRunFlag right)
        {
            return new OrImpl(left, right);
        }

        /// <summary>
        /// Combines two IDryRunFlag instances using a logical AND operation.
        /// </summary>
        /// <param name="left">The first IDryRunFlag instance.</param>
        /// <param name="right">The second IDryRunFlag instance.</param>
        /// <returns>
        /// A new IDryRunFlag that represents the logical AND of the input flags.
        /// </returns>
        public static IDryRunFlag And(this IDryRunFlag left, IDryRunFlag right)
        {
            return new AndImpl(left, right);
        }

        private sealed class OrImpl : IDryRunFlag
        {
            private readonly IDryRunFlag _left;
            private readonly IDryRunFlag _right;

            public OrImpl(IDryRunFlag left, IDryRunFlag right)
            {
                _left = left;
                _right = right;
            }

            public bool Value => _left.Value || _right.Value;
        }

        private sealed class AndImpl : IDryRunFlag
        {
            private readonly IDryRunFlag _left;
            private readonly IDryRunFlag _right;

            public AndImpl(IDryRunFlag left, IDryRunFlag right)
            {
                _left = left;
                _right = right;
            }

            public bool Value => _left.Value && _right.Value;
        }

        private sealed class NotImpl : IDryRunFlag
        {
            private readonly IDryRunFlag _flag;

            public NotImpl(IDryRunFlag flag)
            {
                _flag = flag;
            }

            public bool Value => !_flag.Value;
        }
    }
}
