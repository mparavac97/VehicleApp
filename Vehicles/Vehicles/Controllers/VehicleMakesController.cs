using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Vehicles.DAL;
using Vehicles.Model;
using Vehicles.Model.Common;

namespace Vehicles.Controllers
{
    public class VehicleMakesController : ApiController
    {
        private IVehicleContext db;

        public VehicleMakesController(IVehicleContext vehicleContext)
        {
            this.db = vehicleContext;
        }

        // GET: api/VehicleMakes
        public IQueryable<IVehicleMake> GetVehicleMakes()
        {
            return db.VehicleMakes;
        }

        // GET: api/VehicleMakes/5
        [ResponseType(typeof(VehicleMake))]
        public IHttpActionResult GetVehicleMake(int id)
        {
            IVehicleMake vehicleMake = db.VehicleMakes.Find(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            return Ok(vehicleMake);
        }

        // PUT: api/VehicleMakes/5
        [ResponseType(typeof(void))]
        /*public IHttpActionResult PutVehicleMake(int id, VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleMake.ID)
            {
                return BadRequest();
            }

            db.Entry(vehicleMake).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleMakeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }*/

        // POST: api/VehicleMakes
        [ResponseType(typeof(VehicleMake))]
        public IHttpActionResult PostVehicleMake(VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleMakes.Add(vehicleMake);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicleMake.ID }, vehicleMake);
        }

        // DELETE: api/VehicleMakes/5
        [ResponseType(typeof(VehicleMake))]
        public IHttpActionResult DeleteVehicleMake(int id)
        {
            IVehicleMake vehicleMake = db.VehicleMakes.Find(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            db.VehicleMakes.Remove(vehicleMake);
            db.SaveChanges();

            return Ok(vehicleMake);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /*private bool VehicleMakeExists(int id)
        {
            return db.VehicleMakes.Count(e => e.ID == id) > 0;
        }*/
    }
}