namespace ConsoleAppFramework.Tests
{
    public class DryRunFlagOperatorsTests
    {
        [Fact]
        public void NotTest()
        {
            ConstantDryRunFlag.True.Not().Value.Should().BeFalse();
            ConstantDryRunFlag.False.Not().Value.Should().BeTrue();
        }

        [Fact]
        public void OrTest()
        {
            ConstantDryRunFlag.True.Or(ConstantDryRunFlag.True).Value.Should().BeTrue();
            ConstantDryRunFlag.True.Or(ConstantDryRunFlag.False).Value.Should().BeTrue();
            ConstantDryRunFlag.False.Or(ConstantDryRunFlag.True).Value.Should().BeTrue();
            ConstantDryRunFlag.False.Or(ConstantDryRunFlag.False).Value.Should().BeFalse();
        }

        [Fact]
        public void AndTest()
        {
            ConstantDryRunFlag.True.And(ConstantDryRunFlag.True).Value.Should().BeTrue();
            ConstantDryRunFlag.True.And(ConstantDryRunFlag.False).Value.Should().BeFalse();
            ConstantDryRunFlag.False.And(ConstantDryRunFlag.True).Value.Should().BeFalse();
            ConstantDryRunFlag.False.And(ConstantDryRunFlag.False).Value.Should().BeFalse();
        }
    }
}
