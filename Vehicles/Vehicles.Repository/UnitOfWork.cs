using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.DAL;
using Vehicles.Model;
using Vehicles.Model.Common;
using Vehicles.Repository.Common;

namespace Vehicles.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private IVehicleContext VehicleContext;
		public IGenericRepository<VehicleMake> VehicleMakeRepository { get; set; }
		public IGenericRepository<VehicleModel> VehicleModelRepository { get; set; }

		public UnitOfWork(IVehicleContext vehicleContext, 
						IGenericRepository<VehicleModel> vehicleModelRepository,
						IGenericRepository<VehicleMake> vehicleMakeRepository)
		{
			if (vehicleContext == null || vehicleModelRepository == null || vehicleMakeRepository == null)
			{
				throw new ArgumentException("One of the arguments is null");
			}
			VehicleContext = vehicleContext;
			VehicleModelRepository = vehicleModelRepository;
			VehicleMakeRepository = vehicleMakeRepository;
		}

		public async Task SaveAsync() //commit
		{
			await this.VehicleContext.SaveChangesAsync();
		}

		public void Dispose()
		{
			VehicleContext.Dispose();
		}
	}
}
