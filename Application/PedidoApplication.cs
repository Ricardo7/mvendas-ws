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
        private UsuarioRepository dbUsuario;

        public PedidoApplication() {
            dbPedido = new PedidoRepository();
            dbUsuario = new UsuarioRepository();
        }

        public Pedido GetPedido(string id) {
            try {
                return dbPedido.ConsultaPedido(id);
            } catch (Exception) {
                Pedido vazio = new Pedido();
                return vazio;
            }
        }

        public List<Pedido> GetListaPedido(string usuarioID, int origem)
        {
            Usuario usuario = dbUsuario.ConsultaUsuarioID(usuarioID);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            List<Pedido> pedidos = null;
            try {
                pedidos = new List<Pedido>();
                //Testa se é usuário Adminstrador(1) se for retorna todos os dados, senão retorna somente os dados relacionados ao usuário.
                if (usuario.Tipo == 1 && origem == 1)
                {
                    pedidos = dbPedido.GetListaPedidosAdm();
                }
                else
                {
                    pedidos = dbPedido.GetListaPedidos(usuarioID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return pedidos;
        }

        public List<Pedido> GetListaPedidosAtualizados(string data, string usuarioID, int origem) {

            Usuario usuario = dbUsuario.ConsultaUsuarioID(usuarioID);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            List<Pedido> pedidos = null;
            try
            {
                pedidos = new List<Pedido>();
                //Testa se é usuário Adminstrador(1) se for retorna todos os dados, senão retorna somente os dados relacionados ao usuário.
                if (usuario.Tipo == 1 && origem == 1)
                {
                    pedidos = dbPedido.GetListaPedidosAtualizadosAdm(data);
                }
                else
                {
                    pedidos = dbPedido.GetListaPedidosAtualizados(data, usuarioID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return pedidos;

        }

        public Pedido AddPedido(Pedido pedido) {
            Pedido consultaExiste = new Pedido(); ;
            try {

                //Faz a conta do Numero dos pedidos
                List<Pedido> listaPed = dbPedido.GetListaPedidosAdm();
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
        
    }
}
