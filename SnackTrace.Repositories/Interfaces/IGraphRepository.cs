using System.Linq;

namespace SnackTrace.Repositories.Interfaces
{
	public interface IGraphRepository<Tentity, Twhere, Torder>
	{
		IQueryable<Tentity> GetQuery(Twhere where, Torder order, int skip, int take);
	}
}
