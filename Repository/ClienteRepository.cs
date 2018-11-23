using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Domain;
using MongoDB.Bson;

namespace Repository {
    public class ClienteRepository {

        public List<Cliente> GetListaClientes(string usuarioID) {

            List<Cliente> listaClientes = null;
            try
            {
                listaClientes = new List<Cliente>();

                var conexao = new MongoClient(Conexao.CONEXAO);

                var db = conexao.GetDatabase(Conexao.DB);

                var colecao = db.GetCollection<Cliente>("clientes");

                //var filtro = Builders<Cliente>.Filter.Empty;
                var filtro = Builders<Cliente>.Filter.Eq(u => u.UsuarioCliente.ID, usuarioID);

                var clientes = colecao.Find(filtro).ToList();

                listaClientes = clientes;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listaClientes;

        }

        public List<Cliente> GetListaClientesAdm()
        {

            List<Cliente> listaClientes = null;
            try
            {
                listaClientes = new List<Cliente>();

                var conexao = new MongoClient(Conexao.CONEXAO);

                var db = conexao.GetDatabase(Conexao.DB);

                var colecao = db.GetCollection<Cliente>("clientes");

                var filtro = Builders<Cliente>.Filter.Empty;

                var clientes = colecao.Find(filtro).ToList();

                listaClientes = clientes;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listaClientes;

        }

        public List<Cliente> GetListaClientesAtualizados(string data, string usuarioID) {

            List<Cliente> listaClientes = null;

            try {

                listaClientes = new List<Cliente>();

                var conexao = new MongoClient(Conexao.CONEXAO);

                var db = conexao.GetDatabase(Conexao.DB);

                var colecao = db.GetCollection<Cliente>("clientes");

                var filtro = Builders<Cliente>.Filter.Gt(u => u.DtAtualizacao, data);
                filtro = filtro & (Builders<Cliente>.Filter.Eq(u => u.UsuarioCliente.ID, usuarioID));

                var clientes = colecao.Find(filtro).ToList();

                listaClientes = clientes;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listaClientes;

        }

        public List<Cliente> GetListaClientesAtualizadosAdm(string data)
        {

            List<Cliente> listaClientes = null;

            try
            {

                listaClientes = new List<Cliente>();

                var conexao = new MongoClient(Conexao.CONEXAO);

                var db = conexao.GetDatabase(Conexao.DB);

                var colecao = db.GetCollection<Cliente>("clientes");

                var filtro = Builders<Cliente>.Filter.Gt(u => u.DtAtualizacao, data);

                var clientes = colecao.Find(filtro).ToList();

                listaClientes = clientes;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listaClientes;

        }

        public Cliente AddCliente(Cliente cliente) {

            try
            {
                //Gerar ID para a classe
                ObjectId identidade = ObjectId.GenerateNewId();
                cliente.ID = identidade.ToString();
                cliente._id = identidade;

                var conexao = new MongoClient(Conexao.CONEXAO);

                var db = conexao.GetDatabase(Conexao.DB);

                var colecao = db.GetCollection<Cliente>("clientes");

                colecao.InsertOne(cliente);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cliente;
        }

        public Cliente ConsultaCliente(Cliente cliente) {
            Cliente clientePesquisado = new Cliente();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Cliente>("clientes");

            var filtro = Builders<Cliente>.Filter.Where(u => u.ID == cliente.ID);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            clientePesquisado = (Cliente)retorno;

            return clientePesquisado;

        }

        public Cliente ConsultaCnpjExiste(Cliente cliente) {
            Cliente clientePesquisado = null;
            try
            {
                clientePesquisado = new Cliente();

                var conexao = new MongoClient(Conexao.CONEXAO);

                var db = conexao.GetDatabase(Conexao.DB);

                var colecao = db.GetCollection<Cliente>("clientes");

                var filtro = Builders<Cliente>.Filter.Where(u => u.Cnpj == cliente.Cnpj);

                var retorno = colecao.Find(filtro).FirstOrDefault();

                clientePesquisado = (Cliente)retorno;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return clientePesquisado;

        }

        public Cliente EditarCliente(Cliente cliente) {
            Cliente clientePesquisado = new Cliente();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Cliente>("clientes");

            var filtro = Builders<Cliente>.Filter.Eq(u => u.ID, cliente.ID);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            clientePesquisado = (Cliente)retorno;

            cliente._id = clientePesquisado._id;
            cliente.ID = clientePesquisado.ID;

            colecao.ReplaceOne(filtro, cliente, new UpdateOptions { IsUpsert = true });

            return cliente;

        }

        public void AlterarStatusCliente(Cliente cliente) {
            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Cliente>("clientes");

            var filtro = Builders<Cliente>.Filter.Eq(u => u.ID, cliente.ID);

            var alteracao = Builders<Cliente>.Update.Set(u => u.Ativo, cliente.Ativo).Set(u => u.Status, cliente.Status).Set(u => u.DtAtualizacao, cliente.DtAtualizacao);

            colecao.UpdateOne(filtro, alteracao);
        }

        public void AlterarEnderecoCliente(Cliente cliente) {
            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Cliente>("clientes");

            var filtro = Builders<Cliente>.Filter.Eq(u => u.ID, cliente.ID);

            var alteracao = Builders<Cliente>.Update.Set(u => u.CidadeCliente, cliente.CidadeCliente).Set(u => u.Bairro, cliente.Bairro).Set(u => u.Logradouro, cliente.Logradouro).Set(u => u.Numero, cliente.Numero).Set(u => u.DtAtualizacao, cliente.DtAtualizacao);

            colecao.UpdateOne(filtro, alteracao);
        }
    }
}
