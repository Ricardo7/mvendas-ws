using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    public class RetornoController
    {
        /**
         * Monta o objeto Json padrão de retorno da API
         * 
         */
        public static UsuarioDTO MontaRetornoUsuario(int Cod, String Status, String Message, Usuario usuario) 
        {

            UsuarioDTO usuarioDTO = new UsuarioDTO();

            usuarioDTO.Cod = Cod;
            usuarioDTO.Status = Status;
            usuarioDTO.Message = Message;
            usuarioDTO.usuario = usuario;

            return usuarioDTO;

        }


        /**
         * Monta o objeto Json padrão de retorno da API
         * 
         */
        public static ClienteDTO MontaRetornoCliente(int Cod, String Status, String Message, Cliente cliente)
        {

            ClienteDTO clienteDTO = new ClienteDTO();

            clienteDTO.Cod = Cod;
            clienteDTO.Status = Status;
            clienteDTO.Message = Message;
            clienteDTO.cliente = cliente;

            return clienteDTO;

        }


    }
}