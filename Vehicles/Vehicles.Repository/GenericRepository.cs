using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Common;
using Vehicles.DAL;
using Vehicles.Model;
using Vehicles.Model.Common;
using Vehicles.Repository.Common;
using System.Linq.Dynamic;

namespace Vehicles.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
	{
		protected IVehicleContext VehicleContext;
		protected DbSet<T> _entities;

		public GenericRepository(IVehicleContext vehicleContext)
		{
			VehicleContext = vehicleContext;
		}

		private DbSet<T> Entities
		{
			get
			{
				if (_entities == null)
				{
					_entities = VehicleContext.Set<T>();
				}
				return _entities;
			}
		}

		protected virtual IQueryable<T> ApplyFiltering (Filter filter, IQueryable<T> list)
		{
			IQueryable<T> templist = list;
			if (filter != null)
			{
				if (filter.Name != null || filter.Abbreviation != null)
					templist = templist.Where(s => s.Name.Contains(filter.Name)
										|| s.Abbreviation.Contains(filter.Abbreviation));
			}

			return templist;
		}

		public async Task<List<T>> GetAllAsync(Sorter sorter, Filter filter, Pager pager)
		{
			var list = from v in this.Entities select v;

			list = ApplyFiltering(filter, list);

			if (sorter.SortBy != null && sorter.SortOrder != null)	
			{
				list = list.OrderBy(sorter.SortBy + " " + sorter.SortOrder);
			}

			list = list.Skip((pager.PageNumber - 1) * pager.PageSize).Take(pager.PageSize);

			return await list.ToListAsync();
		}

		public async Task<T> GetByIdAsync(object id) 
		{
			return await this.Entities.FindAsync(id);
		}

		public void Insert(T entity)
		{
			this.Entities.Add(entity);
		}

		public void Update(T entity) 
		{
			this.Entities.Attach(entity);
			VehicleContext.SetModified(entity);
		}

		public void Delete(T entity)
		{
			this.Entities.Remove(entity);
		}

		public virtual IQueryable<T> Table
		{
			get
			{
				return this.Entities;
			}
		}

	}
}
