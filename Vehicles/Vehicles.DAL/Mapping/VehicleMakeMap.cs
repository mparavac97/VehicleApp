using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Model;

namespace Vehicles.DAL.Mapping
{
	public class VehicleMakeMap : EntityTypeConfiguration<VehicleMake>
	{
		public VehicleMakeMap()
		{
			HasKey(t => t.ID);

			Property(t => t.Name).IsRequired();
			Property(t => t.Abbreviation).IsRequired();

			ToTable("VehicleMake");
		}
	}
}
