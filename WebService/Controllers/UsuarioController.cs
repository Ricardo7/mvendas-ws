using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application;
using Domain;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using WebService.Models;

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
        public bool AddUsuario(UsuarioDTO usuarioDTO)
        {
            Usuario usuario = new Usuario
            {
                ID = usuarioDTO.ID,
                Nome = usuarioDTO.Nome,
                Email = usuarioDTO.Email,
                Senha = usuarioDTO.Senha,
                Ativo = usuarioDTO.Ativo
            };

            
            return usuarioApplication.AddUsuario(usuario);
        }

        [HttpGet]
        [Route("api/Usuario/ValidarUsuario")]
        public bool ValidarUsuario(string email, string senha)
        {
            Usuario usuarioConsulta = new Usuario
            {
                Email = email,
                Senha =  senha
            };
            return usuarioApplication.ValidarSenha(usuarioConsulta);
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
        public bool EditUsuario(UsuarioDTO usuarioDTO)
        {
            Usuario usuario = new Usuario
            {
                ID = usuarioDTO.ID,
                Nome = usuarioDTO.Nome,
                Email = usuarioDTO.Email,
                Senha = usuarioDTO.Senha,
                Ativo = usuarioDTO.Ativo
            };

            return usuarioApplication.EditUsuario(usuario);
        }


    }
}
