using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Common;
using Vehicles.Model;

namespace Vehicles.Service.Common
{
	public interface IVehicleModelService
	{
		Task<List<VehicleModel>> GetAllAsync(Sorter sorter, string searchString);
		Task<VehicleModel> GetByIdAsync(object id);
		Task InsertAsync(VehicleModel entity);
		Task UpdateAsync(VehicleModel entity);
		Task DeleteAsync(VehicleModel entity);
	}
}
