using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Common
{
	public class QueryParameters
	{
		public Filter Filter { get; set; }
		public Sorter Sorter { get; set; }
		public Pager Pager { get; set; }
	}
}
