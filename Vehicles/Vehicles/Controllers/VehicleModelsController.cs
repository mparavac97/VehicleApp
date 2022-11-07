using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Vehicles.Common;
using Vehicles.Model;
using Vehicles.Service;
using Vehicles.Service.Common;
using AutoMapper;

namespace Vehicles.Controllers
{
	public class VehicleModelsController : ApiController
	{
		private IVehicleModelService VehicleModelService;

		MapperConfiguration domainToRestConfig = new MapperConfiguration(cfg => {
			cfg.CreateMap<BaseEntity, BaseEntityREST>()
				.IncludeAllDerived();
			cfg.CreateMap<VehicleModel, VehicleModelREST>();
		});

		MapperConfiguration restToDomainConfig = new MapperConfiguration(cfg =>	{
			cfg.CreateMap<BaseEntityREST, BaseEntity>()
				.IncludeAllDerived();
			cfg.CreateMap<VehicleModelREST, VehicleModel>();
		});

		public VehicleModelsController(IVehicleModelService vehicleModelService)
		{
			VehicleModelService = vehicleModelService;
		}

		// GET: api/VehicleModels
		[Route("api/VehicleModels/")]
		public async Task<List<VehicleModelREST>> GetVehicleMakesAsync([FromBody]QueryParameters queryParameters)
		{
			var mapper = domainToRestConfig.CreateMapper();
			var vehicleModelList = await VehicleModelService.GetAllAsync(queryParameters.Sorter, queryParameters.Filter, queryParameters.Pager);
			return mapper.Map<List<VehicleModel>, List<VehicleModelREST>>(vehicleModelList);
		}

		// GET: api/VehicleModels/5
		[Route("api/VehicleModels/{id}")]
		[ResponseType(typeof(VehicleModel))]
		public async Task<IHttpActionResult> GetVehicleModelAsync(int id)
		{
			VehicleModel vehicleModel = await VehicleModelService.GetByIdAsync(id);
			if (vehicleModel == null)
			{
				return NotFound();
			}

			var mapper = domainToRestConfig.CreateMapper();
			
			return Ok(mapper.Map<VehicleModel, VehicleModelREST>(vehicleModel));
		}

		// PUT: api/VehicleMakes/5
		[Route("api/VehicleModels/{id}")]
		[ResponseType(typeof(void))]
		public async Task<IHttpActionResult> PutVehicleModelAsync([FromBody]VehicleModel vehicleModel)
		{
			await VehicleModelService.UpdateAsync(vehicleModel);

			return StatusCode(HttpStatusCode.NoContent);

		}

		// POST: api/VehicleModels
		[Route("api/VehicleModels")]
		[ResponseType(typeof(VehicleModel))]
		public async Task<IHttpActionResult> PostVehicleModelAsync([FromBody]VehicleModel vehicleModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await VehicleModelService.InsertAsync(vehicleModel);


			return CreatedAtRoute("DefaultApi", new { id = vehicleModel.ID }, vehicleModel);
		}

		// DELETE: api/VehicleModels/5
		[Route("api/VehicleModels/{id}")]
		[ResponseType(typeof(VehicleModel))]
		public async Task<IHttpActionResult> DeleteVehicleModelAsync(int id)
		{
			VehicleModel vehicleModel = await VehicleModelService.GetByIdAsync(id);
			if (vehicleModel == null)
			{
				return NotFound();
			}

			await VehicleModelService.DeleteAsync(vehicleModel);

			return Ok(vehicleModel);
		}
	}
}