using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Model.Common;

namespace Vehicles.Model
{
	public class VehicleMake : BaseEntity, IVehicleMake
	{
		public virtual ICollection<IVehicleModel> VehicleModels { get; set; } //navigation property
	}
}
