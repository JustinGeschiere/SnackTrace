using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackTrace.Services.Interfaces
{
	public interface IGraphService<Tentity,Twhere,Torder> 
	{
		IEnumerable<Tentity> GetGraphEntities(Twhere where, Torder order, int skip, int take);
		Task<IEnumerable<Tentity>> GetGraphEntitiesAsync(Twhere where, Torder order, int skip, int take);

		ILookup<Guid, Tentity> LoadGraphEntities(IEnumerable<Guid> ids);
		Task<ILookup<Guid, Tentity>> LoadGraphEntitiesAsync(IEnumerable<Guid> ids);
	}
}
