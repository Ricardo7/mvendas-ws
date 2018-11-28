using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain;
using MongoDB.Driver;

namespace Application {
    public class SugestaoApplication {
        private UsuarioRepository dbUsuario;
        private PedidoRepository dbPedido;
        private ProdutoRepository dbProduto;
        private AtividadeRepository dbAtividade;
        private ClienteRepository dbCliente;

        public List<Produto> GetListaProdutosSugeridos(string idCliente) {

            List<Pedido> ListaPedidos = new List<Pedido>();
            try {
                ListaPedidos = dbPedido.GetListaPedidosCliente(idCliente);
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

        public List<Atividade> GetListaAtividadesSugeridas(string idCliente, string idUsuario) {

            List<Atividade> ListaAtividades = new List<Atividade>();

            return ListaAtividades;
        }

    }
}

