using Microsoft.EntityFrameworkCore;
using SnackTrace.Data;
using SnackTrace.Data.Models;
using SnackTrace.GraphQL.Entities.Order;
using SnackTrace.GraphQL.Entities.Where;
using SnackTrace.Repositories.Interfaces;
using System;
using System.Linq;

namespace SnackTrace.Repositories.Implementations
{
	internal class MenuRepository : BaseRepository, IMenuRepository
	{
		public MenuRepository(DataContext dataContext) : base(dataContext)
		{ }

		public IQueryable<Menu> GetAll()
		{
			return _dataContext.Menus
				.Include(i => i.Snacks)
				.Include(i => i.Drinks);
		}

		public Menu Get(Guid id)
		{
			return GetAll().FirstOrDefault(i => i.Id.Equals(id));
		}

		public void Add(Menu entity)
		{
			_dataContext.Add(entity);
			_dataContext.SaveChanges();
		}

		public void Remove(Guid id)
		{
			var entity = Get(id);

			if (entity == null)
			{
				return;
			}

			_dataContext.Remove(entity);
			_dataContext.SaveChanges();
		}

		public IQueryable<Menu> GetQuery(WhereMenu where)
		{
			var query = GetBaseQuery(where);

			HandleWhere(ref query, where);

			return query;
		}
		public IQueryable<Menu> GetQuery(WhereMenu where, OrderMenu order, int skip, int take)
		{
			var query = GetBaseQuery(where);

			HandleWhere(ref query, where);

			HandleOrder(ref query, order);

			if (skip != default)
			{
				query = query.Skip(skip);
			}

			if (take != default)
			{
				query = query.Take(take);
			}

			return query;
		}


		private IQueryable<Menu> GetBaseQuery(WhereMenu where)
		{
			var query = _dataContext.Menus;

			if (where != null)
			{
				if (where.ContainsSnack != default)
				{
					query.Include(i => i.Snacks);
				}

				if (where.ContainsDrink != default)
				{
					query.Include(i => i.Drinks);
				}
			}

			return query;
		}

		private void HandleWhere(ref IQueryable<Menu> query, WhereMenu where)
		{
			if (where != null)
			{
				if (where.Id != default)
				{
					query = query.Where(i => i.Id.Equals(where.Id));
				}

				if (where.Search != default)
				{
					query = query.Where(i => i.Name.Contains(where.Search));
				}

				if (where.ContainsSnack != default)
				{
					query = query.Where(i => i.Snacks.Any(i => i.Id.Equals(where.ContainsSnack)));
				}

				if (where.ContainsDrink != default)
				{
					query = query.Where(i => i.Drinks.Any(i => i.Id.Equals(where.ContainsDrink)));
				}

				if (where.CreatedAfter != default)
				{
					query = query.Where(i => i.Created.GetValueOrDefault() >= where.CreatedAfter);
				}
			}
		}

		private void HandleOrder(ref IQueryable<Menu> query, OrderMenu order)
		{
			if (order != null)
			{
				bool isAscending = order.Direction.Equals(OrderDirection.Ascending);

				Func<IQueryable<Menu>, IOrderedQueryable<Menu>> operation = order.Option switch
				{
					OrderMenu.Options.Name => (i) => isAscending ? i.OrderBy(i => i.Name) : i.OrderByDescending(i => i.Name),
					OrderMenu.Options.Price => (i) => isAscending ? i.OrderBy(i => i.Price) : i.OrderByDescending(i => i.Price),
					OrderMenu.Options.Created => (i) => isAscending ? i.OrderBy(i => i.Created) : i.OrderByDescending(i => i.Created),
					OrderMenu.Options.Modified => (i) => isAscending ? i.OrderBy(i => i.Modified) : i.OrderByDescending(i => i.Modified),
					_ => throw new InvalidOperationException("Invalid enum type")
				};

				query = operation(query);
			}
		}
	}
}
