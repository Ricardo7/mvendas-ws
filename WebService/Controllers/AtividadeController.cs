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
    public class AtividadeController : ApiController {
        public AtividadeApplication atividadeApplication;

        public AtividadeController() {
            atividadeApplication = new AtividadeApplication();
        }

        [HttpPost]
        [Route("api/Atividade/AddAtividade")]
        public AtividadeDTO AddAtividade(Atividade atividade) {

            Atividade atividadeCadastrado = atividadeApplication.AddAtividade(atividade);

            if (atividadeCadastrado != null) {
                return RetornoController.MontaRetornoAtividade(200, "SUCCESS", "", atividadeCadastrado);
            } else {
                return RetornoController.MontaRetornoAtividade(200, "ERROR", "", null);
            }

        }

        [HttpDelete]
        [Route("api/Atividade/RemoveAtividade")]
        public AtividadeDTO RemoveAtividade(string id) {

            bool deucerto = atividadeApplication.RemoveAtividade(id);

            if (deucerto != false) {
                return RetornoController.MontaRetornoAtividade(200, "SUCCESS", "", null);
            } else {
                return RetornoController.MontaRetornoAtividade(200, "ERROR", "", null);
            }

        }

        [HttpPut]
        [Route("api/Atividade/EditaAtividade")]
        public AtividadeDTO EditaAtividade(Atividade atividade) {
            Atividade atividadeCadastrado = atividadeApplication.EditarAtividade(atividade);

            if (atividadeCadastrado != null) {
                return RetornoController.MontaRetornoAtividade(200, "SUCCESS", "", atividadeCadastrado);
            } else {
                return RetornoController.MontaRetornoAtividade(200, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Atividade/GetAtividade")]
        public AtividadeDTO GetAtividade(string id) {

            Atividade atividadeRetorno = atividadeApplication.GetAtividade(id);

            if (atividadeRetorno != null) {
                return RetornoController.MontaRetornoAtividade(200, "SUCCESS", "", atividadeRetorno);
            } else {
                return RetornoController.MontaRetornoAtividade(200, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Atividade/GetListaAtividades")]
        public ListaAtividadesDTO GetListaAtividades() {
            List<Atividade> ListaTemp = atividadeApplication.GetListaAtividades();

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaAtividades(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaAtividades(200, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Atividade/GetListaAtividadesAtualizados")]
        public ListaAtividadesDTO GetListaAtividadesAtualizados(string dataAt) {
            List<Atividade> ListaTemp = atividadeApplication.GetListaAtividadesAtualizados(dataAt);

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaAtividades(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaAtividades(200, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Atividade/GetListaAtividadesUsuario")]
        public ListaAtividadesDTO GetListaAtividadesUsuario(string usuarioID) {
            List<Atividade> ListaTemp = atividadeApplication.GetListaAtividadesUsuario(usuarioID);
            
            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaAtividades(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaAtividades(200, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Atividade/GetListaAtividadesCliente")]
        public ListaAtividadesDTO GetListaAtividadesCliente(string clienteID) {
            List<Atividade> ListaTemp = atividadeApplication.GetListaAtividadesCliente(clienteID);

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaAtividades(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaAtividades(200, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Atividade/GetListaAtividadesClienteUsuario")]
        public ListaAtividadesDTO GetListaAtividadesClienteUsuario(string clienteID, string usuarioID) {
            List<Atividade> ListaTemp = atividadeApplication.GetListaAtividadesClienteUsuario(clienteID, usuarioID);

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaAtividades(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaAtividades(200, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Atividade/GetListaAtividadesSugeridas")]
        public ListaAtividadesDTO GetListaAtividadesSugeridas(string data, string usuarioID)
        {
            /*
            List<Atividade> ListaTemp = atividadeApplication.GetListaAtividades();

            if (ListaTemp.Count() != 0)
            {
                return RetornoController.MontaRetornoListaAtividades(200, "SUCCESS", "", ListaTemp);
            }
            else
            {
                return RetornoController.MontaRetornoListaAtividades(200, "ERROR", "", null);
            }
            */
            return RetornoController.MontaRetornoListaAtividades(200, "SUCCESS", "", null);

        }
    }
}
