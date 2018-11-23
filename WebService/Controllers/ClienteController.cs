using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application;
using Domain;
using System.Threading.Tasks;
using WebService.Filters;

namespace WebService.Controllers {
    public class ClienteController : ApiController {
        public ClienteApplication clienteApplication;

        public ClienteController() {
            clienteApplication = new ClienteApplication();
        }

        [JwtAuthentication]
        [HttpPost]
        [Route("api/Cliente/AddCliente")]
        //[EnableCors(origins: "*", methods: "*", headers: "*")]
        public ClienteDTO AddCliente(Cliente cliente) {
            Cliente clienteCadastrado = null;
            try
            {
                clienteCadastrado = clienteApplication.AddCliente(cliente);
            }catch (Exception ex)
            {
                return RetornoController.MontaRetornoCliente(200, "ERROR", ex.Message, null);
            }
            if (clienteCadastrado != null) {
                return RetornoController.MontaRetornoCliente(200, "SUCCESS", "", clienteCadastrado);
            } else {
                return RetornoController.MontaRetornoCliente(200, "ERROR", "Dados não encontrados", null);
            }

        }

        [JwtAuthentication]
        [HttpPut]
        [Route("api/Cliente/EditaCliente")]
        public ClienteDTO EditaCliente(Cliente cliente) {
            Cliente clienteCadastrado = clienteApplication.EditarCliente(cliente);

            if (clienteCadastrado != null) {
                return RetornoController.MontaRetornoCliente(200, "SUCCESS", "", clienteCadastrado);
            } else {
                return RetornoController.MontaRetornoCliente(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Cliente/GetCliente")]
        public ClienteDTO GetCliente(string id) {
            Cliente clienteConsulta = new Cliente {
                ID = id,
            };

            Cliente clienteRetorno = clienteApplication.GetCliente(clienteConsulta);

            if (clienteRetorno != null) {
                return RetornoController.MontaRetornoCliente(200, "SUCCESS", "", clienteRetorno);
            } else {
                return RetornoController.MontaRetornoCliente(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Cliente/GetListaClientes")]
        public ListaClientesDTO GetListaClientes(string usuarioID, int origem) {
            List<Cliente> ListaTemp = null;

            try
            {
                ListaTemp = clienteApplication.GetListaClientes(usuarioID, origem);
            }
            catch (Exception ex)
            {
                return RetornoController.MontaRetornoListaClientes(200, "ERROR", ex.Message, null);
            }

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaClientes(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaClientes(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Cliente/GetListaClientesAtualizados")]
        public ListaClientesDTO GetListaClientesAtualizados(string dataAt, string usuarioID, int origem) {
            List<Cliente> ListaTemp = null;

            try
            {
                ListaTemp = clienteApplication.GetListaClientesAtualizados(dataAt, usuarioID, origem);
            }
            catch (Exception ex)
            {
                return RetornoController.MontaRetornoListaClientes(200, "ERROR", ex.Message, null);
            }

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaClientes(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaClientes(200, "ERROR", "", null);
            }

        }

    }
}
