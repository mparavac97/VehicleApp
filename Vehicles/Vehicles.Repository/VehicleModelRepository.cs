using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Common;
using Vehicles.DAL;
using Vehicles.Model;
using Vehicles.Repository.Common;

namespace Vehicles.Repository
{
	public class VehicleModelRepository : GenericRepository<VehicleModel>, IVehicleModelRepository
	{
		
		public VehicleModelRepository(IVehicleContext vehicleContext) : base(vehicleContext)
		{

		}

		protected override IQueryable<VehicleModel> ApplyFiltering(Filter filter, IQueryable<VehicleModel> list)
		{
			IQueryable<VehicleModel> templist = list;
			if (filter != null)
			{
				if (filter.MakeID.HasValue)
				{
					templist = templist.Where(s => s.MakeID == filter.MakeID.Value);
				}
			}
			return base.ApplyFiltering(filter, templist);
		}
	}
}
