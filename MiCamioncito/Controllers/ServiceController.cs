using MiCamioncito.Models;
using MiCamioncito.Resources;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace MiCamioncito.Controllers
{
    [ApiController]
    [Route("service")]
    public class ServiceController : ControllerBase
    {

        [HttpGet]
        [Route("lists")]
        public dynamic listsServices()
        {
            DataTable tService = database.Listar("Services_Get");

            string json = JsonConvert.SerializeObject(tService);

            return new
            {
                success = true,
                message = "Successfull",
                result = new
                {
                    services = JsonConvert.DeserializeObject<List<Service>>(json)
                }
            };
        }

        [HttpGet]
        [Route("list")]
        public dynamic listService(int id)
        {

            List<Parameter> parameters = new List<Parameter>
            {
                new Parameter("@idService", id.ToString())
            };

            DataTable tService = database.Listar("Service_Get_Id", parameters);
            string json = JsonConvert.SerializeObject(tService);

            return new
            {
                success = true,
                message = "Successfull",
                result = new
                {
                    service = JsonConvert.DeserializeObject<List<Service>>(json)
                }
            };
        }


        [HttpPost]
        [Route("create")]
        public dynamic createService(Service service)
        {
            List<Parameter> parameters = new List<Parameter>
            {
                new Parameter("@IDVehicle", service.IDVehicle.ToString()),
                new Parameter("@IDPilot", service.IDPilot.ToString()),
                new Parameter("@IDClient", service.IDClient.ToString()),
                new Parameter("@ServiceDate", service.ServiceDate),
                new Parameter("@DeliveryDate", service.DeliveryDate),
                new Parameter("@TotalCost", service.TotalCost.ToString())
            };

            dynamic result = database.Ejecutar("Service_Insert", parameters);
            return new
            {
                success = result.succes,
                message = result.message + ": Service created",
                result = ""
            };
        }


        [HttpPost]
        [Route("update")]
        public dynamic updateService(Service service)
        {
            List<Parameter> parameters = new List<Parameter>
            {
                new Parameter("@IDService", service.IDService.ToString()),
                new Parameter("@IDVehicle", service.IDVehicle.ToString()),
                new Parameter("@IDPilot", service.IDPilot.ToString()),
                new Parameter("@IDClient", service.IDClient.ToString()),
                new Parameter("@ServiceDate", service.ServiceDate),
                new Parameter("@DeliveryDate", service.DeliveryDate),
                new Parameter("@TotalCost", service.TotalCost.ToString())
            };

            dynamic result = database.Ejecutar("Service_Update_Id", parameters);
            return new
            {
                success = result.succes,
                message = result.message + ": Service updated",
                result = ""
            };
        }


        [HttpPost]
        [Route("delete")]
        public dynamic deleteClient(int id)
        {
            List<Parameter> parameters = new List<Parameter>
            {
                new Parameter("@idService", id.ToString()),
            };

            dynamic result = database.Ejecutar("Service_Delete_Id", parameters);
            return new
            {
                success = result.succes,
                message = result.message + ": Service deleted",
                result = ""
            };
        }
    }
}
