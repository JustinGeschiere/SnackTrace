using Microsoft.Extensions.DependencyInjection;
using SnackTrace.Services.Implementations;
using SnackTrace.Services.Interfaces;

namespace SnackTrace.Services
{
	public static class DependencyInjection
	{
		public static void Register(IServiceCollection services)
		{
			services.AddScoped<ISnackService, SnackService>();
			services.AddScoped<IDrinkService, DrinkService>();
			services.AddScoped<IMenuService, MenuService>();
		}
	}
}
