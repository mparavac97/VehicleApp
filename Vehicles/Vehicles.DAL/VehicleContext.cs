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
		public DbSet<IVehicleMake> VehicleMakes { get; set; }
		public DbSet<Model.Common.IVehicleModel> VehicleModels { get; set; }
		
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
			.Where(type => !String.IsNullOrEmpty(type.Namespace))
			.Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
			type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
			foreach (var type in typesToRegister)
			{
				dynamic configurationInstance = Activator.CreateInstance(type);
				modelBuilder.Configurations.Add(configurationInstance);
			}
			base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

		public new IDbSet<T> Set<T>() where T : BaseEntity
		{
			return base.Set<T>();
		}
	}
}
