using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Model;
using Vehicles.Model.Common;

namespace Vehicles.DAL
{
	public interface IVehicleContext : IDisposable
	{
		DbSet<IVehicleMake> VehicleMakes { get; set; }
		DbSet<Model.Common.IVehicleModel> VehicleModels { get; set; }

		IDbSet<T> Set<T>() where T : BaseEntity;
		int SaveChanges();
	}
}
