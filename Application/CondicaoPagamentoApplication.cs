using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain;
using MongoDB.Driver;

namespace Application {
    public class CondicaoPagamentoApplication {
        private CondicaoPagamentoRepository dbCondicao;

        public CondicaoPagamentoApplication() {
            dbCondicao = new CondicaoPagamentoRepository();
        }

        public CondicaoPagamento GetCondicaoPagamento(string id) {
            try {
                return dbCondicao.ConsultaCondicaoPagamento(id);
            } catch (Exception) {
                CondicaoPagamento vazio = new CondicaoPagamento();
                return vazio;
            }
        }

        public List<CondicaoPagamento> GetListaCondicoesPagamento() {
            try {
                return dbCondicao.GetListaCondicoesPagamento();
            } catch (Exception) {
                List<CondicaoPagamento> ListaVazio = new List<CondicaoPagamento>();

                return ListaVazio;
            }
        }

        public List<CondicaoPagamento> GetListaCondicoesPagamentoAtualizados(string data) {
            try {
                return dbCondicao.GetListaCondicoesPagamentoAtualizadas(data);
            } catch (Exception) {
                List<CondicaoPagamento> ListaVazio = new List<CondicaoPagamento>();

                return ListaVazio;
            }
        }

        public CondicaoPagamento AddCondicaoPagamento(CondicaoPagamento condicaoPagamento) {
            CondicaoPagamento consultaExiste = new CondicaoPagamento(); ;
            try {
                //consultaExiste = dbTabelaPrecos.ConsultaSegmentoMercado(segmentoMercado.ID);

                if (consultaExiste.ID == null) {
                    CondicaoPagamento cadastrado = dbCondicao.AddCondicaoPagamento(condicaoPagamento);

                    return cadastrado;
                } else {
                    return consultaExiste;
                }

            } catch (Exception) {
                return consultaExiste;
            }

        }

        public CondicaoPagamento EditaCondicaoPagamento(CondicaoPagamento condicaoPagamento) {
            CondicaoPagamento consultaExiste = new CondicaoPagamento(); ;
            try {
                //consultaExiste = dbTabelaPrecos.ConsultaSegmentoMercado(segmentoMercado.ID);

                if (consultaExiste.ID == null) {
                    CondicaoPagamento editado = dbCondicao.EditarCondicaoPagamento(condicaoPagamento);

                    return editado;
                } else {
                    return consultaExiste;
                }

            } catch (Exception) {
                return consultaExiste;
            }
        }

    }
}
