using MiCamioncito.Models;
using MiCamioncito.Resources;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace MiCamioncito.Controllers
{
    [ApiController]
    [Route("vehicle")]
    public class VehicleController : ControllerBase
    {

        [HttpGet]
        [Route("lists")]
        public dynamic listsVehicle()
        {
            DataTable tVehicle = database.Listar("Vehicles_Get");

            string json = JsonConvert.SerializeObject(tVehicle);

            return new
            {
                success = true,
                message = "Successfull",
                result = new
                {
                    vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(json)
                }
            };
        }


        [HttpGet]
        [Route("list")]
        public dynamic listVehicle(int id)
        {
            List<Parameter> parameters = new List<Parameter>
            {
                new Parameter("@idVehicle", id.ToString())
            };

            DataTable tVehicle = database.Listar("Vehicle_Get_Id", parameters);
            string json = JsonConvert.SerializeObject(tVehicle);

            return new
            {
                success = true,
                message = "Successfull",
                result = new
                {
                    vehicle = JsonConvert.DeserializeObject<List<Vehicle>>(json)
                }
            };
        }





        [HttpPost]
        [Route("create")]
        public dynamic createVehicle(Vehicle vehicle)
        {
            
            List<Parameter> parameters = new List<Parameter>
            {
                new Parameter("@CapacityCubicMeters", vehicle.CapacityCubicMeters.ToString()),
                new Parameter("@FuelConsumptionPerKm", vehicle.FuelConsumptionPerKm.ToString()),
                new Parameter("@AvailableDistanceKm", vehicle.AvailableDistanceKm.ToString()),
                new Parameter("@AvailabilityStartDate", vehicle.AvailabilityStartDate),
                new Parameter("@AvailabilityEndDate", vehicle.AvailabilityEndDate),
                new Parameter("@DepreciationCostPerKm", vehicle.DepreciationCostPerKm.ToString()),
                new Parameter("@CargoType", vehicle.CargoType)
            };

            dynamic result = database.Ejecutar("Vehicle_Insert", parameters);
            return new
            {
                success = result.succes,
                message = result.message + ": Vehicle created",
                result = ""
            };
        }


        [HttpPost]
        [Route("update")]
        public dynamic updateVehicle(Vehicle vehicle)
        {
            List<Parameter> parameters = new List<Parameter>
            {
                new Parameter("@idVehicle", vehicle.IDVehicle.ToString()),
                new Parameter("@CapacityCubicMeters", vehicle.CapacityCubicMeters.ToString()),
                new Parameter("@FuelConsumptionPerKm", vehicle.FuelConsumptionPerKm.ToString()),
                new Parameter("@AvailableDistanceKm", vehicle.AvailableDistanceKm.ToString()),
                new Parameter("@AvailabilityStartDate", vehicle.AvailabilityStartDate),
                new Parameter("@AvailabilityEndDate", vehicle.AvailabilityEndDate),
                new Parameter("@DepreciationCostPerKm", vehicle.DepreciationCostPerKm.ToString()),
                new Parameter("@CargoType", vehicle.CargoType)
            };

            dynamic result = database.Ejecutar("Vehicle_Update_Id", parameters);
            return new
            {
                success = result.succes,
                message = result.message + ": Vehicle updated",
                result = ""
            };
        }


        [HttpPost]
        [Route("delete")]
        public dynamic deleteVehicle(int id)
        {
            List<Parameter> parameters = new List<Parameter>
            {
                new Parameter("@idVehicle", id.ToString()),
            };

            dynamic result = database.Ejecutar("Vehicle_Delete_Id", parameters);
            return new
            {
                success = result.succes,
                message = result.message + ": Vehicle deleted",
                result = ""
            };
        }
    }
}
