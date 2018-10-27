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
    public class ConfiguracoesController : ApiController
    {
        public ConfiguracoesApplication configuracoesApplication;

        public ConfiguracoesController() {
            configuracoesApplication = new ConfiguracoesApplication();
        }

        [HttpPost]
        [Route("api/Configuracoes/AddConfiguracoes")]
        public ConfiguracoesDTO AddConfiguracoes(Configuracoes configuracoes) {

            Configuracoes configuracoesCadastrado = configuracoesApplication.AddConfiguracoes(configuracoes);

            if (configuracoesCadastrado != null) {
                return RetornoController.MontaRetornoConfiguracoes(200, "SUCCESS", "", configuracoesCadastrado);
            } else {
                return RetornoController.MontaRetornoConfiguracoes(200, "ERROR", "", null);
            }

        }

        [HttpPut]
        [Route("api/Configuracoes/EditaConfiguracoes")]
        public ConfiguracoesDTO EditaConfiguracoes(Configuracoes configuracoes) {
            Configuracoes configuracoesCadastrado = configuracoesApplication.EditarConfiguracoes(configuracoes);

            if (configuracoesCadastrado != null) {
                return RetornoController.MontaRetornoConfiguracoes(200, "SUCCESS", "", configuracoesCadastrado);
            } else {
                return RetornoController.MontaRetornoConfiguracoes(200, "ERROR", "", null);
            }
        }

        [HttpGet]
        [Route("api/Configuracoes/GetConfiguracoesID")]
        public ConfiguracoesDTO GetConfiguracoesID(string id) {

            Configuracoes configuracoesRetorno = configuracoesApplication.GetConfiguracoes(id);

            if (configuracoesRetorno != null) {
                return RetornoController.MontaRetornoConfiguracoes(200, "SUCCESS", "", configuracoesRetorno);
            } else {
                return RetornoController.MontaRetornoConfiguracoes(200, "ERROR", "", null);
            }
        }

        [HttpGet]
        [Route("api/Configuracoes/GetConfiguracoes")]
        public ConfiguracoesDTO GetConfiguracoes() {
            List<Configuracoes> ListaTemp = configuracoesApplication.GetListaConfiguracoess();
            Configuracoes retorno = ListaTemp[0];

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoConfiguracoes(200, "SUCCESS", "", retorno);
            } else {
                return RetornoController.MontaRetornoConfiguracoes(200, "ERROR", "", null);
            }
        }
    }
}
