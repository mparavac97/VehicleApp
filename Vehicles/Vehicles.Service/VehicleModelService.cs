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
	public class VehicleModelService : IVehicleModelService
	{
		private IUnitOfWork UnitOfWork;

		public VehicleModelService(IUnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
		}

		public async Task<List<VehicleModel>> GetAllAsync(Sorter sorter, string searchString)
		{
			return await UnitOfWork.VehicleModelRepository.GetAllAsync(sorter, searchString);
		}

		public async Task<VehicleModel> GetByIdAsync(object id)
		{
			return await UnitOfWork.VehicleModelRepository.GetByIdAsync(id);
		}

		public async Task InsertAsync(VehicleModel entity)
		{
			UnitOfWork.VehicleModelRepository.Insert(entity);
			await UnitOfWork.SaveAsync();
		}

		public async Task UpdateAsync(VehicleModel entity)
		{
			UnitOfWork.VehicleModelRepository.Update(entity);
			await UnitOfWork.SaveAsync();
		}

		public async Task DeleteAsync(VehicleModel entity)
		{
			UnitOfWork.VehicleModelRepository.Delete(entity);
			await UnitOfWork.SaveAsync();
		}
	}
}
