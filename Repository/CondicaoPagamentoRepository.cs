using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Domain;
using MongoDB.Bson;

namespace Repository {
    public class CondicaoPagamentoRepository {

        public List<CondicaoPagamento> GetListaCondicoesPagamento() {

            List<CondicaoPagamento> listaCondicoesPagamento = new List<CondicaoPagamento>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<CondicaoPagamento>("condicoesPagamento");

            var filtro = Builders<CondicaoPagamento>.Filter.Empty;

            var condicoesPagamento = colecao.Find(filtro).ToList();

            listaCondicoesPagamento = condicoesPagamento;

            return listaCondicoesPagamento;

        }

        public List<CondicaoPagamento> GetListaCondicoesPagamentoAtualizadas(string data) {

            List<CondicaoPagamento> listaCondicoesPagamento = new List<CondicaoPagamento>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<CondicaoPagamento>("condicoesPagamento");

            var filtro = Builders<CondicaoPagamento>.Filter.Gt(u => u.DtAtualizacao, data);

            var condicoesPagamento = colecao.Find(filtro).ToList();

            listaCondicoesPagamento = condicoesPagamento;

            return listaCondicoesPagamento;

        }


        public CondicaoPagamento AddCondicaoPagamento(CondicaoPagamento condicaoPagamento) {

            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            condicaoPagamento.ID = identidade.ToString();
            condicaoPagamento._id = identidade;

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<CondicaoPagamento>("condicoesPagamento");

            colecao.InsertOne(condicaoPagamento);

            return condicaoPagamento;
        }

        public CondicaoPagamento ConsultaCondicaoPagamento(CondicaoPagamento condicaoPagamento) {
            CondicaoPagamento condicaoPagamentoPesquisado = new CondicaoPagamento();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<CondicaoPagamento>("condicoesPagamento");

            var filtro = Builders<CondicaoPagamento>.Filter.Where(u => u.ID == condicaoPagamento.ID);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            condicaoPagamentoPesquisado = (CondicaoPagamento)retorno;

            return condicaoPagamentoPesquisado;

        }

        public CondicaoPagamento EditarCondicaoPagamento(CondicaoPagamento condicaoPagamento) {
            CondicaoPagamento condicaoPagamentoPesquisado = new CondicaoPagamento();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<CondicaoPagamento>("condicoesPagamento");

            var filtro = Builders<CondicaoPagamento>.Filter.Eq(u => u.ID, condicaoPagamento.ID);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            condicaoPagamentoPesquisado = (CondicaoPagamento)retorno;

            condicaoPagamento._id = condicaoPagamentoPesquisado._id;
            condicaoPagamento.ID = condicaoPagamentoPesquisado.ID;

            colecao.ReplaceOne(filtro, condicaoPagamento, new UpdateOptions { IsUpsert = true });

            return condicaoPagamento;

        }
    }
}
