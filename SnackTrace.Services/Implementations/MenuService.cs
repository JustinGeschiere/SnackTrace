using SnackTrace.Repositories.Interfaces;
using SnackTrace.Services.Converters;
using SnackTrace.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SnackTrace.Services.Implementations
{
	internal class MenuService : BaseService<IMenuRepository>, IMenuService
	{
		public MenuService(IMenuRepository menuRepository) : base(menuRepository)
		{ }

		public IEnumerable<Data.Models.Menu> GetAll()
		{
			return _repository.GetAll();
		}

		public Data.Models.Menu Get(Guid id)
		{
			return _repository.Get(id);
		}

		public void Add(Data.Models.Menu entity)
		{
			_repository.Add(entity);
		}

		public void Remove(Guid id)
		{
			_repository.Remove(id);
		}

		public IEnumerable<GraphQL.Entities.Menu> GetGraphEntities(GraphQL.Entities.Where.WhereMenu where, GraphQL.Entities.Order.OrderMenu order, int skip, int take)
		{
			return _repository.GetQuery(where, order, skip, take).ToGraphEntities();
		}
	}
}
