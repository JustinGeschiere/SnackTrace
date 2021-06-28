using System;
using System.Collections.Generic;

namespace SnackTrace.Services.Interfaces
{
	public interface IBaseService<Tentity>
	{
		IEnumerable<Tentity> GetAll();

		Tentity Get(Guid id);

		void Add(Tentity entity);

		void Remove(Guid id);
	}
}
