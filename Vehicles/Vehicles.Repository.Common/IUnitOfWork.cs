using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Model;

namespace Vehicles.Repository.Common
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<VehicleMake> VehicleMakeRepository { get; set; }
		IGenericRepository<VehicleModel> VehicleModelRepository { get; set; }
		Task SaveAsync();
	}
}
