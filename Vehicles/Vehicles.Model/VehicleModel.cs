using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Model.Common;

namespace Vehicles.Model
{
	public class VehicleModel : BaseEntity, Common.IVehicleModel
	{
		public int MakeID { get; set; } //foregin key

		public virtual IVehicleMake VehicleMake { get; set; } //navigation property
	}
}
