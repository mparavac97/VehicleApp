﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Model.Common
{
	public interface IVehicleModel : IBaseEntity
	{
		int MakeID { get; set; }
	}
}
