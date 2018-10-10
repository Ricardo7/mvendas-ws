using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application;
using Domain;

namespace WebService.Controllers {
    public class SegmentoMercadoController : ApiController {

        public SegmentoMercadoApplication segmentoMercadoApplication;

        public SegmentoMercadoController() {
            segmentoMercadoApplication = new SegmentoMercadoApplication();
        }

        [HttpPost]
        [Route("api/SegmentoMercado/AddSegmentoMercado")]
        public SegmentoMercadoDTO AddSegmentoMercado(SegmentoMercado segmentoMercado) {
            SegmentoMercado segmentoMercadoCadastrado = segmentoMercadoApplication.AddSegmentoMercado(segmentoMercado);

            if (segmentoMercadoCadastrado != null) {
                return RetornoController.MontaRetornoSegmentoMercado(200, "SUCCESS", "", segmentoMercadoCadastrado);
            } else {
                return RetornoController.MontaRetornoSegmentoMercado(200, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/SegmentoMercado/GetSegmentoMercado")]
        public SegmentoMercadoDTO GetSegmentoMercado(string id) {

            SegmentoMercado retorno = segmentoMercadoApplication.GetSegmentoMercado(id);

            if (retorno != null) {
                return RetornoController.MontaRetornoSegmentoMercado(200, "SUCCESS", "", retorno);
            } else {
                return RetornoController.MontaRetornoSegmentoMercado(200, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/SegmentoMercado/GetListaSegmentosMercado")]
        public ListaSegmentosMercadoDTO GetListaSegmentosMercado() {
            List<SegmentoMercado> ListaTemp = segmentoMercadoApplication.GetListaSegmentosMercado();

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaSegmentosMercado(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaSegmentosMercado(200, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/SegmentoMercado/GetListaSegmentosMercadoAtualizados")]
        public ListaSegmentosMercadoDTO GetListaSegmentosMercadoAtualizados(string dataAt) {
            List<SegmentoMercado> ListaTemp = segmentoMercadoApplication.GetListaSegmentosMercadoAtualizados(dataAt);

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaSegmentosMercado(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaSegmentosMercado(200, "ERROR", "", null);
            }

        }
    }
}
