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
    public class ClienteController : ApiController
    {
        public ClienteApplication clienteApplication;

        public ClienteController()
        {
            clienteApplication = new ClienteApplication();
        }

        [HttpPost]
        [Route("api/Cliente/AddCliente")]
        public bool AddCliente(ClienteDTO clienteDTO)
        {
            Cliente cliente = new Cliente
            {
                ID = clienteDTO.ID,
                Segmento = clienteDTO.Segmento,
                Cnpj = clienteDTO.Cnpj,
                Razao_Social = clienteDTO.Razao_Social,
                Nome_Fan = clienteDTO.Nome_Fan,
                Ins_Est = clienteDTO.Ins_Est,
                Cidade = clienteDTO.Cidade,
                Bairro = clienteDTO.Bairro,
                Logradouro = clienteDTO.Logradouro,
                Numero = clienteDTO.Numero,
                Dt_Criacao = clienteDTO.Dt_Criacao,
                Dt_Atualizacao = clienteDTO.Dt_Atualizacao,
                Status = clienteDTO.Status,
                Ativo = clienteDTO.Ativo
            };

            return clienteApplication.AddCliente(cliente);
        }

        [HttpGet]
        [Route("api/Cliente/GetCliente")]
        public Cliente GetCliente(int id)
        {
            Cliente clienteConsulta = new Cliente
            {
                ID = id,
            };

            return clienteApplication.GetCliente(clienteConsulta);
        }

        [HttpGet]
        [Route("api/Cliente/GetListaClientes")]
        public List<ClienteDTO> GetListaClientes()
        {
            List<Cliente> ListaTemp = clienteApplication.GetListaClientes();

            List<ClienteDTO> ListaRetorno = new List<ClienteDTO>();

            foreach (Cliente cliente in ListaTemp)
            {
                ClienteDTO clienteDTO = new ClienteDTO
                {
                    ID = cliente.ID,
                    Segmento = cliente.Segmento,
                    Cnpj = cliente.Cnpj,
                    Razao_Social = cliente.Razao_Social,
                    Nome_Fan = cliente.Nome_Fan,
                    Ins_Est = cliente.Ins_Est,
                    Cidade = cliente.Cidade,
                    Bairro = cliente.Bairro,
                    Logradouro = cliente.Logradouro,
                    Numero = cliente.Numero,
                    Dt_Criacao = cliente.Dt_Criacao,
                    Dt_Atualizacao = cliente.Dt_Atualizacao,
                    Status = cliente.Status,
                    Ativo = cliente.Ativo
                };
                ListaRetorno.Add(clienteDTO);
            }

            return ListaRetorno;
        }

        /*
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
        }*/

    }
}
