using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Domain;
using MongoDB.Bson;
using Repository;

namespace Test {
    class AddTeste {


        public void AddMeta(Meta meta) {
            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            meta.ID = identidade.ToString();
            meta._id = identidade;
            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Meta>("meta");

            colecao.InsertOne(meta);

        }

        public void AddItemTabelaPreco(ItemTabelaPreco meta) {
            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            meta.ID = identidade.ToString();
            meta._id = identidade;
            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<ItemTabelaPreco>("itemTabelaPreco");

            colecao.InsertOne(meta);

        }

        public void AddTabelaPrecos(TabelaPrecos meta) {
            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            meta.ID = identidade.ToString();
            meta._id = identidade;
            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<TabelaPrecos>("tabelaPrecos");

            colecao.InsertOne(meta);

        }

        public void AddCondicaoPagamento(CondicaoPagamento meta) {
            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            meta.ID = identidade.ToString();
            meta._id = identidade;
            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<CondicaoPagamento>("condicaoPagamento");

            colecao.InsertOne(meta);

        }

        public void AddItemPedido(ItemPedido meta) {
            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            meta.ID = identidade.ToString();
            meta._id = identidade;
            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<ItemPedido>("itemPedido");

            colecao.InsertOne(meta);

        }

        public void AddPedido(Pedido meta) {
            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            meta.ID = identidade.ToString();
            meta._id = identidade;
            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Pedido>("pedidos");

            colecao.InsertOne(meta);

        }


    }
}
