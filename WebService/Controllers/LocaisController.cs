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
    public class LocaisController : ApiController
    {
        public LocaisApplication locaisApplication;

        public LocaisController()
        {
            locaisApplication = new LocaisApplication();
        }

        [HttpGet]
        [Route("api/Locais/GetListaPaises")]
        public ListaPaisesDTO GetListaPaises()
        {
            List<Pais> paises = locaisApplication.GetListaPaises();

            if (paises != null) {
                return RetornoController.MontaRetornoListaPaises(200, "SUCCESS", "", paises);
            } else {
                return RetornoController.MontaRetornoListaPaises(401, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Locais/GetListaEstados")]
        public ListaEstadosDTO GetListaEstados(Pais pais)
        {
            List<Estado> estados = locaisApplication.GetListaEstados(pais);

            if (estados != null) {
                return RetornoController.MontaRetornoListaEstados(200, "SUCCESS", "", estados);
            } else {
                return RetornoController.MontaRetornoListaEstados(401, "ERROR", "", null);
            }
        }

        [HttpGet]
        [Route("api/Locais/GetListaCidades")]
        public ListaCidadesDTO GetListaCidades(Estado estado)
        {
            List<Cidade> cidades = locaisApplication.GetListaCidades(estado);

            if (cidades != null) {
                return RetornoController.MontaRetornoListaCidades(200, "SUCCESS", "", cidades);
            } else {
                return RetornoController.MontaRetornoListaCidades(401, "ERROR", "", null);
            }
        }
    }
}
