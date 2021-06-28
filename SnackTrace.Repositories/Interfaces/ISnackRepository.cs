using SnackTrace.Data.Models;
using SnackTrace.GraphQL.Entities.Order;
using SnackTrace.GraphQL.Entities.Where;

namespace SnackTrace.Repositories.Interfaces
{
	public interface ISnackRepository : IBaseRepository<Snack>, IGraphRepository<Snack, WhereSnack, OrderSnack>
	{ }
}
