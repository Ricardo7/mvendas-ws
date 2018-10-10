using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain;
using MongoDB.Driver;

namespace Application {
    public class TabelaPrecosApplication {
        private TabelaPrecosRepository dbTabelaPrecos;

        public TabelaPrecosApplication() {
            dbTabelaPrecos = new TabelaPrecosRepository();
        }

        public TabelaPrecos GetTabelaPrecos(string id) {
            try {
                return dbTabelaPrecos.ConsultaTabelaPrecos(id);
            } catch (Exception) {
                TabelaPrecos vazio = new TabelaPrecos();
                return vazio;
            }
        }

        public List<TabelaPrecos> GetListaTabelasPrecos() {
            try {
                return dbTabelaPrecos.GetListaTabelasPrecos();
            } catch (Exception) {
                List<TabelaPrecos> ListaVazio = new List<TabelaPrecos>();

                return ListaVazio;
            }
        }

        public List<TabelaPrecos> GetListaTabelasPrecosAtualizados(string data) {
            try {
                return dbTabelaPrecos.GetListaTabelasPrecosAtualizadas(data);
            } catch (Exception) {
                List<TabelaPrecos> ListaVazio = new List<TabelaPrecos>();

                return ListaVazio;
            }
        }

        public TabelaPrecos AddTabelaPrecos(TabelaPrecos tabelaPrecos) {
            TabelaPrecos consultaExiste;
            try {
                //consultaExiste = dbTabelaPrecos.ConsultaSegmentoMercado(segmentoMercado.ID);
                consultaExiste = null;

                if (consultaExiste == null) {
                    TabelaPrecos cadastrado = dbTabelaPrecos.AddTabelaPrecos(tabelaPrecos);

                    return cadastrado;
                } else {
                    return null;
                }

            } catch (Exception) {
                return null;
            }

        }

        public TabelaPrecos EditaTabelaPrecos(TabelaPrecos tabelaPrecos) {
            TabelaPrecos consultaExiste = new TabelaPrecos(); ;
            try {
                //consultaExiste = dbTabelaPrecos.ConsultaSegmentoMercado(segmentoMercado.ID);
                consultaExiste = null;

                if (consultaExiste.ID == null) {
                    TabelaPrecos editado = dbTabelaPrecos.EditarTabelaPrecos(tabelaPrecos);

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
