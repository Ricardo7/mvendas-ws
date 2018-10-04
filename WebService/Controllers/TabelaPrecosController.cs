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
    public class TabelaPrecosController : ApiController
    {
        public TabelaPrecosApplication tabelaPrecosApplication;

        public TabelaPrecosController() {
            tabelaPrecosApplication = new TabelaPrecosApplication();
        }

        [HttpPost]
        [Route("api/TabelaPrecos/AddTabelaPrecos")]
        public TabelaPrecosDTO AddTabelaPrecos(TabelaPrecos tabelaPrecos) {
            TabelaPrecos tabelaPrecosCadastrado = tabelaPrecosApplication.AddTabelaPrecos(tabelaPrecos);

            if (tabelaPrecosCadastrado.ID != null) {
                return RetornoController.MontaRetornoTabelaPrecos(200, "SUCCESS", "", tabelaPrecosCadastrado);
            } else {
                return RetornoController.MontaRetornoTabelaPrecos(401, "ERROR", "", null);
            }

        }

        [HttpPut]
        [Route("api/TabelaPrecos/AditaTabelaPrecos")]
        public TabelaPrecosDTO EditaTabelaPrecos(TabelaPrecos tabelaPrecos) {
            TabelaPrecos tabelaPrecosCadastrado = tabelaPrecosApplication.EditaTabelaPrecos(tabelaPrecos);

            if (tabelaPrecosCadastrado.ID != null) {
                return RetornoController.MontaRetornoTabelaPrecos(200, "SUCCESS", "", tabelaPrecosCadastrado);
            } else {
                return RetornoController.MontaRetornoTabelaPrecos(401, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/TabelaPrecos/GetTabelaPrecos")]
        public TabelaPrecosDTO GetTabelaPrecos(string id) {

            TabelaPrecos tabelaPrecosRetorno = tabelaPrecosApplication.GetTabelaPrecos(id);

            if (tabelaPrecosRetorno.ID != null) {
                return RetornoController.MontaRetornoTabelaPrecos(200, "SUCCESS", "", tabelaPrecosRetorno);
            } else {
                return RetornoController.MontaRetornoTabelaPrecos(401, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/TabelaPrecos/GetListaTabelaPrecos")]
        public ListaTabelasPrecosDTO GetListaTabelaPrecos() {
            List<TabelaPrecos> ListaTemp = tabelaPrecosApplication.GetListaTabelasPrecos();

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaTabelasPrecos(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaTabelasPrecos(401, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/TabelaPrecos/GetListaTabelaPrecosAtualizados")]
        public ListaTabelasPrecosDTO GetListaTabelaPrecosAtualizados(string dataAt) {
            List<TabelaPrecos> ListaTemp = tabelaPrecosApplication.GetListaTabelasPrecosAtualizados(dataAt);

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaTabelasPrecos(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaTabelasPrecos(401, "ERROR", "", null);
            }

        }
    }
}
