using SnackTrace.Repositories.Interfaces;
using SnackTrace.Services.Converters;
using SnackTrace.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SnackTrace.Services.Implementations
{
	public class MenuService : BaseService<IMenuRepository>, IMenuService
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

		public IEnumerable<GraphQL.Entities.Menu> GetGraph(GraphQL.Entities.Where.WhereMenu where)
		{
			return _repository.GetQuery(where).ToGraphEntities();
		}

		public IEnumerable<GraphQL.Entities.Menu> GetGraph(GraphQL.Entities.Where.WhereMenu where, GraphQL.Entities.Order.OrderMenu order, int first)
		{
			return _repository.GetQuery(where, order, first).ToGraphEntities();
		}
	}
}
