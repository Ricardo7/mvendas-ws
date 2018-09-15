using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers {
    public class RetornoController {
        
        /**
         * Monta o objeto Json padrão de retorno da API
         * 
         */
        public static UsuarioDTO MontaRetornoUsuario(int Cod, String Status, String Message, Usuario usuario) {

            UsuarioDTO usuarioDTO = new UsuarioDTO();

            usuarioDTO.Cod = Cod;
            usuarioDTO.Status = Status;
            usuarioDTO.Message = Message;
            usuarioDTO.usuario = usuario;

            return usuarioDTO;

        }

        public static ListaUsuariosDTO MontaRetornoListaUsuario(int Cod, String Status, String Message, List<Usuario> usuarios) {

            ListaUsuariosDTO usuarioDTO = new ListaUsuariosDTO();

            usuarioDTO.Cod = Cod;
            usuarioDTO.Status = Status;
            usuarioDTO.Message = Message;
            usuarioDTO.usuarios = usuarios;

            return usuarioDTO;

        }

        public static ClienteDTO MontaRetornoCliente(int Cod, String Status, String Message, Cliente cliente) {

            ClienteDTO clienteDTO = new ClienteDTO();

            clienteDTO.Cod = Cod;
            clienteDTO.Status = Status;
            clienteDTO.Message = Message;
            clienteDTO.cliente = cliente;

            return clienteDTO;

        }

        public static ListaClientesDTO MontaRetornoListaClientes(int Cod, String Status, String Message, List<Cliente> clientes) {

            ListaClientesDTO clienteDTO = new ListaClientesDTO();

            clienteDTO.Cod = Cod;
            clienteDTO.Status = Status;
            clienteDTO.Message = Message;
            clienteDTO.clientes = clientes;

            return clienteDTO;

        }

        public static ProdutoDTO MontaRetornoProduto(int Cod, String Status, String Message, Produto produto) {

            ProdutoDTO produtoDTO = new ProdutoDTO();

            produtoDTO.Cod = Cod;
            produtoDTO.Status = Status;
            produtoDTO.Message = Message;
            produtoDTO.produto = produto;

            return produtoDTO;

        }

        public static ListaProdutosDTO MontaRetornoListaProdutos(int Cod, String Status, String Message, List<Produto> produtos) {

            ListaProdutosDTO produtoDTO = new ListaProdutosDTO();

            produtoDTO.Cod = Cod;
            produtoDTO.Status = Status;
            produtoDTO.Message = Message;
            produtoDTO.produtos = produtos;

            return produtoDTO;

        }

        public static PaisDTO MontaRetornoPais(int Cod, String Status, String Message, Pais pais) {

            PaisDTO paisDTO = new PaisDTO();

            paisDTO.Cod = Cod;
            paisDTO.Status = Status;
            paisDTO.Message = Message;
            paisDTO.pais = pais;

            return paisDTO;

        }

        public static ListaPaisesDTO MontaRetornoListaPaises(int Cod, String Status, String Message, List<Pais> paises) {

            ListaPaisesDTO paisDTO = new ListaPaisesDTO();

            paisDTO.Cod = Cod;
            paisDTO.Status = Status;
            paisDTO.Message = Message;
            paisDTO.paises = paises;

            return paisDTO;

        }

        public static EstadoDTO MontaRetornoEstado(int Cod, String Status, String Message, Estado estado) {

            EstadoDTO estadoDTO = new EstadoDTO();

            estadoDTO.Cod = Cod;
            estadoDTO.Status = Status;
            estadoDTO.Message = Message;
            estadoDTO.estado = estado;

            return estadoDTO;

        }

        public static ListaEstadosDTO MontaRetornoListaEstados(int Cod, String Status, String Message, List<Estado> estados) {

            ListaEstadosDTO estadoDTO = new ListaEstadosDTO();

            estadoDTO.Cod = Cod;
            estadoDTO.Status = Status;
            estadoDTO.Message = Message;
            estadoDTO.estados = estados;

            return estadoDTO;

        }

        public static CidadeDTO MontaRetornoCidade(int Cod, String Status, String Message, Cidade cidade) {

            CidadeDTO cidadeDTO = new CidadeDTO();

            cidadeDTO.Cod = Cod;
            cidadeDTO.Status = Status;
            cidadeDTO.Message = Message;
            cidadeDTO.cidade = cidade;

            return cidadeDTO;

        }

        public static ListaCidadesDTO MontaRetornoListaCidadess(int Cod, String Status, String Message, List<Cidade> cidades) {

            ListaCidadesDTO cidadesDTO = new ListaCidadesDTO();

            cidadesDTO.Cod = Cod;
            cidadesDTO.Status = Status;
            cidadesDTO.Message = Message;
            cidadesDTO.cidades = cidades;

            return cidadesDTO;

        }

    }
}