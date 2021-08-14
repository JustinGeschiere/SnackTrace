using SnackTrace.Repositories.Interfaces;
using SnackTrace.Services.Converters;
using SnackTrace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackTrace.Services.Implementations
{
	internal class DrinkService : BaseService<IDrinkRepository>, IDrinkService
	{
		public DrinkService(IDrinkRepository drinkRepository) : base(drinkRepository)
		{ }

		public IEnumerable<Data.Models.Drink> GetAll()
		{
			return _repository.GetAll();
		}

		public Data.Models.Drink Get(Guid id)
		{
			return _repository.Get(id);
		}

		public void Add(Data.Models.Drink entity)
		{
			_repository.Add(entity);
		}

		public void Remove(Guid id)
		{
			_repository.Remove(id);
		}

		public IEnumerable<GraphQL.Entities.Drink> GetGraphEntities(GraphQL.Entities.Where.WhereDrink where, GraphQL.Entities.Order.OrderDrink order, int skip, int take)
		{
			var query = _repository.GetGraphQuery(where, order, skip, take);
			return query.ToGraphEntities();
		}

		public async Task<IEnumerable<GraphQL.Entities.Drink>> GetGraphEntitiesAsync(GraphQL.Entities.Where.WhereDrink where, GraphQL.Entities.Order.OrderDrink order, int skip, int take)
		{
			var query = _repository.GetGraphQuery(where, order, skip, take);
			return await query.ToGraphEntitiesAsync();
		}

		public ILookup<Guid, GraphQL.Entities.Drink> LoadGraphEntities(IEnumerable<Guid> ids)
		{
			var query = _repository.GetLoadQuery(ids);
			return query.ToGraphEntities().ToLookup(i => i.Id);
		}

		public async Task<ILookup<Guid, GraphQL.Entities.Drink>> LoadGraphEntitiesAsync(IEnumerable<Guid> ids)
		{
			var query = _repository.GetLoadQuery(ids);
			var result = await query.ToGraphEntitiesAsync();
			return result.ToLookup(i => i.Id);
		}
	}
}
