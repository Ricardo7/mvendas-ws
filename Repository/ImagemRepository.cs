using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Domain;
using MongoDB.Bson;

namespace Repository {
    public class ImagemRepository {
        public List<Imagem> GetListaImagens() {

            List<Imagem> listaImagens = new List<Imagem>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Imagem>("imagens");

            var filtro = Builders<Imagem>.Filter.Empty;

            var imagens = colecao.Find(filtro).ToList();

            listaImagens = imagens;

            return listaImagens;

        }

        public List<Imagem> GetListaImagensAtualizados(string data) {

            List<Imagem> listaImagens = new List<Imagem>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Imagem>("imagens");

            var filtro = Builders<Imagem>.Filter.Gt(u => u.DtAtualizacao, data);

            var imagens = colecao.Find(filtro).ToList();

            listaImagens = imagens;

            return listaImagens;

        }

        public List<Imagem> GetListaImagensProduto(string produtoID) {

            List<Imagem> listaImagens = new List<Imagem>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Imagem>("imagens");

            var filtro = Builders<Imagem>.Filter.Where(u => u.ProdutoID == produtoID);

            var imagens = colecao.Find(filtro).ToList();

            listaImagens = imagens;

            return listaImagens;

        }

        public Imagem AddImagem(Imagem imagem) {

            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            imagem.ID = identidade.ToString();
            imagem._id = identidade;

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Imagem>("imagens");

            colecao.InsertOne(imagem);

            return imagem;
        }

        public Imagem ConsultaImagem(string ID) {
            Imagem imagemPesquisado = new Imagem();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Imagem>("imagens");

            var filtro = Builders<Imagem>.Filter.Where(u => u.ID == ID);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            imagemPesquisado = (Imagem)retorno;

            return imagemPesquisado;

        }

        public Imagem EditarImagem(Imagem imagem) {
            Imagem imagemPesquisado = new Imagem();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Imagem>("imagens");

            var filtro = Builders<Imagem>.Filter.Eq(u => u.ID, imagem.ID);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            imagemPesquisado = (Imagem)retorno;

            imagem._id = imagemPesquisado._id;
            imagem.ID = imagemPesquisado.ID;

            colecao.ReplaceOne(filtro, imagem, new UpdateOptions { IsUpsert = true });

            return imagem;

        }
    }
}
