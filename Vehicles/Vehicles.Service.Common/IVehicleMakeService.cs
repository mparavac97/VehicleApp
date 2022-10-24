using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Common;
using Vehicles.Model;

namespace Vehicles.Service.Common
{
	public interface IVehicleMakeService
	{
		Task<List<VehicleMake>> GetAllAsync(Sorter sorter, string searchString);
		Task<VehicleMake> GetByIdAsync(object id);
		Task InsertAsync(VehicleMake entity);
		Task UpdateAsync(VehicleMake entity);
		Task DeleteAsync(VehicleMake entity);
	}
}
