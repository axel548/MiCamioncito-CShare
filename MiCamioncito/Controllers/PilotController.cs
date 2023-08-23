using MiCamioncito.Models;
using MiCamioncito.Resources;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Transactions;

namespace MiCamioncito.Controllers
{

    [ApiController]
    [Route("pilot")]
    public class PilotController : ControllerBase
    {

        [HttpGet]
        [Route("lists")]
        public dynamic listsPilot()
        {
            DataTable tPilot = database.Listar("Pilots_Get");

            string json = JsonConvert.SerializeObject(tPilot);

            return new
            {
                success = true,
                message = "Successfull",
                result = new
                {
                    pilots = JsonConvert.DeserializeObject<List<Pilot>>(json)
                }
            };
        }


        [HttpGet]
        [Route("list")]
        public dynamic listPilot(int id)
        {
            List<Parameter> parameters = new List<Parameter>
            {
                new Parameter("@idPilot", id.ToString())
            };

            DataTable tPilot = database.Listar("Pilot_Get_Id", parameters);
            string json = JsonConvert.SerializeObject(tPilot);

            return new
            {
                success = true,
                message = "Successfull",
                result = new
                {
                    pilot = JsonConvert.DeserializeObject<List<Pilot>>(json)
                }
            };
        }





        [HttpPost]
        [Route("create")]
        public dynamic createPilot(Pilot pilot)
        {
            List<Parameter> parameters = new List<Parameter>
            {
                new Parameter("@Name", pilot.Name),
                new Parameter("@AvailableTime", pilot.AvailableTime.ToString()),
                new Parameter("@AvailabilityStartDate", pilot.AvailabilityStartDate),
                new Parameter("@AvailabilityEndDate", pilot.AvailabilityEndDate),
                new Parameter("@PerDiem", pilot.PerDiem.ToString()),
                new Parameter("@AdditionalExpenses", pilot.AdditionalExpenses.ToString())
            };

            dynamic result = database.Ejecutar("Pilot_Insert", parameters);
            return new
            {
                success = result.succes,
                message = result.message + ": Pilot created",
                result = ""
            };
        }


        [HttpPost]
        [Route("update")]
        public dynamic updatePilot(Pilot pilot)
        {
            List<Parameter> parameters = new List<Parameter>
            {
                new Parameter("@idPilot", pilot.idPilot.ToString()),
                new Parameter("@Name", pilot.Name),
                new Parameter("@AvailableTime", pilot.AvailableTime.ToString()),
                new Parameter("@AvailabilityStartDate", pilot.AvailabilityStartDate),
                new Parameter("@AvailabilityEndDate", pilot.AvailabilityEndDate),
                new Parameter("@PerDiem", pilot.PerDiem.ToString()),
                new Parameter("@AdditionalExpenses", pilot.AdditionalExpenses.ToString()),
            };

            dynamic result = database.Ejecutar("Pilot_Update_Id", parameters);
            return new
            {
                success = result.succes,
                message = result.message + ": Pilot updated",
                result = ""
            };
        }


        [HttpPost]
        [Route("delete")]
        public dynamic deletePilot(int id)
        {
            List<Parameter> parameters = new List<Parameter>
            {
                new Parameter("@idPilot", id.ToString()),
            };

            dynamic result = database.Ejecutar("Pilot_Delete_Id", parameters);
            return new
            {
                success = result.succes,
                message = result.message + ": Pilot deleted",
                result = ""
            };
        }
    }
}
