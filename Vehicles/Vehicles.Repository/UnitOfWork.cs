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
		private IGenericRepository<VehicleMake> VehicleMakeRepository;
		private IGenericRepository<Model.VehicleModel> VehicleModelRepository;

		public UnitOfWork(IVehicleContext vehicleContext, 
						IGenericRepository<Model.VehicleModel> vehicleModelRepository,
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

		public void Save() //commit
		{
			VehicleContext.SaveChanges();
		}

		public void Dispose()
		{
			VehicleContext.Dispose();
		}
	}
}
