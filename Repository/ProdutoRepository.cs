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

        public List<Produto> GetListaProdutosAtualizados(string data) {

            List<Produto> listaProdutos = new List<Produto>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Produto>("produtos");

            var filtro = Builders<Produto>.Filter.Gt(u => u.DtAtualizacao, data);

            var produtos = colecao.Find(filtro).ToList();

            listaProdutos = produtos;

            return listaProdutos;

        }

        public Produto AddProduto(Produto produto) {

            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            produto.ID = identidade.ToString();
            produto._id = identidade;

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Produto>("produtos");

            colecao.InsertOne(produto);

            return produto;
        }

        public Produto ConsultaProduto(string ID) {
            Produto produtoPesquisado = new Produto();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Produto>("produtos");

            var filtro = Builders<Produto>.Filter.Where(u => u.ID == ID);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            produtoPesquisado = (Produto)retorno;

            return produtoPesquisado;

        }

        public Produto EditarProduto(Produto produto) {
            Produto produtoPesquisado = new Produto();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Produto>("produtos");

            var filtro = Builders<Produto>.Filter.Eq(u => u.ID, produto.ID);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            produtoPesquisado = (Produto)retorno;

            produto._id = produtoPesquisado._id;
            produto.ID = produtoPesquisado.ID;

            colecao.ReplaceOne(filtro, produto, new UpdateOptions { IsUpsert = true });

            return produto;

        }
    }
}
