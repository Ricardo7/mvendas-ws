using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Domain;
using MongoDB.Bson;

namespace Repository {
    public class TabelaPrecosRepository {

        public List<TabelaPrecos> GetListaTabelasPrecos() {

            List<TabelaPrecos> listaTabelasPrecos = new List<TabelaPrecos>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<TabelaPrecos>("tabelasPrecos");

            var filtro = Builders<TabelaPrecos>.Filter.Empty;

            var retorno = colecao.Find(filtro).ToList();

            listaTabelasPrecos = retorno;

            return listaTabelasPrecos;

        }

        public List<TabelaPrecos> GetListaTabelasPrecosAtualizadas(string data) {

            List<TabelaPrecos> tabelasPrecos = new List<TabelaPrecos>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<TabelaPrecos>("tabelasPrecos");

            var filtro = Builders<TabelaPrecos>.Filter.Gt(u => u.DtAtualizacao, data);

            var retorno = colecao.Find(filtro).ToList();

            tabelasPrecos = retorno;

            return tabelasPrecos;

        }


        public TabelaPrecos AddTabelaPrecos(TabelaPrecos tabelaPrecos) {

            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            tabelaPrecos.ID = identidade.ToString();
            tabelaPrecos._id = identidade;

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<TabelaPrecos>("tabelasPrecos");

            colecao.InsertOne(tabelaPrecos);

            return tabelaPrecos;
        }

        public TabelaPrecos ConsultaTabelaPrecos(string id) {
            TabelaPrecos tabelaPrecosPesquisado = new TabelaPrecos();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<TabelaPrecos>("tabelasPrecos");

            var filtro = Builders<TabelaPrecos>.Filter.Where(u => u.ID == id);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            tabelaPrecosPesquisado = (TabelaPrecos)retorno;

            return tabelaPrecosPesquisado;

        }

        public TabelaPrecos EditarTabelaPrecos(TabelaPrecos tabelaPrecos) {
            TabelaPrecos tabelaPrecosPesquisado = new TabelaPrecos();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<TabelaPrecos>("tabelasPrecos");

            var filtro = Builders<TabelaPrecos>.Filter.Eq(u => u.ID, tabelaPrecos.ID);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            tabelaPrecosPesquisado = (TabelaPrecos)retorno;

            tabelaPrecos._id = tabelaPrecosPesquisado._id;
            tabelaPrecos.ID = tabelaPrecosPesquisado.ID;

            colecao.ReplaceOne(filtro, tabelaPrecos, new UpdateOptions { IsUpsert = true });

            return tabelaPrecos;

        }
    }
}
