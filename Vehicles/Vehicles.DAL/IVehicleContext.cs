using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Model;
using Vehicles.Model.Common;

namespace Vehicles.DAL
{
	public interface IVehicleContext : IDisposable
	{
		DbSet<VehicleMake> VehicleMakes { get; set; }
		DbSet<VehicleModel> VehicleModels { get; set; }

		DbSet<T> Set<T>() where T : BaseEntity;
		int SaveChanges();
		Task<int> SaveChangesAsync();

		void SetModified<T>(T entity) where T : BaseEntity;
	}
}
