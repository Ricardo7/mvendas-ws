using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application;
using Domain;
using System.Threading.Tasks;


namespace WebService.Controllers
{
    public class UsuarioController : ApiController
    {

        public UsuarioApplication usuarioApplication;

        public UsuarioController()
        {
            usuarioApplication = new UsuarioApplication();
        }

        [HttpPost]
        [Route ("api/Usuario/AddUsuario")]
        public bool AddUsuario(Usuario usuario)
        {
            return usuarioApplication.AddUsuario(usuario);
        }

        [HttpGet]
        [Route("api/Usuario/ValidarUsuario")]
        public object ValidarUsuario(string email, string senha)
        {
            //var abc = Convert.ToString(Request.Headers["X-Auth-Token"));

            Usuario usuarioConsulta = new Usuario
            {
                Email = email,
                Senha =  senha
            };

            Usuario usuario = usuarioApplication.ValidarSenha(usuarioConsulta);

            if (usuario != null)
            {
                return RetornoController.MontaRetorno(200,"SUCCESS","",usuario);
            }
            else
            {
                return RetornoController.MontaRetorno(401, "ERROR", "", null);
            }

        }

        [HttpGet]
        [Route("api/Usuario/ValidarUsuarioToken")]
        public object ValidarUsuarioToken()
        {
            //string token = Request.Headers.Authorization;
            //Método utilizado para validar se o usuário está valido, utilizando o Token para isto.
            
            return RetornoController.MontaRetorno(200, "SUCCESS", "", null);
            
        }

        [HttpGet]
        [Route("api/Usuario/GetUsuario")]
        public Usuario GetUsuario(string email)
        {
            Usuario usuarioConsulta = new Usuario
            {
                Email = email,
            };

            return usuarioApplication.GetUsuario(usuarioConsulta);
        }

        [HttpPut]
        [Route("api/Usuario/EditUsuario")]
        public bool EditUsuario(Usuario usuario)
        {
            /*Usuario usuario = new Usuario
            {
                ID = usuarioDTO.ID,
                Nome = usuarioDTO.Nome,
                Email = usuarioDTO.Email,
                Senha = usuarioDTO.Senha,
                Ativo = usuarioDTO.Ativo
            };*/

            return usuarioApplication.EditUsuario(usuario);
        }


    }
}
