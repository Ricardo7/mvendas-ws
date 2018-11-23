using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain;
using MongoDB.Driver;

namespace Application {
    public class ConfiguracoesApplication {
        private ConfiguracoesRepository dbConfiguracoes;

        public ConfiguracoesApplication() {
            dbConfiguracoes = new ConfiguracoesRepository();
        }

        public Configuracoes GetConfiguracoes(string ID) {
            try {
                return dbConfiguracoes.ConsultaConfiguracoes(ID);
            } catch (Exception) {
                return null;
            }
        }

        public Configuracoes GetConfiguracao()
        {
            try
            {
                return dbConfiguracoes.ConsultaConfiguracao();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Configuracoes> GetListaConfiguracoes() {
            try {
                return dbConfiguracoes.GetListaConfiguracoes();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public Configuracoes AddConfiguracoes(Configuracoes configuracoes) {
            Configuracoes consultaExiste;
            try {
                consultaExiste = dbConfiguracoes.ConsultaConfiguracoes(configuracoes.ID);

                if (consultaExiste == null) {
                    Configuracoes cadastrado = dbConfiguracoes.AddConfiguracoes(configuracoes);
                    return cadastrado;

                } else {
                    return null;
                }

            } catch (Exception) {
                return null;
            }
        }

        public Configuracoes EditarConfiguracoes(Configuracoes configuracoes) {
            Configuracoes consultaExiste;
            try {
                consultaExiste = dbConfiguracoes.ConsultaConfiguracoes(configuracoes.ID);

                if (consultaExiste != null) {
                    Configuracoes editado = dbConfiguracoes.EditarConfiguracoes(configuracoes);
                    return editado;

                } else {
                    return null;
                }

            } catch (Exception) {
                return null;
            }
        }

    }
}