namespace ConsoleAppFramework.Tests
{
    public class DefaultDryRunFlagTests
    {
        [InlineData(new[] { "test", "-d", "-o", "gg" }, true)]
        [InlineData(new[] { "test", "--dry", "-o", "gg" }, true)]
        [InlineData(new[] { "test", "--dry-run", "-o", "gg" }, true)]
        [InlineData(new[] { "test", "-o", "gg" }, false)]
        [InlineData(new[] { "test", "--dry-flower", "gg" }, false)]
        [InlineData(new[] { "test", "-dir", "gg" }, false)]
        [Theory]
        public void CommandLineArgsTests(string[] args, bool expected)
        {
            DryRunFlag.Default(args).Value.Should().Be(expected);
        }

        [InlineData("1", true)]
        [InlineData("true", true)]
        [InlineData("TRUE", true)]
        [InlineData("0", false)]
        [InlineData(null, false)]
        [InlineData("foo", false)]
        [Theory]
        public async Task EnvironmentVariablesTests(string? envVarValue, bool expected)
        {
            Environment.SetEnvironmentVariable("DOTNET_DRY_RUN", envVarValue);
            await Task.Delay(10);
            DryRunFlag.Default(Array.Empty<string>()).Value.Should().Be(expected);
            await Task.Delay(10);
            Environment.SetEnvironmentVariable("DOTNET_DRY_RUN", null);
            await Task.Delay(10);
        }
    }
}
