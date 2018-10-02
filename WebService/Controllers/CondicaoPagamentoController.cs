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
    public class CondicaoPagamentoController : ApiController {
        public CondicaoPagamentoApplication condicaoPagamentoApplication;

        public CondicaoPagamentoController() {
            condicaoPagamentoApplication = new CondicaoPagamentoApplication();
        }

        [HttpPost]
        [Route("api/CondicaoPagamento/AddCondicaoPagamento")]
        public CondicaoPagamentoDTO AddCondicaoPagamento(CondicaoPagamento condicaoPagamento) {
            CondicaoPagamento condicaoPagamentoCadastrado = condicaoPagamentoApplication.AddCondicaoPagamento(condicaoPagamento);

            if (condicaoPagamentoCadastrado != null) {
                return RetornoController.MontaRetornoCondicaoPagamento(200, "SUCCESS", "", condicaoPagamentoCadastrado);
            } else {
                return RetornoController.MontaRetornoCondicaoPagamento(401, "ERROR", "", null);
            }

        }

        [HttpPut]
        [Route("api/CondicaoPagamento/EditaCondicaoPagamento")]
        public CondicaoPagamentoDTO EditaCondicaoPagamento(CondicaoPagamento condicaoPagamento) {
            CondicaoPagamento condicaoPagamentoCadastrado = condicaoPagamentoApplication.EditaCondicaoPagamento(condicaoPagamento);

            if (condicaoPagamentoCadastrado != null) {
                return RetornoController.MontaRetornoCondicaoPagamento(200, "SUCCESS", "", condicaoPagamentoCadastrado);
            } else {
                return RetornoController.MontaRetornoCondicaoPagamento(401, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/CondicaoPagamento/GetCondicaoPagamento")]
        public CondicaoPagamentoDTO GetCondicaoPagamento(string id) {

            CondicaoPagamento tabelaPrecosRetorno = condicaoPagamentoApplication.GetCondicaoPagamento(id);

            if (tabelaPrecosRetorno != null) {
                return RetornoController.MontaRetornoCondicaoPagamento(200, "SUCCESS", "", tabelaPrecosRetorno);
            } else {
                return RetornoController.MontaRetornoCondicaoPagamento(401, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/CondicaoPagamento/GetListaCondicaoPagamento")]
        public ListaCondicoesPagamentoDTO GetListaCondicaoPagamento() {
            List<CondicaoPagamento> ListaTemp = condicaoPagamentoApplication.GetListaCondicoesPagamento();

            if (ListaTemp != null) {
                return RetornoController.MontaRetornoListaCondicaoPagamento(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaCondicaoPagamento(401, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/CondicaoPagamento/GetListaCondicaoPagamentoAtualizados")]
        public ListaCondicoesPagamentoDTO GetListaCondicaoPagamentoAtualizados(string dataAt) {
            List<CondicaoPagamento> ListaTemp = condicaoPagamentoApplication.GetListaCondicoesPagamentoAtualizados(dataAt);

            if (ListaTemp != null) {
                return RetornoController.MontaRetornoListaCondicaoPagamento(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaCondicaoPagamento(401, "ERROR", "", null);
            }

        }
    }
}
