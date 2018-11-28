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
    public class ProdutoController : ApiController
    {
        public ProdutoApplication produtoApplication;
        public SugestaoApplication sugestaoApplication;

        public ProdutoController() {
            produtoApplication = new ProdutoApplication();
            sugestaoApplication = new SugestaoApplication();
        }

        [JwtAuthentication]
        [HttpPost]
        [Route("api/Produto/AddProduto")]
        public ProdutoDTO AddProduto(Produto produto) {
            Produto produtoCadastrado = produtoApplication.AddProduto(produto);

            if (produtoCadastrado != null) {
                return RetornoController.MontaRetornoProduto(200, "SUCCESS", "", produtoCadastrado);
            } else {
                return RetornoController.MontaRetornoProduto(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpPut]
        [Route("api/Produto/EditaProduto")]
        public ProdutoDTO Editaproduto(Produto produto) {
            Produto produtoCadastrado = produtoApplication.EditarProduto(produto);

            if (produtoCadastrado != null) {
                return RetornoController.MontaRetornoProduto(200, "SUCCESS", "", produtoCadastrado);
            } else {
                return RetornoController.MontaRetornoProduto(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Produto/GetProduto")]
        public ProdutoDTO GetProduto(string id) {

            Produto produtoRetorno = produtoApplication.GetProduto(id);

            if (produtoRetorno != null) {
                return RetornoController.MontaRetornoProduto(200, "SUCCESS", "", produtoRetorno);
            } else {
                return RetornoController.MontaRetornoProduto(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Produto/GetListaProdutos")]
        public ListaProdutosDTO GetListaProdutos() {
            List<Produto> ListaTemp = produtoApplication.GetListaProdutos();

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaProdutos(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaProdutos(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Produto/GetListaProdutosAtualizados")]
        public ListaProdutosDTO GetListaAtualizados(string dataAt) {
            List<Produto> ListaTemp = produtoApplication.GetListaProdutosAtualizados(dataAt);

            if (ListaTemp.Count() != 0) {
                
                return RetornoController.MontaRetornoListaProdutos(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaProdutos(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Produto/GetListaProdutosSugeridos")]
        public ListaProdutosDTO GetListaProdutosSugeridos(String idCliente) {
            List<Produto> ListaTemp = sugestaoApplication.GetListaProdutosSugeridos(idCliente);

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaProdutos(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaProdutos(200, "ERROR", "", null);
            }
        }

    }

}
