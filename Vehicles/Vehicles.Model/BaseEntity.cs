using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Model.Common;

namespace Vehicles.Model
{
	public abstract class BaseEntity : IBaseEntity
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Abbreviation { get; set; }
	}
}
