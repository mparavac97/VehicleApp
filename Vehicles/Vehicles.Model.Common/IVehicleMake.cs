using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Model.Common
{
	public interface IVehicleMake : IBaseEntity
	{
		ICollection<IVehicleModel> VehicleModels { get; set; }
	}
}
