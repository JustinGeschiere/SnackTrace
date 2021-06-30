using GraphQL;

namespace SnackTrace.GraphQL.Resolvers.Contexts
{
	internal abstract class BaseContext<Tentity>
	{
		public delegate Twhere CustomWhere<Twhere>(IResolveFieldContext<Tentity> context, Twhere where);
	}
}
