using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Model;

namespace Vehicles.DAL
{
	class VehicleInitializer : DropCreateDatabaseIfModelChanges<VehicleContext>
	{
		protected override void Seed(VehicleContext context)
		{
			var vehicleMakes = new List<VehicleMake>
			{
				new VehicleMake{ ID=1, Name="Volkswagen", Abbreviation="VW"},
				new VehicleMake{ ID=2, Name="Ford", Abbreviation="FD"},
				new VehicleMake{ ID=3, Name="Peugeot", Abbreviation="PG"},
			};
			vehicleMakes.ForEach(s => context.VehicleMakes.Add(s));
			context.SaveChanges();

			var vehicleModels = new List<VehicleModel>
			{
				new VehicleModel{ID=1, MakeID=1, Name="Golf 5", Abbreviation="G5"},
				new VehicleModel{ID=2, MakeID=1, Name="Polo", Abbreviation="PL"},
				new VehicleModel{ID=3, MakeID=2, Name="Mustang", Abbreviation="MU"},
				new VehicleModel{ID=4, MakeID=2, Name="Focus", Abbreviation="FO"},
				new VehicleModel{ID=5, MakeID=3, Name="307", Abbreviation="P307"}
			};
			vehicleModels.ForEach(s => context.VehicleModels.Add(s));
			context.SaveChanges();

		}
	}
}
