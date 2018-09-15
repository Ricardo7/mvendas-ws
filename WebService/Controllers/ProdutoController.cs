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
    public class ProdutoController : ApiController
    {
        public ProdutoApplication produtoApplication;

        public ProdutoController() {
            produtoApplication = new ProdutoApplication();
        }

        /*
        [HttpPost]
        [Route("api/Produto/AddProduto")]
        public ProdutoDTO AddUsuario(ProdutoDTO produtoDTO) {

            return usuarioApplication.AddUsuario(usuario);
        }

        [HttpGet]
        [Route("api/Usuario/GetUsuario")]
        public Usuario GetUsuario(string email) {
            Usuario usuarioConsulta = new Usuario {
                Email = email,
            };

            return usuarioApplication.GetUsuario(usuarioConsulta);
        }

        [HttpPut]
        [Route("api/Usuario/EditUsuario")]
        public bool EditUsuario(Usuario usuario) {


            return usuarioApplication.EditUsuario(usuario);
        }*/
    
    }

}
