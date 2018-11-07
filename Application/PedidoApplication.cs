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

                //Faz a conta do Numero dos pedidos
                List<Pedido> listaPed = dbPedido.GetListaPedidos();
                if (listaPed.Count() == 0) {
                    pedido.Numero = 1;
                } else {
                    listaPed.OrderBy(x => x.Numero);
                    Pedido temp = listaPed.LastOrDefault();
                    pedido.Numero = temp.Numero + 1;
                }

                //Altera o Status do pedido para sinalizar que já foi sincronizado
                pedido.Status = 2;

                //Salva o Pedido na base
                Pedido cadastrado = dbPedido.AddPedido(pedido);

                return cadastrado;


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

        public List<Produto> ConsultaSugestaoProduto(Cliente cliente) {

            List<Pedido> ListaPedidos = new List<Pedido>();
            try {
                ListaPedidos = dbPedido.GetListaPedidosCliente(cliente.ID);
            } catch (Exception) {
                List<Produto> ListaVazio = new List<Produto>();

                return ListaVazio;
            }

            List<Produto> ListaProdutos = new List<Produto>();

            foreach (Pedido pedido in ListaPedidos) {
                List<ItemPedido> listaItemPedido = pedido.ListaItemPedido;

                foreach (ItemPedido item in listaItemPedido) {

                    Produto produto = item.ProdutoPedido;

                    int existe = 0;

                    foreach (Produto teste in ListaProdutos) {
                        if (teste.ID == produto.ID) {
                            existe = 1;
                        }
                    }

                    if (existe == 0) {
                        ListaProdutos.Add(produto);
                    }
                }
            }

            if (ListaProdutos.Count == 0) {
                ProdutoRepository dbProduto = new ProdutoRepository();
                List<Produto> ListaProdutosTemp = dbProduto.GetListaProdutos();
                ListaProdutos.Add(ListaProdutosTemp[0]);
            }

            return ListaProdutos;
        }
    }
}
