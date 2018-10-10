using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain;
using MongoDB.Driver;

namespace Application {
    public class UsuarioApplication {
        private UsuarioRepository dbUser;

        public UsuarioApplication() {
            dbUser = new UsuarioRepository();
        }

        public Usuario ValidarSenha(Usuario usuario) {
            Usuario consulta;


            try {
                consulta = dbUser.ConsultaUsuario(usuario);

            } catch (Exception) {
                return null;
            }

            try {
                if (usuario.Senha == consulta.Senha) {
                    return consulta;
                } else {
                    return null;
                }
            } catch (Exception) {
                return null;
            }
        }

        public Usuario GetUsuario(Usuario usuario) {
            try {
                return dbUser.ConsultaUsuario(usuario);
            } catch (Exception) {
                return null;
            }
        }

        public Usuario AddUsuario(Usuario usuario) {
            try {
                Usuario consultaExiste;
                consultaExiste = dbUser.ConsultaUsuario(usuario);

                if (consultaExiste == null) {
                    return dbUser.AddUsuario(usuario);                     
                } else {
                    return null;
                }

            } catch (Exception) {
                return null;
            }
        }


        public Usuario EditUsuario(Usuario usuario) {
            try {
                return dbUser.EditarUsuario(usuario);

            } catch (Exception) {
                return null;
            }
        }

        public List<Usuario> GetListaUsuarios() {
            try {
                return dbUser.GetListaUsuario();
            } catch (Exception) {
                List<Usuario> ListaUsuariosVazio = new List<Usuario>();

                return ListaUsuariosVazio;
            }
        }

    }
}
