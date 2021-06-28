namespace SnackTrace.Services.Interfaces
{
	public interface ISnackService : IBaseService<Data.Models.Snack>, IGraphService<GraphQL.Entities.Snack, GraphQL.Entities.Where.WhereSnack, GraphQL.Entities.Order.OrderSnack>
	{ }
}
