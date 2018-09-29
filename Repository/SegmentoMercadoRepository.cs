using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Domain;
using MongoDB.Bson;

namespace Repository {
    public class SegmentoMercadoRepository {

        public List<SegmentoMercado> GetListaSegmentosMercado() {

            List<SegmentoMercado> listaSegmentosMercado = new List<SegmentoMercado>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<SegmentoMercado>("segmentosMercado");

            var filtro = Builders<SegmentoMercado>.Filter.Empty;

            var segmentosMercado = colecao.Find(filtro).ToList();

            listaSegmentosMercado = segmentosMercado;

            return listaSegmentosMercado;

        }

        public List<SegmentoMercado> GetListaSegmentosMercadoAtualizados(string data) {

            List<SegmentoMercado> listaSegmentosMercado = new List<SegmentoMercado>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<SegmentoMercado>("segmentosMercado");

            var filtro = Builders<SegmentoMercado>.Filter.Gt(u => u.DtAtualizacao, data);

            var segmentosMercado = colecao.Find(filtro).ToList();

            listaSegmentosMercado = segmentosMercado;

            return listaSegmentosMercado;

        }

        public SegmentoMercado AddSegmentoMercado(SegmentoMercado segmentoMercado) {

            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            segmentoMercado.ID = identidade.ToString();
            segmentoMercado._id = identidade;

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<SegmentoMercado>("segmentosMercado");

            colecao.InsertOne(segmentoMercado);

            return segmentoMercado;
        }

        public SegmentoMercado ConsultaSegmentoMercado(string id) {
            SegmentoMercado segmentoPesquisado = new SegmentoMercado();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<SegmentoMercado>("segmentosMercado");

            var filtro = Builders<SegmentoMercado>.Filter.Where(u => u.ID == id);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            segmentoPesquisado = (SegmentoMercado)retorno;

            return segmentoPesquisado;

        }
    }
}
