using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ConsoleAppFramework;


/// <summary>
/// Provides extension methods for <see cref="IServiceCollection"/> to register services with a dry run flag.
/// </summary>
public static class ServiceCollectionExtensions
{
		/// <summary>
	/// Adds a <see cref="TInterface"/> service to the <see cref="IServiceCollection"/> with the specified service lifetime.
	/// If the dry run flag is set to true, the <see cref="TDryRunImpl"/> implementation is used.
	/// Otherwise, the <see cref="TImpl"/> implementation is used.
	/// </summary>
	/// <typeparam name="TInterface">The type of the service to add.</typeparam>
	/// <typeparam name="TImpl">The type of the implementation to use when the dry run flag is false.</typeparam>
	/// <typeparam name="TDryRunImpl">The type of the implementation to use when the dry run flag is true.</typeparam>
	/// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
	/// <returns>The same service collection so that multiple calls can be chained.</returns>
	public static IServiceCollection AddTransientWithDryRunFlag<TInterface, TImpl, TDryRunImpl>(this IServiceCollection services) 
		where TInterface : class
		where TImpl : class, TInterface
		where TDryRunImpl : class, TInterface
	{
		return services.AddTransient<TImpl>()
			.AddTransient<TDryRunImpl>()
			.AddTransient<TInterface>(provider => provider.GetDryRunFlagsValue() ? provider.GetRequiredService<TDryRunImpl>() : provider.GetRequiredService<TImpl>());
	}

	/// <summary>
	/// Tries to add a <see cref="TInterface"/> service to the <see cref="IServiceCollection"/> with the specified service lifetime.
	/// If the dry run flag is set to true, the <see cref="TDryRunImpl"/> implementation is used.
	/// Otherwise, the <see cref="TImpl"/> implementation is used.
	/// If a service with the same service type is already present in the service collection, this method doesn't add another one.
	/// </summary>
	/// <typeparam name="TInterface">The type of the service to add.</typeparam>
	/// <typeparam name="TImpl">The type of the implementation to use when the dry run flag is false.</typeparam>
	/// <typeparam name="TDryRunImpl">The type of the implementation to use when the dry run flag is true.</typeparam>
	/// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
	public static void TryAddTransientWithDryRunFlag<TInterface, TImpl, TDryRunImpl>(this IServiceCollection services) 
		where TInterface : class
		where TImpl : class, TInterface
		where TDryRunImpl : class, TInterface
	{
		services.TryAddTransient<TImpl>();
		services.TryAddTransient<TDryRunImpl>();
		services.TryAddTransient<TInterface>(provider => provider.GetDryRunFlagsValue() ? provider.GetRequiredService<TDryRunImpl>() : provider.GetRequiredService<TImpl>());
	}
		/// <summary>
	/// Adds a <see cref="TInterface"/> service to the <see cref="IServiceCollection"/> with the specified service lifetime.
	/// If the dry run flag is set to true, the <see cref="TDryRunImpl"/> implementation is used.
	/// Otherwise, the <see cref="TImpl"/> implementation is used.
	/// </summary>
	/// <typeparam name="TInterface">The type of the service to add.</typeparam>
	/// <typeparam name="TImpl">The type of the implementation to use when the dry run flag is false.</typeparam>
	/// <typeparam name="TDryRunImpl">The type of the implementation to use when the dry run flag is true.</typeparam>
	/// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
	/// <returns>The same service collection so that multiple calls can be chained.</returns>
	public static IServiceCollection AddScopedWithDryRunFlag<TInterface, TImpl, TDryRunImpl>(this IServiceCollection services) 
		where TInterface : class
		where TImpl : class, TInterface
		where TDryRunImpl : class, TInterface
	{
		return services.AddScoped<TImpl>()
			.AddScoped<TDryRunImpl>()
			.AddScoped<TInterface>(provider => provider.GetDryRunFlagsValue() ? provider.GetRequiredService<TDryRunImpl>() : provider.GetRequiredService<TImpl>());
	}

	/// <summary>
	/// Tries to add a <see cref="TInterface"/> service to the <see cref="IServiceCollection"/> with the specified service lifetime.
	/// If the dry run flag is set to true, the <see cref="TDryRunImpl"/> implementation is used.
	/// Otherwise, the <see cref="TImpl"/> implementation is used.
	/// If a service with the same service type is already present in the service collection, this method doesn't add another one.
	/// </summary>
	/// <typeparam name="TInterface">The type of the service to add.</typeparam>
	/// <typeparam name="TImpl">The type of the implementation to use when the dry run flag is false.</typeparam>
	/// <typeparam name="TDryRunImpl">The type of the implementation to use when the dry run flag is true.</typeparam>
	/// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
	public static void TryAddScopedWithDryRunFlag<TInterface, TImpl, TDryRunImpl>(this IServiceCollection services) 
		where TInterface : class
		where TImpl : class, TInterface
		where TDryRunImpl : class, TInterface
	{
		services.TryAddScoped<TImpl>();
		services.TryAddScoped<TDryRunImpl>();
		services.TryAddScoped<TInterface>(provider => provider.GetDryRunFlagsValue() ? provider.GetRequiredService<TDryRunImpl>() : provider.GetRequiredService<TImpl>());
	}
		/// <summary>
	/// Adds a <see cref="TInterface"/> service to the <see cref="IServiceCollection"/> with the specified service lifetime.
	/// If the dry run flag is set to true, the <see cref="TDryRunImpl"/> implementation is used.
	/// Otherwise, the <see cref="TImpl"/> implementation is used.
	/// </summary>
	/// <typeparam name="TInterface">The type of the service to add.</typeparam>
	/// <typeparam name="TImpl">The type of the implementation to use when the dry run flag is false.</typeparam>
	/// <typeparam name="TDryRunImpl">The type of the implementation to use when the dry run flag is true.</typeparam>
	/// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
	/// <returns>The same service collection so that multiple calls can be chained.</returns>
	public static IServiceCollection AddSingletonWithDryRunFlag<TInterface, TImpl, TDryRunImpl>(this IServiceCollection services) 
		where TInterface : class
		where TImpl : class, TInterface
		where TDryRunImpl : class, TInterface
	{
		return services.AddSingleton<TImpl>()
			.AddSingleton<TDryRunImpl>()
			.AddSingleton<TInterface>(provider => provider.GetDryRunFlagsValue() ? provider.GetRequiredService<TDryRunImpl>() : provider.GetRequiredService<TImpl>());
	}

	/// <summary>
	/// Tries to add a <see cref="TInterface"/> service to the <see cref="IServiceCollection"/> with the specified service lifetime.
	/// If the dry run flag is set to true, the <see cref="TDryRunImpl"/> implementation is used.
	/// Otherwise, the <see cref="TImpl"/> implementation is used.
	/// If a service with the same service type is already present in the service collection, this method doesn't add another one.
	/// </summary>
	/// <typeparam name="TInterface">The type of the service to add.</typeparam>
	/// <typeparam name="TImpl">The type of the implementation to use when the dry run flag is false.</typeparam>
	/// <typeparam name="TDryRunImpl">The type of the implementation to use when the dry run flag is true.</typeparam>
	/// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
	public static void TryAddSingletonWithDryRunFlag<TInterface, TImpl, TDryRunImpl>(this IServiceCollection services) 
		where TInterface : class
		where TImpl : class, TInterface
		where TDryRunImpl : class, TInterface
	{
		services.TryAddSingleton<TImpl>();
		services.TryAddSingleton<TDryRunImpl>();
		services.TryAddSingleton<TInterface>(provider => provider.GetDryRunFlagsValue() ? provider.GetRequiredService<TDryRunImpl>() : provider.GetRequiredService<TImpl>());
	}
	}