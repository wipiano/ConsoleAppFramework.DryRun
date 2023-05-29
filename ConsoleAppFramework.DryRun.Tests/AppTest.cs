namespace ConsoleAppFramework.Tests
{
    public class AppTest
    {
        [Fact]
        public async Task TestNoDryRun()
        {
            var args = new[] {"--dry-curry", "some"};
            var app = ConsoleApp.CreateBuilder(args)
                .UseDryRunFlag(args)
                .ConfigureServices(services =>
                {
                    services.AddTransientWithDryRunFlag<IRepository, RepositoryImpl, RepositoryDryRunImpl>();
                })
                .Build();

            app.AddRootCommand((IRepository repository) =>
            {
                repository.GetValue().Should().Be("impl");
            });

            await app.RunAsync();
        }

        [Fact]
        public async Task TestDryRun()
        {
            var args = new[] {"--dry-run"};
            var app = ConsoleApp.CreateBuilder(args)
                .UseDryRunFlag(args)
                .ConfigureServices(services =>
                {
                    services.AddTransientWithDryRunFlag<IRepository, RepositoryImpl, RepositoryDryRunImpl>();
                })
                .Build();

            app.AddRootCommand((IRepository repository) =>
            {
                repository.GetValue().Should().Be("dry-run");
            });

            await app.RunAsync();
        }

        public interface IRepository
        {
            string GetValue();
        }

        public class RepositoryImpl : IRepository
        {
            public string GetValue()
            {
                return "impl";
            }
        }

        public class RepositoryDryRunImpl : IRepository
        {
            public string GetValue()
            {
                return "dry-run";
            }
        }
    }
}
