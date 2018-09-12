using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application;
using Domain;
using System.Threading.Tasks;

namespace WebService.Controllers
{
    public class ClienteController : ApiController
    {
        public ClienteApplication clienteApplication;

        public ClienteController()
        {
            clienteApplication = new ClienteApplication();
        }

        [HttpPost]
        [Route("api/Cliente/AddCliente")]
        public object AddCliente(Cliente cliente)
        {
            Cliente clienteCadastrado = clienteApplication.AddCliente(cliente);

            if (clienteCadastrado != null) {
                return RetornoController.MontaRetorno(200, "SUCCESS", "", clienteCadastrado);
            } else {
                return RetornoController.MontaRetorno(401, "ERROR", "", null);
            }
        }

        [HttpGet]
        [Route("api/Cliente/GetCliente")]
        public Cliente GetCliente(int id)
        {
            Cliente clienteConsulta = new Cliente
            {
                ID = id,
            };
            return clienteApplication.GetCliente(clienteConsulta);
        }

        [HttpGet]
        [Route("api/Cliente/GetListaClientes")]
        public List<Cliente> GetListaClientes()
        {
            List<Cliente> ListaTemp = clienteApplication.GetListaClientes();
            return ListaTemp;
        }

    }
}
