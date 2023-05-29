namespace ConsoleAppFramework.Tests
{
    public class ConstantDryRunFlagsTests
    {
        [Fact]
        public void TrueTest()
        {
            ConstantDryRunFlag.True.Value.Should().BeTrue();
        }

        [Fact]
        public void FalseTest()
        {
            ConstantDryRunFlag.False.Value.Should().BeFalse();
        }
    }
}
