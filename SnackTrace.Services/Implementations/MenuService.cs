using SnackTrace.Repositories.Interfaces;
using SnackTrace.Services.Converters;
using SnackTrace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
			var query = _repository.GetGraphQuery(where, order, skip, take);
			return query.ToGraphEntities();
		}

		public async Task<IEnumerable<GraphQL.Entities.Menu>> GetGraphEntitiesAsync(GraphQL.Entities.Where.WhereMenu where, GraphQL.Entities.Order.OrderMenu order, int skip, int take)
		{
			var query = _repository.GetGraphQuery(where, order, skip, take);
			return await query.ToGraphEntitiesAsync();
		}

		public ILookup<Guid, GraphQL.Entities.Menu> LoadGraphEntities(IEnumerable<Guid> ids)
		{
			var query = _repository.GetLoadQuery(ids);
			return query.ToGraphEntities().ToLookup(i => i.Id);
		}

		public async Task<ILookup<Guid, GraphQL.Entities.Menu>> LoadGraphEntitiesAsync(IEnumerable<Guid> ids)
		{
			var query = _repository.GetLoadQuery(ids);
			var result = await query.ToGraphEntitiesAsync();
			return result.ToLookup(i => i.Id);
		}
	}
}
