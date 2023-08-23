using MiCamioncito.Models;
using MiCamioncito.Resources;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using Parameter = MiCamioncito.Resources.Parameter;

namespace MiCamioncito.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        [Route("lists")]
        public dynamic listsClients()
        {
            DataTable tClient = database.Listar("Client_Get");

            string json = JsonConvert.SerializeObject(tClient);

            return new
            {
                success = true,
                message = "Successfull",
                result =  new {
                    clients = JsonConvert.DeserializeObject<List<Client>>(json)
                }
            };
        }

        [HttpGet]
        [Route("list")]
        public dynamic listClient(int id)
        {

            List<Parameter> parameters = new List<Parameter>
            {
                new Parameter("@idClient", id.ToString())
            };

            DataTable tClient = database.Listar("Client_Get_Id", parameters);
            string json = JsonConvert.SerializeObject(tClient);

            return new
            {
                success = true,
                message = "Successfull",
                result = new
                {
                    client = JsonConvert.DeserializeObject<List<Client>>(json)
                }
            };
        }


        [HttpPost]
        [Route("create")]
        public dynamic createClient(Client client)
        {
            List<Parameter> parameters = new List<Parameter>
            {
                new Parameter("@Name", client.Name),
                new Parameter("@Email", client.Email),
                new Parameter("@CargoPercentage", client.CargoPercentage.ToString()),
                new Parameter("@ReceptionAddress", client.ReceptionAddress),
                new Parameter("@DeliveryAddress", client.DeliveryAddress),
                new Parameter("@RequiredDocumentation", client.RequiredDocumentation)
            };

            dynamic result = database.Ejecutar("Client_Insert", parameters);
            return new
            {
                success = result.succes,
                message = result.message + ": Client created",
                result = ""
            };
        }


        [HttpPost]
        [Route("update")]
        public dynamic updateClient(Client client)
        {
            List<Parameter> parameters = new List<Parameter>
            {
                new Parameter("@IDClient", client.IDClient.ToString()),
                new Parameter("@Name", client.Name),
                new Parameter("@Email", client.Email),
                new Parameter("@CargoPercentage", client.CargoPercentage.ToString()),
                new Parameter("@ReceptionAddress", client.ReceptionAddress),
                new Parameter("@DeliveryAddress", client.DeliveryAddress),
                new Parameter("@RequiredDocumentation", client.RequiredDocumentation)
            };

            dynamic result = database.Ejecutar("Client_Update_Id", parameters);
            return new
            {
                success = result.succes,
                message = result.message + ": Client updated",
                result = ""
            };
        }


        [HttpPost]
        [Route("delete")]
        public dynamic deleteClient(int id)
        {
            List<Parameter> parameters = new List<Parameter>
            {
                new Parameter("@idClient", id.ToString()),
            };

            dynamic result = database.Ejecutar("Client_Delete_Id", parameters);
            return new
            {
                success = result.succes,
                message = result.message + ": Client deleted",
                result = ""
            };
        }
    }
}
