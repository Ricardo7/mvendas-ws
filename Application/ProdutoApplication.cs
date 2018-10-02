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

        public List<Produto> GetListaProdutos() {
            try {
                return dbProduto.GetListaProdutos();
            } catch (Exception) {
                List<Produto> ListaProdutosvazio = new List<Produto>();

                return ListaProdutosvazio;
            }
        }

        public List<Produto> GetListaProdutosAtualizados(string data) {
            try {
                return dbProduto.GetListaProdutosAtualizados(data);
            } catch (Exception) {
                List<Produto> ListaProdutosvazio = new List<Produto>();

                return ListaProdutosvazio;
            }
        }

        public Produto AddProduto(Produto produto) {
            Produto consultaExiste = new Produto(); ;
            try {
                consultaExiste = new Produto();
                consultaExiste = dbProduto.ConsultaProduto(produto);

                if (consultaExiste == null) {
                    Produto cadastrado = dbProduto.AddProduto(produto);
                    return cadastrado;

                } else {
                    return consultaExiste;
                }
                
            } catch (Exception) {
                return consultaExiste;
            }
        }

        public Produto EditarProduto(Produto produto) {
            Produto consultaExiste = new Produto(); ;
            try {
                consultaExiste = new Produto();
                consultaExiste = dbProduto.ConsultaProduto(produto);

                if (consultaExiste == null) {
                    Produto editado = dbProduto.EditarProduto(produto);
                    return editado;

                } else {
                    return consultaExiste;
                }

            } catch (Exception) {
                return consultaExiste;
            }
        }

    }
}
