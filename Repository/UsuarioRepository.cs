using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Domain;


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

            var filtro = Builders<Usuario>.Filter.Where(u => u.Login == usuario.Login);

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

            var filtro = Builders<Usuario>.Filter.Eq(u => u.Login, usuario.Login);

            var alteracao = Builders<Usuario>.Update.Set(u => u.Senha, usuario.Senha);

            colecao.UpdateOne(filtro, alteracao);

        }

        public void EditarUsuario(Usuario usuario)
        {
            Usuario usuarioPesquisado = new Usuario();

            var conexao = new MongoClient(Conexao.CONEXAO);

            var db = conexao.GetDatabase(Conexao.DB);

            var colecao = db.GetCollection<Usuario>("usuarios");

            var filtro = Builders<Usuario>.Filter.Eq(u => u.Login, usuario.Login);

            var alteracao = Builders<Usuario>.Update.Set(u => u.Posicao, usuario.Posicao);

            //Ainda não fiz funfar pra atualizar a classe toda de uma vez...
            //colecao.ReplaceOne(filtro, usuario, new UpdateOptions { IsUpsert = true });

            colecao.UpdateOne(filtro, alteracao);

        }



    }
}
