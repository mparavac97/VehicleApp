using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Model;
using Vehicles.Model.Common;

namespace Vehicles.DAL
{
	public class VehicleContext : DbContext, IVehicleContext
	{
		public VehicleContext() : base("VehicleContext")
		{
		}

		public DbSet<VehicleMake> VehicleMakes { get; set; }
		public DbSet<VehicleModel> VehicleModels { get; set; }
		
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

		public new DbSet<T> Set<T>() where T : BaseEntity
		{
			return base.Set<T>();
		}

		public void SetModified<T>(T entity) where T : BaseEntity
		{
			Entry(entity).State = EntityState.Modified;
		}
	}
}
