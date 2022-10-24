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

namespace Vehicles.Controllers
{
    public class VehicleMakesController : ApiController
    {
        private IVehicleMakeService VehicleMakeService;

        public VehicleMakesController(IVehicleMakeService vehicleMakeService)
        {
            VehicleMakeService = vehicleMakeService;
        }

        // GET: api/VehicleMakes
        public async Task<List<VehicleMake>> GetVehicleMakesAsync([FromUri]Sorter sorter, [FromUri]string searchString)
        {
            return await VehicleMakeService.GetAllAsync(sorter, searchString);
        }

        // GET: api/VehicleMakes/5
        [ResponseType(typeof(VehicleMake))]
        public async Task<IHttpActionResult> GetVehicleMakeAsync(int id)
        {
            VehicleMake vehicleMake = await VehicleMakeService.GetByIdAsync(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            return Ok(vehicleMake);
        }

        // PUT: api/VehicleMakes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVehicleMakeAsync([FromBody]VehicleMake vehicleMake)
        {
            await VehicleMakeService.UpdateAsync(vehicleMake);
            
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VehicleMakes
        [ResponseType(typeof(VehicleMake))]
        public async Task<IHttpActionResult> PostVehicleMakeAsync([FromBody]VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await VehicleMakeService.InsertAsync(vehicleMake);
            

            return CreatedAtRoute("DefaultApi", new { id = vehicleMake.ID }, vehicleMake);
        }
        
        // DELETE: api/VehicleMakes/5
        [ResponseType(typeof(VehicleMake))]
        public async Task<IHttpActionResult> DeleteVehicleMakeAsync(int id)
        {
            VehicleMake vehicleMake = await VehicleMakeService.GetByIdAsync(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            await VehicleMakeService.DeleteAsync(vehicleMake);

            return Ok(vehicleMake);
        }
    }
}