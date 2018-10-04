using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application;
using Domain;
using System.Threading.Tasks;

namespace WebService.Controllers {
    public class ClienteController : ApiController {
        public ClienteApplication clienteApplication;

        public ClienteController() {
            clienteApplication = new ClienteApplication();
        }

        [HttpPost]
        [Route("api/Cliente/AddCliente")]
        public ClienteDTO AddCliente(Cliente cliente) {
            Cliente clienteCadastrado = clienteApplication.AddCliente(cliente);

            if (clienteCadastrado.ID != null) {
                return RetornoController.MontaRetornoCliente(200, "SUCCESS", "", clienteCadastrado);
            } else {
                return RetornoController.MontaRetornoCliente(401, "ERROR", "", null);
            }

        }

        [HttpPut]
        [Route("api/Cliente/EditaCliente")]
        public ClienteDTO EditaCliente(Cliente cliente) {
            Cliente clienteCadastrado = clienteApplication.EditarCliente(cliente);

            if (clienteCadastrado.ID != null) {
                return RetornoController.MontaRetornoCliente(200, "SUCCESS", "", clienteCadastrado);
            } else {
                return RetornoController.MontaRetornoCliente(401, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Cliente/GetCliente")]
        public ClienteDTO GetCliente(string id) {
            Cliente clienteConsulta = new Cliente {
                ID = id,
            };

            Cliente clienteRetorno = clienteApplication.GetCliente(clienteConsulta);

            if (clienteRetorno.ID != null) {
                return RetornoController.MontaRetornoCliente(200, "SUCCESS", "", clienteRetorno);
            } else {
                return RetornoController.MontaRetornoCliente(401, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Cliente/GetListaClientes")]
        public ListaClientesDTO GetListaClientes() {
            List<Cliente> ListaTemp = clienteApplication.GetListaClientes();

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaClientes(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaClientes(401, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Cliente/GetListaClientesAtualizados")]
        public ListaClientesDTO GetListaClientesAtualizados(string dataAt) {
            List<Cliente> ListaTemp = clienteApplication.GetListaClientesAtualizados(dataAt);

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaClientes(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaClientes(401, "ERROR", "", null);
            }

        }

    }
}
