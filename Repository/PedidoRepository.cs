using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Domain;
using MongoDB.Bson;


namespace Repository {
    public class PedidoRepository {

        public List<Pedido> GetListaPedidos() {

            List<Pedido> listaPedidos = new List<Pedido>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Pedido>("pedidos");

            var filtro = Builders<Pedido>.Filter.Empty;

            var pedidos = colecao.Find(filtro).ToList();

            listaPedidos = pedidos;

            return listaPedidos;

        }

        public List<Pedido> GetListaPedidosAtualizados(string data) {

            List<Pedido> listaPedidos = new List<Pedido>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Pedido>("pedidos");

            var filtro = Builders<Pedido>.Filter.Gt(u => u.DtAtualizacao, data);

            var pedidos = colecao.Find(filtro).ToList();

            listaPedidos = pedidos;

            return listaPedidos;

        }


        public Pedido AddPedido(Pedido pedido) {

            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            pedido.ID = identidade.ToString();
            pedido._id = identidade;

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Pedido>("pedidos");



            colecao.InsertOne(pedido);

            return pedido;
        }

        public Pedido ConsultaPedido(string id) {
            Pedido pedidoPesquisado = new Pedido();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Pedido>("pedidos");

            var filtro = Builders<Pedido>.Filter.Where(u => u.ID == id);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            pedidoPesquisado = (Pedido)retorno;

            return pedidoPesquisado;

        }

        public Pedido EditarPedido(Pedido pedido) {
            Pedido pedidoPesquisado = new Pedido();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Pedido>("pedidos");

            var filtro = Builders<Pedido>.Filter.Eq(u => u.ID, pedido.ID);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            pedidoPesquisado = (Pedido)retorno;

            pedido._id = pedidoPesquisado._id;
            pedido.ID = pedidoPesquisado.ID;

            colecao.ReplaceOne(filtro, pedido, new UpdateOptions { IsUpsert = true });

            return pedido;

        }

        public List<Pedido> GetListaPedidosCliente(string IDCliente) {

            List<Pedido> listaPedidos = new List<Pedido>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Pedido>("pedidos");

            var filtro = Builders<Pedido>.Filter.Where(u => u.ClientePedido.ID == IDCliente);

            var pedidos = colecao.Find(filtro).ToList();

            listaPedidos = pedidos;

            return listaPedidos;

        }


    }
}
