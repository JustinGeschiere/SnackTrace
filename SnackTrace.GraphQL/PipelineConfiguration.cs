using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;

namespace SnackTrace.GraphQL
{
	public static class PipelineConfiguration
	{
		public static void Register(IApplicationBuilder app)
		{
			app.UseGraphQL<Schema>();
			app.UseGraphQLPlayground(options: new PlaygroundOptions());
		}
	}
}
