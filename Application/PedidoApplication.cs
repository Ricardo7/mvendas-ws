using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain;
using MongoDB.Driver;

namespace Application {
    public class PedidoApplication {
        private PedidoRepository dbPedido;

        public PedidoApplication() {
            dbPedido = new PedidoRepository();
        }

        public Pedido GetPedido(string id) {
            try {
                return dbPedido.ConsultaPedido(id);
            } catch (Exception) {
                Pedido vazio = new Pedido();
                return vazio;
            }
        }

        public List<Pedido> GetListaPedido() {
            try {
                return dbPedido.GetListaPedidos();
            } catch (Exception) {
                List<Pedido> ListaVazio = new List<Pedido>();

                return ListaVazio;
            }
        }

        public List<Pedido> GetListaPedidosAtualizados(string data) {
            try {
                return dbPedido.GetListaPedidosAtualizados(data);
            } catch (Exception) {
                List<Pedido> ListaVazio = new List<Pedido>();

                return ListaVazio;
            }
        }

        public Pedido AddPedido(Pedido pedido) {
            Pedido consultaExiste = new Pedido(); ;
            try {
                //consultaExiste = dbTabelaPrecos.ConsultaSegmentoMercado(segmentoMercado.ID);
                consultaExiste = null;

                if (consultaExiste == null) {
                    Pedido cadastrado = dbPedido.AddPedido(pedido);

                    return cadastrado;
                } else {
                    return null;
                }

            } catch (Exception) {
                return null;
            }

        }

        public Pedido EditaPedido(Pedido pedido) {
            Pedido consultaExiste = new Pedido(); ;
            try {
                //consultaExiste = dbPedido.EditarPedido(pedido);
                consultaExiste = null;

                if (consultaExiste == null) {
                    Pedido editado = dbPedido.EditarPedido(pedido);

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
