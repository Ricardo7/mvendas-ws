using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Domain;
using MongoDB.Bson;

namespace Repository {
    public class ConfiguracoesRepository {

        public List<Configuracoes> GetListaConfiguracoes() {

            List<Configuracoes> lista = null;
            try
            {
                lista = new List<Configuracoes>();

                var conexao = new MongoClient(Conexao.CONEXAO);

                var db = conexao.GetDatabase(Conexao.DB);

                var colecao = db.GetCollection<Configuracoes>("configuracoes");

                var filtro = Builders<Configuracoes>.Filter.Empty;

                var retorno = colecao.Find(filtro).ToList();

                lista = retorno;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lista;

        }

        public Configuracoes ConsultaConfiguracao()
        {
            Configuracoes ConfiguracoesPesquisada = null;

            try
            {
                ConfiguracoesPesquisada = new Configuracoes();
                var conexao = new MongoClient(Conexao.CONEXAO);

                var db = conexao.GetDatabase(Conexao.DB);

                var colecao = db.GetCollection<Configuracoes>("configuracoes");

                var filtro = Builders<Configuracoes>.Filter.Empty;

                var retorno = colecao.Find(filtro).Limit(1).FirstOrDefault();
                //var retorno = colecao.Find(x => true).SortByDescending(u => u.ID).Limit(1).FirstOrDefaultAsync();

                ConfiguracoesPesquisada = (Configuracoes)retorno;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ConfiguracoesPesquisada;

        }

        public Configuracoes AddConfiguracoes(Configuracoes configuracoes) {

            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            configuracoes.ID = identidade.ToString();
            configuracoes._id = identidade;

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Configuracoes>("configuracoes");

            colecao.InsertOne(configuracoes);

            return configuracoes;
        }

        public Configuracoes ConsultaConfiguracoes(string ID) {
            Configuracoes ConfiguracoesPesquisada = new Configuracoes();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Configuracoes>("configuracoes");

            var filtro = Builders<Configuracoes>.Filter.Where(u => u.ID == ID);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            ConfiguracoesPesquisada = (Configuracoes)retorno;

            return ConfiguracoesPesquisada;

        }

        public Configuracoes EditarConfiguracoes(Configuracoes configuracoes) {
            Configuracoes configuracoesPesquisada = new Configuracoes();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Configuracoes>("configuracoes");

            var filtro = Builders<Configuracoes>.Filter.Eq(u => u.ID, configuracoes.ID);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            configuracoesPesquisada = (Configuracoes)retorno;

            configuracoes._id = configuracoesPesquisada._id;
            configuracoes.ID = configuracoesPesquisada.ID;

            colecao.ReplaceOne(filtro, configuracoes, new UpdateOptions { IsUpsert = true });

            return configuracoes;

        }

    }
}
