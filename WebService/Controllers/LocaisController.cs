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
    public class LocaisController : ApiController
    {
        public LocaisApplication locaisApplication;

        public LocaisController()
        {
            locaisApplication = new LocaisApplication();
        }

        [JwtAuthentication]
        [HttpPost]
        [Route("api/Locais/AddPais")]
        public PaisDTO AddPais(Pais pais) {
            Pais paisCadastrado = locaisApplication.AddPais(pais);

            if (paisCadastrado != null) {
                return RetornoController.MontaRetornoPais(200, "SUCCESS", "", paisCadastrado);
            } else {
                return RetornoController.MontaRetornoPais(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Locais/GetListaPaises")]
        public ListaPaisesDTO GetListaPaises()
        {
            List<Pais> paises = locaisApplication.GetListaPaises();

            if (paises.Count() != 0) {
                return RetornoController.MontaRetornoListaPaises(200, "SUCCESS", "", paises);
            } else {
                return RetornoController.MontaRetornoListaPaises(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Locais/GetListaPaisesAtualizados")]
        public ListaPaisesDTO GetListaPaisesAtualizados(string dataAt) {
            List<Pais> paises = locaisApplication.GetListaPaisesAtualizados(dataAt);

            if (paises.Count() != 0) {
                return RetornoController.MontaRetornoListaPaises(200, "SUCCESS", "", paises);
            } else {
                return RetornoController.MontaRetornoListaPaises(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Locais/GetPais")]
        public PaisDTO GetPais(string id) {
            Pais pais = locaisApplication.GetPais(id);

            if (pais != null) {
                return RetornoController.MontaRetornoPais(200, "SUCCESS", "", pais);
            } else {
                return RetornoController.MontaRetornoPais(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpPost]
        [Route("api/Locais/AddEstado")]
        public EstadoDTO AddEstado(Estado estado) {
            Estado estadoCadastrado = locaisApplication.AddEstado(estado);

            if (estadoCadastrado != null) {
                return RetornoController.MontaRetornoEstado(200, "SUCCESS", "", estadoCadastrado);
            } else {
                return RetornoController.MontaRetornoEstado(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Locais/GetListaEstados")]
        public ListaEstadosDTO GetListaEstados(String siglaPais)
        {
            List<Estado> estados = locaisApplication.GetListaEstados(siglaPais);

            if (estados.Count() != 0 ) {
                return RetornoController.MontaRetornoListaEstados(200, "SUCCESS", "", estados);
            } else {
                return RetornoController.MontaRetornoListaEstados(200, "ERROR", "", null);
            }
        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Locais/GetListaEstadosAtualizados")]
        public ListaEstadosDTO GetListaEstadosAtualizados(String dataAt) {
            List<Estado> estados = locaisApplication.GetListaEstadosAtualizados(dataAt);

            if (estados.Count() != 0) {
                return RetornoController.MontaRetornoListaEstados(200, "SUCCESS", "", estados);
            } else {
                return RetornoController.MontaRetornoListaEstados(200, "ERROR", "", null);
            }
        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Locais/GetEstado")]
        public EstadoDTO GetEstado(string id) {
            Estado estado = locaisApplication.GetEstado(id);

            if (estado != null) {
                return RetornoController.MontaRetornoEstado(200, "SUCCESS", "", estado);
            } else {
                return RetornoController.MontaRetornoEstado(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpPost]
        [Route("api/Locais/AddCidade")]
        public CidadeDTO AddCidade(Cidade cidade) {
            Cidade cidadeCadastrado = locaisApplication.AddCidade(cidade);

            if (cidadeCadastrado != null) {
                return RetornoController.MontaRetornoCidade(200, "SUCCESS", "", cidadeCadastrado);
            } else {
                return RetornoController.MontaRetornoCidade(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Locais/GetListaCidades")]
        public ListaCidadesDTO GetListaCidades(String siglaEstado)
        {
            List<Cidade> cidades = locaisApplication.GetListaCidades(siglaEstado);

            if (cidades.Count() != 0) {
                return RetornoController.MontaRetornoListaCidades(200, "SUCCESS", "", cidades);
            } else {
                return RetornoController.MontaRetornoListaCidades(200, "ERROR", "", null);
            }
        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Locais/GetListaCidadesAtualizadas")]
        public ListaCidadesDTO GetListaCidadesAtualizadas(String dataAt) {
            List<Cidade> cidades = locaisApplication.GetListaCidadesAtualizadas(dataAt);

            if (cidades.Count() != 0) {
                return RetornoController.MontaRetornoListaCidades(200, "SUCCESS", "", cidades);
            } else {
                return RetornoController.MontaRetornoListaCidades(200, "ERROR", "", null);
            }
        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Locais/GetCidade")]
        public CidadeDTO GetCidade(string id) {
            Cidade cidade = locaisApplication.GetCidade(id);

            if (cidade != null) {
                return RetornoController.MontaRetornoCidade(200, "SUCCESS", "", cidade);
            } else {
                return RetornoController.MontaRetornoCidade(200, "ERROR", "", null);
            }

        }
    }
}
