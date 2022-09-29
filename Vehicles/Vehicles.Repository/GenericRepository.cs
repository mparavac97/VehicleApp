using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.DAL;
using Vehicles.Model;
using Vehicles.Model.Common;
using Vehicles.Repository.Common;

namespace Vehicles.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
	{
		private readonly IVehicleContext VehicleContext;
		private IDbSet<T> _entities;

		public GenericRepository(IVehicleContext vehicleContext)
		{
			VehicleContext = vehicleContext;
		}

		private IDbSet<T> Entities
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

		public T GetById(object id) 
		{
			return this.Entities.Find(id);
			
		}

		public void Insert(T entity)
		{
			this.Entities.Add(entity);	
		}

		public void Update(T entity) //dovršiti
		{
			this.Entities.Attach(entity);
			
		}

		public void Delete(T entity)
		{
			this.Entities.Remove(entity);
			this.VehicleContext.SaveChanges();
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
