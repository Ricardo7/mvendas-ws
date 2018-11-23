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
    public class PedidoController : ApiController
    {
        public PedidoApplication pedidoApplication;

        public PedidoController() {
            pedidoApplication = new PedidoApplication();
        }

        [JwtAuthentication]
        [HttpPost]
        [Route("api/Pedido/AddPedido")]
        public PedidoDTO AddPedido(Pedido pedido) {

            Pedido pedidoCadastrado = pedidoApplication.AddPedido(pedido);

            if (pedidoCadastrado != null) {
                return RetornoController.MontaRetornoPedido(200, "SUCCESS", "", pedidoCadastrado);
            } else {
                return RetornoController.MontaRetornoPedido(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpPut]
        [Route("api/Pedido/EditaPedido")]
        public PedidoDTO EditaPedido(Pedido pedido) {
            Pedido pedidoCadastrado = pedidoApplication.EditaPedido(pedido);

            if (pedidoCadastrado != null) {
                return RetornoController.MontaRetornoPedido(200, "SUCCESS", "", pedidoCadastrado);
            } else {
                return RetornoController.MontaRetornoPedido(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Pedido/GetPedido")]
        public PedidoDTO GetPedido(string id) {

            Pedido pedidoRetorno = pedidoApplication.GetPedido(id);

            if (pedidoRetorno != null) {
                return RetornoController.MontaRetornoPedido(200, "SUCCESS", "", pedidoRetorno);
            } else {
                return RetornoController.MontaRetornoPedido(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Pedido/GetListaPedidos")]
        public ListaPedidosDTO GetListaPedidos(string usuarioID, int origem)
        {
            List<Pedido> ListaTemp = null;

            try
            {
                ListaTemp = pedidoApplication.GetListaPedido(usuarioID,origem);
            }
            catch (Exception ex)
            {
                return RetornoController.MontaRetornoListaPedidos(200, "ERROR", ex.Message, null);
            }

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaPedidos(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaPedidos(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Pedido/GetListaPedidosAtualizados")]
        public ListaPedidosDTO GetListaPedidosAtualizados(string dataAt,string usuarioID, int origem)
        {
            List<Pedido> ListaTemp = null;

            try
            {
                ListaTemp = pedidoApplication.GetListaPedidosAtualizados(dataAt,usuarioID,origem);
            }
            catch (Exception ex)
            {
                return RetornoController.MontaRetornoListaPedidos(200, "ERROR", ex.Message, null);
            }

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaPedidos(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaPedidos(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Pedido/ConsultaSugestaoProduto")]
        public ListaProdutosDTO ConsultaSugestaoProduto(Cliente cliente){
            List<Produto> ListaTemp = pedidoApplication.ConsultaSugestaoProduto(cliente);

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaProdutos(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaProdutos(200, "ERROR", "", null);
            }

        }
    }
}
