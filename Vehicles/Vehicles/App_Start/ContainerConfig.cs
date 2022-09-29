using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Vehicles.DAL;
using Vehicles.Repository;
using Vehicles.Repository.Common;

namespace Vehicles.App_Start
{
	public class ContainerConfig
	{
		public static void RegisterDependencies()
		{
			var builder = new ContainerBuilder();

			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			builder.RegisterType<VehicleContext>().As<IVehicleContext>();

			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
			builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));

			var container = builder.Build();
			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
		}
	}
}