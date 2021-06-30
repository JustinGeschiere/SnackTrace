using System.Collections.Generic;

namespace SnackTrace.Services.Interfaces
{
	public interface IGraphService<Tentity,Twhere,Torder> 
	{
		IEnumerable<Tentity> GetGraphEntities(Twhere where, Torder order, int skip, int take);
	}
}
