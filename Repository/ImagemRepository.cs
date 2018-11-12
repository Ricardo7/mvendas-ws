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
            try
            {
                //Gerar ID para a classe
                ObjectId identidade = ObjectId.GenerateNewId();
                imagem.ID = identidade.ToString();
                imagem._id = identidade;

                var conexao = new MongoClient(Conexao.CONEXAO);

                var db = conexao.GetDatabase(Conexao.DB);

                var colecao = db.GetCollection<Imagem>("imagens");

                colecao.InsertOne(imagem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return imagem;
        }

        public Imagem ConsultaImagem(string ID) {
            Imagem imagemPesquisado = null;
            try {
                imagemPesquisado = new Imagem();

                var conexao = new MongoClient(Conexao.CONEXAO);

                var db = conexao.GetDatabase(Conexao.DB);

                var colecao = db.GetCollection<Imagem>("imagens");

                var filtro = Builders<Imagem>.Filter.Where(u => u.ID == ID);

                var retorno = colecao.Find(filtro).FirstOrDefault();

                imagemPesquisado = (Imagem)retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return imagemPesquisado;

        }

        public Imagem EditarImagem(Imagem imagem) {
            Imagem imagemPesquisado =null;

            try {
                imagemPesquisado = new Imagem();

                var conexao = new MongoClient(Conexao.CONEXAO);

                var db = conexao.GetDatabase(Conexao.DB);

                var colecao = db.GetCollection<Imagem>("imagens");

                var filtro = Builders<Imagem>.Filter.Eq(u => u.ID, imagem.ID);

                var retorno = colecao.Find(filtro).FirstOrDefault();

                imagemPesquisado = (Imagem)retorno;

                imagem._id = imagemPesquisado._id;
                imagem.ID = imagemPesquisado.ID;

                colecao.ReplaceOne(filtro, imagem, new UpdateOptions { IsUpsert = true });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return imagem;

        }

        public bool RemoveImagem(string ID)
        {
            Imagem Pesquisado = new Imagem();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Imagem>("imagens");

            var retorno = colecao.DeleteOne(m => m.ID == ID);

            return true;

        }
    }
}
