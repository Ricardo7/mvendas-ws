using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Repository
{
    public class LocaisRepository
    {

        public List<Pais> GetListaPaises()
        {

            List<Pais> listaPaises = new List<Pais>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Pais>("paises");

            var filtro = Builders<Pais>.Filter.Empty;

            var paises = colecao.Find(filtro).ToList();

            listaPaises = paises;

            return listaPaises;

        }

        public List<Estado> GetListaEstados(String siglaPais)
        {

            List<Estado> listaEstados = new List<Estado>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Estado>("estados");

            var filtro = Builders<Estado>.Filter.Where(u => u.Pais_Estado.Sigla == siglaPais);

            var estados = colecao.Find(filtro).ToList();

            listaEstados = estados;

            return listaEstados;

        }

        public List<Cidade> GetListaCidades(String siglaEstado)
        {

            List<Cidade> listaCidades = new List<Cidade>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Cidade>("cidades");

            var filtro = Builders<Cidade>.Filter.Where(u => u.Estado_Cidade.Sigla == siglaEstado);

            var cidades = colecao.Find(filtro).ToList();

            listaCidades = cidades;

            return listaCidades;

        }

        public void AddPais(Pais pais)
        {
            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            pais.ID = identidade.ToString();
            pais._id = identidade;

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Pais>("paises");

            colecao.InsertOne(pais);
        }

        public void AddEstado(Estado estado)
        {
            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            estado.ID = identidade.ToString();
            estado._id = identidade;

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Estado>("estados");

            colecao.InsertOne(estado);
        }

        public void AddCidade(Cidade cidade)
        {
            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            cidade.ID = identidade.ToString();
            cidade._id = identidade;

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Cidade>("cidades");

            colecao.InsertOne(cidade);
        }
    }
}
