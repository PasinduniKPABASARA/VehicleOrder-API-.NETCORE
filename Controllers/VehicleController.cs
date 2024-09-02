using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleOrderAPI.Data;
using VehicleOrderAPI.Models;



namespace VehicleOrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ApiContext  _context;

            public VehicleController(ApiContext context)

        { 
             _context = context;
        
        }

        //Get
        [HttpGet]
        public JsonResult Get (int id) {
            var vehicleInDb = _context.Vehicles.Find(id);
            if (vehicleInDb == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(vehicleInDb));
        }

        //Create / Edit
        [HttpPost]
        public JsonResult CreateEdit(Vehicle vehicle)
        {
            var vehicleInDb = _context.Vehicles.Find(vehicle.Id);
            if (vehicleInDb == null)
            {
                _context.Vehicles.Add(vehicle);
            }
            vehicleInDb = vehicle;
            _context.SaveChanges();
            return new JsonResult(Ok(vehicle));
        }
        //delete
        [HttpDelete]

        public JsonResult Delete(Vehicle vehicle) { 
        
            var vehicleInDb = _context.Vehicles.Find(vehicle.Id);
            if (vehicleInDb == null)
            {
                return new JsonResult(NotFound());

            }
            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
            return new JsonResult(Ok(NoContent));
        }
    }
}
