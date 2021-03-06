﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application;
using Domain;
using System.Threading.Tasks;
using WebService.Filters;

namespace WebService.Controllers
{
    public class UsuarioController : ApiController
    {

        public UsuarioApplication usuarioApplication;

        public UsuarioController()
        {
            usuarioApplication = new UsuarioApplication();
        }

        [JwtAuthentication]
        [HttpPost]
        [Route ("api/Usuario/AddUsuario")]
        public UsuarioDTO AddUsuario(Usuario usuario)
        {

            Usuario usuarioAdicionado = null;
            try
            {
                usuarioAdicionado = usuarioApplication.AddUsuario(usuario);
            }
            catch (Exception ex)
            {
                return RetornoController.MontaRetornoUsuario(200, "ERROR", ex.Message, null);
            }

            if (usuarioAdicionado != null) {
                return RetornoController.MontaRetornoUsuario(200, "SUCCESS", "", usuario);
            } else {
                return RetornoController.MontaRetornoUsuario(200, "ERROR", "", null);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/Usuario/ValidarUsuario")]
        public UsuarioDTO ValidarUsuario(string email, string senha)
        {
            
            GeraLog.Debug("email: "+email);
            GeraLog.Debug("senha: "+senha);
            //var abc = Convert.ToString(Request.Headers["X-Auth-Token"));

            Usuario usuarioConsulta = new Usuario
            {
                Email = email,
                Senha =  senha
            };

            Usuario usuario = usuarioApplication.ValidarSenha(usuarioConsulta);

            if (usuario != null)
            {
                //Caso o usuário esteja correto irá gerar o Token para acesso
                usuario.Token = "Bearer " + JwtManager.GenerateToken(usuario.Nome,usuario.ID);
                return RetornoController.MontaRetornoUsuario(200,"SUCCESS","",usuario);
            }
            else
            {
                return RetornoController.MontaRetornoUsuario(401, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Usuario/ValidarUsuarioToken")]
        public UsuarioDTO ValidarUsuarioToken()
        {
            //string token = Request.Headers.Authorization;
            //Método utilizado para validar se o usuário está valido, utilizando o Token para isto.
            /*JwtAuthenticationAttribute jwt = new JwtAuthenticationAttribute();
            jwt.GetUserIdToken*/
            return RetornoController.MontaRetornoUsuario(200, "SUCCESS", "", null);
            
        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Usuario/GetUsuario")]
        public UsuarioDTO GetUsuario(string email)
        {
            Usuario usuarioConsulta = new Usuario
            {
                Email = email,
            };

            Usuario usuario = usuarioApplication.GetUsuario(usuarioConsulta);

            if (usuario != null) {
                return RetornoController.MontaRetornoUsuario(200, "SUCCESS", "", usuario);
            } else {
                return RetornoController.MontaRetornoUsuario(200, "ERROR", "", null);
            }
        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Usuario/GetUsuarioID")]
        public UsuarioDTO GetUsuarioID(string ID) {

            Usuario usuario = usuarioApplication.GetUsuarioID(ID);

            if (usuario != null) {
                return RetornoController.MontaRetornoUsuario(200, "SUCCESS", "", usuario);
            } else {
                return RetornoController.MontaRetornoUsuario(200, "ERROR", "", null);
            }
        }

        [JwtAuthentication]
        [HttpPut]
        [Route("api/Usuario/EditUsuario")]
        public UsuarioDTO EditUsuario(Usuario usuario)
        {
            Usuario usuarioEditado = usuarioApplication.EditUsuario(usuario);

            if (usuarioEditado != null) {
                return RetornoController.MontaRetornoUsuario(200, "SUCCESS", "", usuario);
            } else {
                return RetornoController.MontaRetornoUsuario(200, "ERROR", "", null);
            }
        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Usuario/ListaUsuarios")]
        public ListaUsuariosDTO ListaUsuarios() {

            List<Usuario> lista = usuarioApplication.GetListaUsuarios();

            if (lista.Count() != 0) {
                return RetornoController.MontaRetornoListaUsuario(200, "SUCCESS", "", lista);
            } else {
                return RetornoController.MontaRetornoListaUsuario(200, "ERROR", "", null);
            }

        }


    }
}
