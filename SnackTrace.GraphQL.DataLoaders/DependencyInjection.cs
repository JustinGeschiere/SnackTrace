using Microsoft.Extensions.DependencyInjection;
using SnackTrace.GraphQL.DataLoaders.Implementations;
using SnackTrace.GraphQL.DataLoaders.Interfaces;

namespace SnackTrace.GraphQL.DataLoaders
{
	public static class DependencyInjection
	{
		public static void Register(IServiceCollection services)
		{
			services.AddScoped<ISnackDataLoader, SnackDataLoader>();
			services.AddScoped<IMenuDataLoader, MenuDataLoader>();
		}
	}
}
