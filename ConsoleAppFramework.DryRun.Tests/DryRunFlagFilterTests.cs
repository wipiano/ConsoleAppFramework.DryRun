using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleAppFramework.Tests
{
    public class DryRunFlagFilterTests
    {
        [Fact]
        public async Task LogTest1()
        {
            var mockLogger = new Mock<ILogger<ConsoleApp>>();

            var serviceProvider = new ServiceCollection()
                .AddTransient<IDryRunFlag>(_ => ConstantDryRunFlag.True)
                .BuildServiceProvider();

            var context = new ConsoleAppContext(new[] { "test" }, DateTime.Now, new CancellationTokenSource(), mockLogger.Object, typeof(DryRunFlagFilterTests).GetMethod("LogTest1")!, serviceProvider);
            var filter = new DryRunFlagFilter();
            await filter.Invoke(context, _ => ValueTask.CompletedTask);

            mockLogger.Verify(logger => logger.Log<It.IsAnyType>(LogLevel.Information, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), It.IsAny<Func<It.IsAnyType?, Exception?, string>>()), Times.Once);
        }

        [Fact]
        public async Task LogTest2()
        {
            var mockLogger = new Mock<ILogger<ConsoleApp>>();

            var serviceProvider = new ServiceCollection()
                .AddTransient<IDryRunFlag>(_ => ConstantDryRunFlag.False)
                .BuildServiceProvider();

            var context = new ConsoleAppContext(new[] { "test" }, DateTime.Now, new CancellationTokenSource(), mockLogger.Object, typeof(DryRunFlagFilterTests).GetMethod("LogTest1")!, serviceProvider); 
            var filter = new DryRunFlagFilter();
            await filter.Invoke(context, _ => ValueTask.CompletedTask);

            mockLogger.Verify(logger => logger.Log<It.IsAnyType>(LogLevel.Information, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), It.IsAny<Func<It.IsAnyType?, Exception?, string>>()), Times.Never);
        }
    }
}
