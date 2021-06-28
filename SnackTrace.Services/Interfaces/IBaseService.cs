using System;
using System.Collections.Generic;

namespace SnackTrace.Services.Interfaces
{
	public interface IBaseService<Tdata, Tgraph, Twhere>
	{
		IEnumerable<Tdata> GetAll();

		Tdata Get(Guid id);

		void Add(Tdata entity);

		void Remove(Guid id);

		IEnumerable<Tgraph> GetGraph(Twhere where);
	}
}
