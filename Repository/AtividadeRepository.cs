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

        public List<Atividade> GetListaAtividades(string UsuarioID) {

            List<Atividade> lista = null;
            try {
                lista = new List<Atividade>();

                var conexao = new MongoClient(Conexao.CONEXAO);

                var db = conexao.GetDatabase(Conexao.DB);

                var colecao = db.GetCollection<Atividade>("atividades");

                //var filtro = Builders<Atividade>.Filter.Empty;
                var filtro = Builders<Atividade>.Filter.Eq(u => u.UsuarioAtividade.ID, UsuarioID);

                var retorno = colecao.Find(filtro).ToList();

                lista = retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lista;

        }

        public List<Atividade> GetListaAtividadesAdm()
        {

            List<Atividade> lista = null;
            try
            {
                lista = new List<Atividade>();

                var conexao = new MongoClient(Conexao.CONEXAO);

                var db = conexao.GetDatabase(Conexao.DB);

                var colecao = db.GetCollection<Atividade>("atividades");

                var filtro = Builders<Atividade>.Filter.Empty;

                var retorno = colecao.Find(filtro).ToList();

                lista = retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lista;

        }

        public List<Atividade> GetListaAtividadesUsuario(string usuarioID) {

            List<Atividade> lista = new List<Atividade>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Atividade>("atividades");

            var filtro = Builders<Atividade>.Filter.Where(u => u.UsuarioAtividade.ID == usuarioID);

            var retorno = colecao.Find(filtro).ToList();

            lista = retorno;

            return lista;

        }

        public List<Atividade> GetListaAtividadesCliente(string clienteID) {

            List<Atividade> lista = new List<Atividade>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Atividade>("atividades");

            var filtro = Builders<Atividade>.Filter.Where(u => u.ClienteAtividade.ID == clienteID);

            var retorno = colecao.Find(filtro).ToList();

            lista = retorno;

            return lista;

        }

        public List<Atividade> GetListaAtividadesClienteUsuario(string clienteID, string usuarioID) {

            List<Atividade> lista = new List<Atividade>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Atividade>("atividades");

            //ainda em desenvoclimento
            var filtro = Builders<Atividade>.Filter.Where(u => u.ClienteAtividade.ID == clienteID);

            var retorno = colecao.Find(filtro).ToList();

            lista = retorno;

            return lista;

        }

        public List<Atividade> GetListaAtividadesClienteCheckin(string usuarioID, string dataIni, string dataFim)
        {

            List<Atividade> lista = null;

            try
            {
                lista = new List<Atividade>();
                var conexao = new MongoClient(Conexao.CONEXAO);

                var db = conexao.GetDatabase(Conexao.DB);

                var colecao = db.GetCollection<Atividade>("atividades");

                var filtro = Builders<Atividade>.Filter.Where(u => u.UsuarioAtividade.ID == usuarioID);
                filtro = filtro & (Builders<Atividade>.Filter.Gte(u => u.DataCheckin, dataIni)); //Maior ou igual que a data inicio
                filtro = filtro & (Builders<Atividade>.Filter.Lte(u => u.DataCheckin, dataFim)); //Menor que a data Fim
                //filtro = filtro & (Builders<Atividade>.Filter.Eq(u => u.UsuarioAtividade.Tipo, 0)); //Somente usuários do tipo Vendedor (0)

                var retorno = colecao.Find(filtro).Sort(Builders<Atividade>.Sort.Ascending("HoraAtividade").Ascending("DataAtividade")).ToList();

                lista = retorno;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lista;

        }

        public List<Atividade> GetListaAtividadesAtualizadas(string data, string UsuarioID)
        {
            List<Atividade> lista = null;
            try
            {
                lista = new List<Atividade>();

                var conexao = new MongoClient(Conexao.CONEXAO);

                var db = conexao.GetDatabase(Conexao.DB);

                var colecao = db.GetCollection<Atividade>("atividades");

                var filtro = Builders<Atividade>.Filter.Gt(u => u.DtAtualizacao, data);
                filtro = filtro & (Builders<Atividade>.Filter.Eq(u => u.UsuarioAtividade.ID, UsuarioID));

                var retorno = colecao.Find(filtro).ToList();

                lista = retorno;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lista;

        }

        public List<Atividade> GetListaAtividadesAtualizadasAdm(string data)
        {
            List<Atividade> lista = null;
            try
            {
                lista = new List<Atividade>();

                var conexao = new MongoClient(Conexao.CONEXAO);

                var db = conexao.GetDatabase(Conexao.DB);

                var colecao = db.GetCollection<Atividade>("atividades");

                var filtro = Builders<Atividade>.Filter.Gt(u => u.DtAtualizacao, data);
                
                var retorno = colecao.Find(filtro).ToList();

                lista = retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
            Atividade AtividadePesquisada = null;
            try
            {
                AtividadePesquisada = new Atividade();

                var conexao = new MongoClient(Conexao.CONEXAO);

                var db = conexao.GetDatabase(Conexao.DB);

                var colecao = db.GetCollection<Atividade>("atividades");

                var filtro = Builders<Atividade>.Filter.Where(u => u.ID == ID);
                
                var retorno = colecao.Find(filtro).FirstOrDefault();

                AtividadePesquisada = (Atividade)retorno;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
