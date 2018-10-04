using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application;
using Domain;
using System.Threading.Tasks;

namespace WebService.Controllers
{
    public class PedidoController : ApiController
    {
        public PedidoApplication pedidoApplication;

        public PedidoController() {
            pedidoApplication = new PedidoApplication();
        }

        [HttpPost]
        [Route("api/Pedido/AddPedido")]
        public PedidoDTO AddPedido(Pedido pedido) {

            Pedido pedidoCadastrado = pedidoApplication.AddPedido(pedido);

            if (pedidoCadastrado.ID != null) {
                return RetornoController.MontaRetornoPedido(200, "SUCCESS", "", pedidoCadastrado);
            } else {
                return RetornoController.MontaRetornoPedido(401, "ERROR", "", null);
            }

        }

        [HttpPut]
        [Route("api/Pedido/EditaPedido")]
        public PedidoDTO EditaPedido(Pedido pedido) {
            Pedido pedidoCadastrado = pedidoApplication.EditaPedido(pedido);

            if (pedidoCadastrado.ID != null) {
                return RetornoController.MontaRetornoPedido(200, "SUCCESS", "", pedidoCadastrado);
            } else {
                return RetornoController.MontaRetornoPedido(401, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Pedido/GetPedido")]
        public PedidoDTO GetPedido(string id) {

            Pedido pedidoRetorno = pedidoApplication.GetPedido(id);

            if (pedidoRetorno.ID != null) {
                return RetornoController.MontaRetornoPedido(200, "SUCCESS", "", pedidoRetorno);
            } else {
                return RetornoController.MontaRetornoPedido(401, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Pedido/GetListaPedidos")]
        public ListaPedidosDTO GetListaPedidos() {
            List<Pedido> ListaTemp = pedidoApplication.GetListaPedido();

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaPedidos(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaPedidos(401, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Pedido/GetListaPedidosAtualizados")]
        public ListaPedidosDTO GetListaPedidosAtualizados(string dataAt) {
            List<Pedido> ListaTemp = pedidoApplication.GetListaPedidosAtualizados(dataAt);

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaPedidos(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaPedidos(401, "ERROR", "", null);
            }

        }
    }
}
