using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Domain;
using MongoDB.Bson;

namespace Repository {
    public class AtividadeRepository {

        public List<Atividade> GetListaAtividades() {

            List<Atividade> lista = new List<Atividade>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Atividade>("atividades");

            var filtro = Builders<Atividade>.Filter.Empty;

            var retorno = colecao.Find(filtro).ToList();

            lista = retorno;

            return lista;

        }

        public List<Atividade> GetListaAtividadesUsuario(string usuarioID) {

            List<Atividade> lista = new List<Atividade>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Atividade>("atividades");

            var filtro = Builders<Atividade>.Filter.Where(u => u.UsuarioID == usuarioID);

            var retorno = colecao.Find(filtro).ToList();

            lista = retorno;

            return lista;

        }

        public List<Atividade> GetListaAtividadesCliente(string clienteID) {

            List<Atividade> lista = new List<Atividade>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Atividade>("atividades");

            var filtro = Builders<Atividade>.Filter.Where(u => u.ClienteID == clienteID);

            var retorno = colecao.Find(filtro).ToList();

            lista = retorno;

            return lista;

        }

        public List<Atividade> GetListaAtividadesClienteUsuario(string clienteID, string usuarioID) {

            List<Atividade> lista = new List<Atividade>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Atividade>("atividades");

            //ainda em desenvoclimento kkkk
            var filtro = Builders<Atividade>.Filter.Where(u => u.ClienteID == clienteID);

            var retorno = colecao.Find(filtro).ToList();

            lista = retorno;

            return lista;

        }

        public List<Atividade> GetListaAtividadesAtualizadas(string data) {

            List<Atividade> lista = new List<Atividade>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Atividade>("atividades");

            var filtro = Builders<Atividade>.Filter.Gt(u => u.DtAtualizacao, data);

            var retorno = colecao.Find(filtro).ToList();

            lista = retorno;

            return lista;

        }

        public Atividade AddAtividade(Atividade atividade) {

            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            atividade.ID = identidade.ToString();
            atividade._id = identidade;

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Atividade>("atividades");

            colecao.InsertOne(atividade);

            return atividade;
        }

        public Atividade ConsultaAtividade(string ID) {
            Atividade AtividadePesquisada = new Atividade();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Atividade>("atividades");

            var filtro = Builders<Atividade>.Filter.Where(u => u.ID == ID);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            AtividadePesquisada = (Atividade)retorno;

            return AtividadePesquisada;

        }

        public Atividade EditarAtividade(Atividade atividade) {
            Atividade atividadePesquisada = new Atividade();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Atividade>("atividades");

            var filtro = Builders<Atividade>.Filter.Eq(u => u.ID, atividade.ID);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            atividadePesquisada = (Atividade)retorno;

            atividade._id = atividadePesquisada._id;
            atividade.ID = atividadePesquisada.ID;

            colecao.ReplaceOne(filtro, atividade, new UpdateOptions { IsUpsert = true });

            return atividade;

        }

        public bool RemoveAtividade(string ID) {
            Atividade AtividadePesquisada = new Atividade();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Atividade>("atividades");

            var retorno = colecao.DeleteOne(m => m.ID == ID);

            return true;

        }

    }
}
