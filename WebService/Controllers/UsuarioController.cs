using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application;
using Domain;
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
        public object ValidarUsuario(string email, string senha)
        {
            
            Usuario usuarioConsulta = new Usuario
            {
                Email = email,
                Senha =  senha
            };

            Usuario usuario = usuarioApplication.ValidarSenha(usuarioConsulta);

            if (usuario != null)
            {
                //Converte o objeto interno em um DTO
                UsuarioDTO usuarioDTO = new UsuarioDTO();
                usuarioDTO.Nome = usuario.Nome;
                usuarioDTO.Email = usuario.Email;
                usuarioDTO.Senha = usuario.Senha;
                usuarioDTO.Ativo = usuario.Ativo;
                usuarioDTO.Token = "aaFF231";

                return RetornoController.MontaRetorno(200,"SUCCESS","",usuarioDTO);

            }
            else
            {
                return RetornoController.MontaRetorno(401, "ERROR", "", null);
            }

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
