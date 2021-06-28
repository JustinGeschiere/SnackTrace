using GraphQL.Server;
using Microsoft.Extensions.DependencyInjection;

namespace SnackTrace.GraphQL
{
	public static class DependencyInjection
	{
		public static void Register(IServiceCollection services)
		{
			services.AddScoped<Schema>();

			services.AddGraphQL()
				.AddSystemTextJson()
				.AddGraphTypes(typeof(Schema), ServiceLifetime.Scoped);
		}
	}
}
