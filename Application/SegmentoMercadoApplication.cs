using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain;
using MongoDB.Driver;

namespace Application {
    public class SegmentoMercadoApplication {
        private SegmentoMercadoRepository dbSegmento;

        public SegmentoMercadoApplication() {
            dbSegmento = new SegmentoMercadoRepository();
        }

        public SegmentoMercado GetSegmentoMercado(string id) {
            try {
                return dbSegmento.ConsultaSegmentoMercado(id);
            } catch (Exception) {
                SegmentoMercado vazio = new SegmentoMercado();
                return vazio;
            }
        }

        public List<SegmentoMercado> GetListaSegmentosMercado() {
            try {
                return dbSegmento.GetListaSegmentosMercado();
            } catch (Exception) {
                List<SegmentoMercado> ListaVazio = new List<SegmentoMercado>();

                return ListaVazio;
            }
        }

        public List<SegmentoMercado> GetListaSegmentosMercadoAtualizados(string data) {
            try {
                return dbSegmento.GetListaSegmentosMercadoAtualizados(data);
            } catch (Exception) {
                List<SegmentoMercado> ListaVazio = new List<SegmentoMercado>();

                return ListaVazio;
            }
        }

        public SegmentoMercado AddSegmentoMercado(SegmentoMercado segmentoMercado) {
            SegmentoMercado consultaExiste;
            try {
                //consultaExiste = dbSegmento.ConsultaSegmentoMercado(segmentoMercado.ID);
                consultaExiste = null;
                if (consultaExiste == null) {
                    SegmentoMercado cadastrado = dbSegmento.AddSegmentoMercado(segmentoMercado);

                    return cadastrado;
                } else {
                    return null;
                }

            } catch (Exception) {
                return null;
            }
        }
    }
}
