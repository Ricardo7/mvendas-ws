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

        public SugestaoApplication() {
            dbUsuario = new UsuarioRepository();
            dbPedido = new PedidoRepository();
            dbProduto = new ProdutoRepository();
            dbAtividade = new AtividadeRepository();
            dbCliente = new ClienteRepository();
        }

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

                    if (existe.Equals(0)) {
                        ListaProdutos.Add(produto);
                    }
                }
            }

            if (ListaProdutos.Count == 0) {
                ProdutoRepository dbProduto = new ProdutoRepository();
                List<Produto> ListaProdutosTemp = dbProduto.GetListaProdutos();
                ListaProdutos.Add(ListaProdutosTemp.Last());
                ListaProdutos.Add(ListaProdutosTemp[0]);
                ListaProdutos.Add(ListaProdutosTemp[1]);
            }

            return ListaProdutos;
        }

        public List<Atividade> GetListaAtividadesSugeridas(string data, string idUsuario) {

            List<Atividade> ListaAtividades = new List<Atividade>();

            ////////////////Lista de Clientes que não foram visitados
            List<Atividade> ListaAtividadesFeitas = new List<Atividade>();
            ListaAtividadesFeitas = dbAtividade.GetListaAtividadesUsuario(idUsuario);
            List<Cliente> ListaClientesUsuario = new List<Cliente>();
            ListaClientesUsuario = dbCliente.GetListaClientes(idUsuario);

            List<Cliente> ListaClientesNaoVisitados = new List<Cliente>();

            foreach (Atividade atividade in ListaAtividadesFeitas) {

                Cliente clienteVisitado = atividade.ClienteAtividade;

                foreach (Cliente cliente in ListaClientesUsuario) {
                    
                    if (clienteVisitado.ID != cliente.ID) {

                        int existe = 0;

                        foreach (Cliente teste in ListaClientesNaoVisitados) {
                            if (teste.ID == cliente.ID) {
                                existe = 1;
                            }
                        }

                        if (existe == 0) {
                            ListaClientesNaoVisitados.Add(cliente);
                        }
                    }
                }
            }

            if (ListaAtividadesFeitas.Count()== 0) {
                ListaClientesNaoVisitados.Add(ListaClientesUsuario.FirstOrDefault());
            }

            ////////////////Lista de Clientes que não compraram
            List<Pedido> ListaPedidosUsuario = new List<Pedido>();
            ListaPedidosUsuario = dbPedido.GetListaPedidos(idUsuario);

            List<Cliente> ListaClientesNaoCompram = new List<Cliente>();

            foreach (Pedido pedido in ListaPedidosUsuario) {

                Cliente clienteComprou = pedido.ClientePedido;

                foreach (Cliente cliente in ListaClientesUsuario) {

                    if (clienteComprou.ID != cliente.ID) {

                        int existe = 0;

                        foreach (Cliente teste in ListaClientesNaoCompram) {
                            if (teste.ID == cliente.ID) {
                                existe = 1;
                            }
                        }

                        if (existe == 0) {
                            ListaClientesNaoCompram.Add(cliente);
                        }
                    }
                }
            }

            if (ListaPedidosUsuario.Count() == 0) {
                ListaClientesNaoCompram = ListaClientesUsuario;
            }

            ////////////////////Gera as atividades
            if ((ListaClientesNaoCompram.Count() != 0) && (data == "2018-12-01")) {

                Atividade atividade = new Atividade() {
                    Assunto = "Este cliente ainda não tem nenhuma compra registrada, que tal visita-lo?",
                    Observacao = "Veja o motivo dele não estar comprando!",
                    ClienteAtividade = ListaClientesNaoCompram.Last(),
                    UsuarioAtividade = ListaClientesNaoCompram.Last().UsuarioCliente,
                    DataAtividade = "2018-12-01",
                    HoraAtividade = "09:00",
                };
                ListaAtividades.Add(atividade);
            }

            if ((ListaClientesNaoVisitados.Count() != 0) && (data == "2018-12-03")) {

                Atividade atividade = new Atividade() {
                    Assunto = "Este cliente ainda não foi visitado, que tal visita-lo?",
                    Observacao = "Uma visita pode ser uma boa forma de iniciar uma venda!",
                    ClienteAtividade = ListaClientesNaoVisitados.Last(),
                    UsuarioAtividade = ListaClientesNaoVisitados.Last().UsuarioCliente,
                    DataAtividade = "2018-12-03",
                    HoraAtividade = "09:00",
                };

                ListaAtividades.Add(atividade);
            }

            //string dtTemp = "2018-12-05";
            if ((ListaPedidosUsuario.Count() != 0) & (data.Equals("2018-12-05"))) {
            //if (data.Equals(dtTemp)) {


                    Atividade atividade = new Atividade() {
                    Assunto = "Este cliente costuma comprar neste período, que tal visita-lo?",
                    Observacao = "Uma visita no tempo certo é !",
                    ClienteAtividade = ListaPedidosUsuario.Last().ClientePedido,
                    UsuarioAtividade = ListaPedidosUsuario.Last().ClientePedido.UsuarioCliente,
                    DataAtividade = "2018-12-05",
                    HoraAtividade = "09:00",
                };

                ListaAtividades.Add(atividade);

            }

            return ListaAtividades;
        }

    }
}

