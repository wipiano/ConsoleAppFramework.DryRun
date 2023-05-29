namespace ConsoleAppFramework.Tests
{
    public class EnvironmentVariableDryRunFlagTests
    {

        [InlineData("1", true)]
        [InlineData("true", true)]
        [InlineData("TRUE", true)]
        [InlineData("0", false)]
        [InlineData(null, false)]
        [InlineData("foo", false)]
        [Theory]
        public void EnvironmentVariablesTests(string? envVarValue, bool expected)
        {
            Environment.SetEnvironmentVariable("DOTNET_DRY_RUN", envVarValue);
            EnvironmentVariableDryRunFlag.Default.Value.Should().Be(expected);
            Environment.SetEnvironmentVariable("DOTNET_DRY_RUN", null);
        }
    }
}
