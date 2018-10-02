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
    public class ProdutoController : ApiController
    {
        public ProdutoApplication produtoApplication;

        public ProdutoController() {
            produtoApplication = new ProdutoApplication();
        }

        [HttpPost]
        [Route("api/Produto/AddProduto")]
        public ProdutoDTO AddProduto(Produto produto) {
            Produto produtoCadastrado = produtoApplication.AddProduto(produto);

            if (produtoCadastrado != null) {
                return RetornoController.MontaRetornoProduto(200, "SUCCESS", "", produtoCadastrado);
            } else {
                return RetornoController.MontaRetornoProduto(401, "ERROR", "", null);
            }

        }

        [HttpPut]
        [Route("api/Produto/EditaProduto")]
        public ProdutoDTO Editaproduto(Produto produto) {
            Produto produtoCadastrado = produtoApplication.EditarProduto(produto);

            if (produtoCadastrado != null) {
                return RetornoController.MontaRetornoProduto(200, "SUCCESS", "", produtoCadastrado);
            } else {
                return RetornoController.MontaRetornoProduto(401, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Produto/GetProduto")]
        public ProdutoDTO GetProduto(string id) {
            Produto produtoConsulta = new Produto {
                ID = id,
            };

            Produto produtoRetorno = produtoApplication.GetProduto(produtoConsulta);

            if (produtoRetorno != null) {
                return RetornoController.MontaRetornoProduto(200, "SUCCESS", "", produtoRetorno);
            } else {
                return RetornoController.MontaRetornoProduto(401, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Produto/GetListaProdutos")]
        public ListaProdutosDTO GetListaProdutos() {
            List<Produto> ListaTemp = produtoApplication.GetListaProdutos();

            if (ListaTemp != null) {
                return RetornoController.MontaRetornoListaProdutos(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaProdutos(401, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Produto/GetListaProdutosAtualizados")]
        public ListaProdutosDTO GetListaAtualizados(string dataAt) {
            List<Produto> ListaTemp = produtoApplication.GetListaProdutosAtualizados(dataAt);

            if (ListaTemp != null) {
                return RetornoController.MontaRetornoListaProdutos(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaProdutos(401, "ERROR", "", null);
            }

        }

    }

}
