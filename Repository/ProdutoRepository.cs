using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Domain;
using MongoDB.Bson;

namespace Repository {

    public class ProdutoRepository {

        public List<Produto> GetListaProdutos() {

            List<Produto> listaProdutos = new List<Produto>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Produto>("produtos");

            var filtro = Builders<Produto>.Filter.Empty;

            var produtos = colecao.Find(filtro).ToList();

            listaProdutos = produtos;

            return listaProdutos;

        }

        public void AddProduto(Produto produto) {

            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            produto.ID = identidade.ToString();
            produto._id = identidade;

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Produto>("produtos");

            colecao.InsertOne(produto);
        }

        public Produto ConsultaProduto(Produto produto) {
            Produto produtoPesquisado = new Produto();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Produto>("produtos");

            var filtro = Builders<Produto>.Filter.Where(u => u.ID == produto.ID);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            produtoPesquisado = (Produto)retorno;

            return produtoPesquisado;

        }
    }
}
