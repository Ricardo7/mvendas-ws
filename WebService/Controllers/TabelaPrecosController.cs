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

namespace WebService.Controllers
{
    public class TabelaPrecosController : ApiController
    {
        public TabelaPrecosApplication tabelaPrecosApplication;

        public TabelaPrecosController() {
            tabelaPrecosApplication = new TabelaPrecosApplication();
        }

        [JwtAuthentication]
        [HttpPost]
        [Route("api/TabelaPrecos/AddTabelaPrecos")]
        public TabelaPrecosDTO AddTabelaPrecos(TabelaPrecos tabelaPrecos) {
            TabelaPrecos tabelaPrecosCadastrado = tabelaPrecosApplication.AddTabelaPrecos(tabelaPrecos);

            if (tabelaPrecosCadastrado != null) {
                return RetornoController.MontaRetornoTabelaPrecos(200, "SUCCESS", "", tabelaPrecosCadastrado);
            } else {
                return RetornoController.MontaRetornoTabelaPrecos(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpPut]
        [Route("api/TabelaPrecos/AditaTabelaPrecos")]
        public TabelaPrecosDTO EditaTabelaPrecos(TabelaPrecos tabelaPrecos) {
            TabelaPrecos tabelaPrecosCadastrado = tabelaPrecosApplication.EditaTabelaPrecos(tabelaPrecos);

            if (tabelaPrecosCadastrado != null) {
                return RetornoController.MontaRetornoTabelaPrecos(200, "SUCCESS", "", tabelaPrecosCadastrado);
            } else {
                return RetornoController.MontaRetornoTabelaPrecos(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/TabelaPrecos/GetTabelaPrecos")]
        public TabelaPrecosDTO GetTabelaPrecos(string id) {

            TabelaPrecos tabelaPrecosRetorno = tabelaPrecosApplication.GetTabelaPrecos(id);

            if (tabelaPrecosRetorno != null) {
                return RetornoController.MontaRetornoTabelaPrecos(200, "SUCCESS", "", tabelaPrecosRetorno);
            } else {
                return RetornoController.MontaRetornoTabelaPrecos(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/TabelaPrecos/GetListaTabelaPrecos")]
        public ListaTabelasPrecosDTO GetListaTabelaPrecos() {
            List<TabelaPrecos> ListaTemp = tabelaPrecosApplication.GetListaTabelasPrecos();

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaTabelasPrecos(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaTabelasPrecos(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/TabelaPrecos/GetListaTabelaPrecosAtualizados")]
        public ListaTabelasPrecosDTO GetListaTabelaPrecosAtualizados(string dataAt) {
            try
            {
                List<TabelaPrecos> ListaTemp = tabelaPrecosApplication.GetListaTabelasPrecosAtualizados(dataAt);


                if (ListaTemp.Count() != 0)
                {
                    return RetornoController.MontaRetornoListaTabelasPrecos(200, "SUCCESS", "", ListaTemp);
                }
                else
                {
                    return RetornoController.MontaRetornoListaTabelasPrecos(200, "ERROR", "", null);
                }
            }
            catch (Exception ex){
                return RetornoController.MontaRetornoListaTabelasPrecos(200, "ERROR", ex.Message, null);
            }

        }
    }
}
