using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Domain;
using MongoDB.Bson;


namespace Repository
{
    public class UsuarioRepository
    {
        public List<Usuario> GetListaUsuario()
        {

            List<Usuario> listaUsuarios = new List<Usuario>();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Usuario>("usuarios");

            var filtro = Builders<Usuario>.Filter.Empty;

            var usuarios = colecao.Find(filtro).ToList();

            listaUsuarios = usuarios;

            return listaUsuarios;

        }

        public void AddUsuario(Usuario usuario)
        {
            //Gerar ID para a classe
            ObjectId identidade = ObjectId.GenerateNewId();
            usuario.ID = identidade.ToString();
            usuario._id = identidade;
            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Usuario>("usuarios");

            colecao.InsertOne(usuario);

        }

        public Usuario ConsultaUsuario(Usuario usuario)
        {
            Usuario usuarioPesquisado = new Usuario();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Usuario>("usuarios");

            var filtro = Builders<Usuario>.Filter.Where(u => u.Email == usuario.Email);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            usuarioPesquisado = (Usuario)retorno;

            return usuarioPesquisado;

        }

        public void EditarSenhaUsuario(Usuario usuario)
        {
            Usuario usuarioPesquisado = new Usuario();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Usuario>("usuarios");

            var filtro = Builders<Usuario>.Filter.Eq(u => u.Email, usuario.Email);

            var alteracao = Builders<Usuario>.Update.Set(u => u.Senha, usuario.Senha);

            colecao.UpdateOne(filtro, alteracao);

        }

        public Usuario EditarUsuario(Usuario usuario)
        {
            Usuario usuarioPesquisado = new Usuario();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Usuario>("usuarios");

            var filtro = Builders<Usuario>.Filter.Eq(u => u.Email, usuario.Email);

            //var alteracao = Builders<Usuario>.Update.Set(u => u.Nome, usuario.Nome).Set(u => u.Ativo, usuario.Ativo);

            //colecao.UpdateOne(filtro, alteracao);

            var retorno = colecao.Find(filtro).FirstOrDefault();

            usuarioPesquisado = (Usuario)retorno;

            usuario._id = usuarioPesquisado._id;

            colecao.ReplaceOne(filtro, usuario, new UpdateOptions { IsUpsert = true } );

            return usuario;

        }        
    }
}
