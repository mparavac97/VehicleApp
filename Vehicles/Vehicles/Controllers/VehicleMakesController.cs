using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Vehicles.Common;
using Vehicles.DAL;
using Vehicles.Model;
using Vehicles.Model.Common;
using Vehicles.Service.Common;
using AutoMapper;

namespace Vehicles.Controllers
{
    public class VehicleMakesController : ApiController
    {
        private IVehicleMakeService VehicleMakeService;

        MapperConfiguration domainToRestConfig = new MapperConfiguration(cfg => {
            cfg.CreateMap<BaseEntity, BaseEntityREST>()
                .IncludeAllDerived();

            cfg.CreateMap<VehicleMake, VehicleMakeREST>();
            });
        
        MapperConfiguration restToDomainConfig = new MapperConfiguration(cfg => {
            cfg.CreateMap<BaseEntityREST, BaseEntity>()
                .IncludeAllDerived();
            cfg.CreateMap<VehicleModelREST, VehicleModel>();
        });

        public VehicleMakesController(IVehicleMakeService vehicleMakeService)
        {
            VehicleMakeService = vehicleMakeService;
        }

        // GET: api/VehicleMakes
        [Route("api/VehicleMakes/")]
        public async Task<List<VehicleMakeREST>> GetVehicleMakesAsync([FromUri]Sorter sorter,
                                                                        [FromUri]Filter filter,
                                                                        [FromUri]Pager pager)
        {
            var mapper = domainToRestConfig.CreateMapper();
            var vehicleMakeList = await VehicleMakeService.GetAllAsync(sorter, filter, pager);
            return mapper.Map<List<VehicleMake>, List<VehicleMakeREST>>(vehicleMakeList);
        }

        // GET: api/VehicleMakes/5
        [Route("api/VehicleMakes/{id}")]
        [ResponseType(typeof(VehicleMakeREST))]
        public async Task<IHttpActionResult> GetVehicleMakeAsync(int id)
        {
            VehicleMake vehicleMake = await VehicleMakeService.GetByIdAsync(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            var mapper = domainToRestConfig.CreateMapper();

            return Ok(mapper.Map<VehicleMake, VehicleMakeREST>(vehicleMake));
        }

        // PUT: api/VehicleMakes/5
        [Route("api/VehicleMakes/{id}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVehicleMakeAsync([FromBody]VehicleMakeREST vehicleMake)
        {
            var mapper = restToDomainConfig.CreateMapper();
            await VehicleMakeService.UpdateAsync(mapper.Map<VehicleMakeREST, VehicleMake>(vehicleMake));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VehicleMakes
        [Route("api/VehicleMakes/", Name = "PostVehicleMake")]
        [ResponseType(typeof(VehicleMake))]
        public async Task<IHttpActionResult> PostVehicleMakeAsync([FromBody]VehicleMakeREST vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mapper = restToDomainConfig.CreateMapper();

            await VehicleMakeService.InsertAsync(mapper.Map<VehicleMakeREST, VehicleMake>(vehicleMake));


            return CreatedAtRoute("PostVehicleMake", new { id = vehicleMake.ID }, vehicleMake);
        }

        // DELETE: api/VehicleMakes/5
        [Route("api/VehicleMakes/{id}")]
        [ResponseType(typeof(VehicleMakeREST))]
        public async Task<IHttpActionResult> DeleteVehicleMakeAsync(int id)
        {
            VehicleMake vehicleMake = await VehicleMakeService.GetByIdAsync(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            await VehicleMakeService.DeleteAsync(vehicleMake);
            var mapper = domainToRestConfig.CreateMapper();

            return Ok(mapper.Map<VehicleMake, VehicleMakeREST>(vehicleMake));
        }
    }
}