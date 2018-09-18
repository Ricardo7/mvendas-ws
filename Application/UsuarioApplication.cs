using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain;
using MongoDB.Driver;

namespace Application
{
    public class UsuarioApplication
    {
        private UsuarioRepository dbUser;

        public UsuarioApplication()
        {
            dbUser = new UsuarioRepository();
        }

        public Usuario ValidarSenha(Usuario usuario)
        {
            Usuario consulta;


            try
            {
                consulta = dbUser.ConsultaUsuario(usuario);
            }
            catch (Exception)
            {
                return null;
            }

            try
            {
                if (usuario.Senha == consulta.Senha)
                {
                    return consulta;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Usuario GetUsuario(Usuario usuario)
        {
            try
            {
                return dbUser.ConsultaUsuario(usuario);
            }
            catch (Exception)
            {
                Usuario vazio = new Usuario();
                return vazio;
            }
        }

        public Usuario AddUsuario(Usuario usuario)
        {
            Usuario nulo = new Usuario();
            try
            {
                Usuario consultaExiste;
                consultaExiste = dbUser.ConsultaUsuario(usuario);

                if (consultaExiste == null)
                {
                    dbUser.AddUsuario(usuario);
                    return dbUser.ConsultaUsuario(usuario);
                }
                else
                {
                    return nulo;
                }
               
            }
            catch (Exception)
            {
                return nulo;
            }
        }


        public Boolean EditUsuario(Usuario usuario)
        {
            try
            {
                  dbUser.EditarUsuario(usuario);
                  return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //public Boolean CastID(Usuario usuario)
        // {

        //    Usuario consulta;
        //    consulta = dbUser.ConsultaUsuario(usuario);

        //    string ID;
        //    ID = consulta._id.ToString();

        //    consulta._id = ID;

        //     return true;
        // }

    }
}
