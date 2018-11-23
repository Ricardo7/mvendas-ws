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
    public class ConfiguracoesController : ApiController
    {
        public ConfiguracoesApplication configuracoesApplication;

        public ConfiguracoesController() {
            configuracoesApplication = new ConfiguracoesApplication();
        }

        [JwtAuthentication]
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

        [JwtAuthentication]
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

        [JwtAuthentication]
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

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Configuracoes/GetConfiguracoes")]
        public ConfiguracoesDTO GetConfiguracoes() {
            Configuracoes retorno = null;
            try
            {
                retorno = configuracoesApplication.GetConfiguracao();
            }catch (Exception ex)
            {
                return RetornoController.MontaRetornoConfiguracoes(200, "ERROR", ex.Message, null);
            }

            if (retorno != null) {
                return RetornoController.MontaRetornoConfiguracoes(200, "SUCCESS", "", retorno);
            } else {
                return RetornoController.MontaRetornoConfiguracoes(200, "ERROR", "Dados não encontrados", null);
            }
        }
    }
}
