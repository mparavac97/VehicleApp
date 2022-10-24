using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Vehicles.DAL;
using Vehicles.Model;
using Vehicles.Model.Common;
using Vehicles.Repository;
using Vehicles.Repository.Common;
using Vehicles.Service;
using Vehicles.Service.Common;

namespace Vehicles.App_Start
{
	public class ContainerConfig
	{
		public static void RegisterDependencies()
		{
			var builder = new ContainerBuilder();

			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			
			builder.RegisterType<VehicleMake>().As<IVehicleMake>();
			builder.RegisterType<VehicleModel>().As<IVehicleModel>();

			builder.RegisterType<VehicleContext>().As<IVehicleContext>().InstancePerLifetimeScope();

			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
			builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));

			builder.RegisterType<VehicleMakeService>().As<IVehicleMakeService>();
			builder.RegisterType<VehicleModelService>().As<IVehicleModelService>();

			var container = builder.Build();
			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
		}
	}
}