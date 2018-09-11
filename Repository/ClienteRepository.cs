using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Domain;

namespace Repository
{
    public class ClienteRepository
    {
        public List<Cliente> GetListaClientes()
        {

            List<Cliente> listaClientes = new List<Cliente>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Cliente>("clientes");

            var filtro = Builders<Cliente>.Filter.Empty;

            var clientes = colecao.Find(filtro).ToList();

            listaClientes = clientes;

            return listaClientes;

        }

        public void AddCliente(Cliente cliente)
        {
            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Cliente>("clientes");

            colecao.InsertOne(cliente);
        }

        public Cliente ConsultaCliente(Cliente cliente)
        {
            Cliente clientePesquisado = new Cliente();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Cliente>("clientes");

            var filtro = Builders<Cliente>.Filter.Where(u => u.ID == cliente.ID);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            clientePesquisado = (Cliente)retorno;

            return clientePesquisado;

        }

        public void AlterarStatusCliente(Cliente cliente)
        {
            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Cliente>("clientes");

            var filtro = Builders<Cliente>.Filter.Eq(u => u.ID, cliente.ID);

            var alteracao = Builders<Cliente>.Update.Set(u => u.Ativo, cliente.Ativo).Set(u => u.Status, cliente.Status).Set(u => u.DtAtualizacao, cliente.DtAtualizacao);

            colecao.UpdateOne(filtro, alteracao);
        }

        public void AlterarEnderecoCliente(Cliente cliente)
        {
            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Cliente>("clientes");

            var filtro = Builders<Cliente>.Filter.Eq(u => u.ID, cliente.ID);

            var alteracao = Builders<Cliente>.Update.Set(u => u.CidadeCliente, cliente.CidadeCliente).Set(u => u.Bairro, cliente.Bairro).Set(u => u.Logradouro, cliente.Logradouro).Set(u => u.Numero, cliente.Numero).Set(u => u.DtAtualizacao, cliente.DtAtualizacao);

            colecao.UpdateOne(filtro, alteracao);
        }
    }
}
