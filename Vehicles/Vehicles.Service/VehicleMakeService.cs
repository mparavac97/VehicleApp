using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Common;
using Vehicles.Model;
using Vehicles.Repository.Common;
using Vehicles.Service.Common;

namespace Vehicles.Service
{
	public class VehicleMakeService : IVehicleMakeService
	{
		private IUnitOfWork UnitOfWork;

		public VehicleMakeService(IUnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
		}

		public async Task<List<VehicleMake>> GetAllAsync(Sorter sorter, string searchString)
		{
			return await UnitOfWork.VehicleMakeRepository.GetAllAsync(sorter, searchString);
		}
		public Task<VehicleMake> GetByIdAsync(object id)
		{
			return UnitOfWork.VehicleMakeRepository.GetByIdAsync(id);
		}

		public async Task InsertAsync(VehicleMake entity)
		{
			UnitOfWork.VehicleMakeRepository.Insert(entity);
			await UnitOfWork.SaveAsync();
		}

		public async Task UpdateAsync(VehicleMake entity)
		{
			UnitOfWork.VehicleMakeRepository.Update(entity);
			await UnitOfWork.SaveAsync();
		}

		public async Task DeleteAsync(VehicleMake entity)
		{
			UnitOfWork.VehicleMakeRepository.Delete(entity);
			await UnitOfWork.SaveAsync();
		}
	}
}
