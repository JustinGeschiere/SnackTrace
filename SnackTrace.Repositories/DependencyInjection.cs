using Microsoft.Extensions.DependencyInjection;
using SnackTrace.Repositories.Implementations;
using SnackTrace.Repositories.Interfaces;

namespace SnackTrace.Repositories
{
	public static class DependencyInjection
	{
		public static void Register(IServiceCollection services)
		{
			services.AddScoped<ISnackRepository, SnackRepository>();
			services.AddScoped<IDrinkRepository, DrinkRepository>();
			services.AddScoped<IMenuRepository, MenuRepository>();
		}
	}
}
