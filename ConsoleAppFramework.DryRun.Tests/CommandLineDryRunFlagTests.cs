namespace ConsoleAppFramework.Tests
{
    public class CommandLineDryRunFlagTests
    {
        [InlineData(new[] { "test", "-d", "-o", "gg" }, true)]
        [InlineData(new[] { "test", "--dry", "-o", "gg" }, true)]
        [InlineData(new[] { "test", "--dry-run", "-o", "gg" }, true)]
        [InlineData(new[] { "test", "-o", "gg" }, false)]
        [InlineData(new[] { "test", "--dry-flower", "gg" }, false)]
        [InlineData(new[] { "test", "-dir", "gg" }, false)]
        [Theory]
        public void ParseFlagsTest(string[] args, bool expectedValue)
        {
            CommandLineDryRunFlag.CreateDefault(args).Value.Should().Be(expectedValue);
        }
    }
}