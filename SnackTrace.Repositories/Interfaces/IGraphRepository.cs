using System;
using System.Collections.Generic;
using System.Linq;

namespace SnackTrace.Repositories.Interfaces
{
	public interface IGraphRepository<Tentity, Twhere, Torder>
	{
		IQueryable<Tentity> GetGraphQuery(Twhere where, Torder order, int skip, int take);

		IQueryable<Tentity> GetLoadQuery(IEnumerable<Guid> ids);
	}
}
