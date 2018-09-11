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
        public List<Pais> GetListaPaises()
        {
            return locaisApplication.GetListaPaises();
        }

        [HttpGet]
        [Route("api/Locais/GetListaEstados")]
        public List<Estado> GetListaEstados(Pais pais)
        {
            return locaisApplication.GetListaEstados(pais);
        }

        [HttpGet]
        [Route("api/Locais/GetListaCidadess")]
        public List<Cidade> GetListaCidades(Estado estado)
        {
            return locaisApplication.GetListaCidades(estado);
        }
    }
}
