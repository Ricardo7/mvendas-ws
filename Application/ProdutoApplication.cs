using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain;
using MongoDB.Driver;

namespace Application {
    public class ProdutoApplication {

        private ProdutoRepository dbProduto;

        public ProdutoApplication() {
            dbProduto = new ProdutoRepository();
        }

        public Produto GetProduto(Produto produto) {
            try {
                return dbProduto.ConsultaProduto(produto);
            } catch (Exception) {
                Produto vazio = new Produto();
                return vazio;
            }
        }

        public List<Produto> GetListaProdutoss() {
            try {
                return dbProduto.GetListaProdutos();
            } catch (Exception) {
                List<Produto> ListaProdutosvazio = new List<Produto>();

                return ListaProdutosvazio;
            }
        }

        public Produto Addproduto(Produto produto) {
            Produto consultaExiste = new Produto(); ;
            try {
                consultaExiste = new Produto();
                consultaExiste = dbProduto.ConsultaProduto(produto);

                if (consultaExiste == null) {
                    dbProduto.AddProduto(produto);
                    Produto cadastrado;
                    cadastrado = dbProduto.ConsultaProduto(produto);

                    return cadastrado;
                } else {
                    return consultaExiste;
                }
                
            } catch (Exception) {
                return consultaExiste;
            }
        }

    }
}
