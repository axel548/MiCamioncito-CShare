using MiCamioncito.Models;
using MiCamioncito.Resources;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net.Sockets;

namespace MiCamioncito.Controllers
{
    [ApiController]
    [Route("reportery")]
    public class ReportController : ControllerBase
    {

        [HttpGet]
        [Route("list")]
        public dynamic listsClients(string startdate, string enddate)
        {

            List<Parameter> parameters = new List<Parameter>
            {
                new Parameter("@StartDate", startdate),
                new Parameter("@EndDate", enddate)
            };

            DataTable tPilot = database.Listar("Reportery_list_pilot", parameters);
            DataTable tVehicle = database.Listar("Reportery_list_vehicle", parameters);

            string json_pilots = JsonConvert.SerializeObject(tPilot);
            string json_vehicles = JsonConvert.SerializeObject(tVehicle);

            return new
            {
                success = true,
                message = "Successfull: Vehicles and Pilots available in the range of dates",
                result = new
                {
                   pilots = JsonConvert.DeserializeObject<List<Pilot>>(json_pilots),
                   vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(json_vehicles)
                }
            };
        }

    }
}
