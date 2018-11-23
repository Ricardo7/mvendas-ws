using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain;
using MongoDB.Driver;

namespace Application {
    public class ClienteApplication {
        private ClienteRepository dbCliente;
        private UsuarioRepository dbUsuario;

        public ClienteApplication() {
            dbCliente = new ClienteRepository();
            dbUsuario = new UsuarioRepository();
        }

        public Cliente GetCliente(Cliente cliente) {
            try {
                return dbCliente.ConsultaCliente(cliente);
            } catch (Exception) {
                Cliente vazio = new Cliente();
                return vazio;
            }
        }

        public List<Cliente> GetListaClientes(string UsuarioID, int origem)
        {
            Usuario usuario = dbUsuario.ConsultaUsuarioID(UsuarioID);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            List<Cliente> clientes = null;
            try {
                clientes = new List<Cliente>();
                
                //Testa se é usuário Adminstrador(1) e se a origem é Portal(1), se for retorna todos os dados, senão retorna somente os dados relacionados ao usuário.
                if (usuario.Tipo == 1 && origem == 1)
                {
                    clientes = dbCliente.GetListaClientesAdm();
                }
                else
                {
                    clientes = dbCliente.GetListaClientes(UsuarioID);
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return clientes;
        }

        public List<Cliente> GetListaClientesAtualizados(string data, string UsuarioID, int origem)
        {

            Usuario usuario = dbUsuario.ConsultaUsuarioID(UsuarioID);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            List<Cliente> clientes = null;
            try
            {
                clientes = new List<Cliente>();

                //Testa se é usuário Adminstrador(1) se for retorna todos os dados, senão retorna somente os dados relacionados ao usuário.
                if (usuario.Tipo == 1 && origem == 1)
                {
                    clientes = dbCliente.GetListaClientesAtualizadosAdm(data);
                }
                else
                {
                    clientes = dbCliente.GetListaClientesAtualizados(data,UsuarioID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return clientes;
        }

        public Cliente AddCliente(Cliente cliente) {
            Cliente consultaExiste=null;
            try {

                consultaExiste = dbCliente.ConsultaCnpjExiste(cliente);

                if (consultaExiste == null) {
                    Cliente cadastrado = dbCliente.AddCliente(cliente);

                    return cadastrado;
                } else {
                    throw new Exception("CNPJ já cadastrado");
                }
                
            } catch (Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public Cliente EditarCliente(Cliente cliente) {
            Cliente consultaExiste = null;
            try {
                consultaExiste = dbCliente.ConsultaCliente(cliente);

                if (consultaExiste != null) {
                    Cliente editado = dbCliente.EditarCliente(cliente);
                    return editado;

                } else {
                    return null;
                }

            } catch (Exception) {
                return null;
            }
        }

        public Boolean AlterarStatusCliente(Cliente cliente) {
            try {
                dbCliente.AlterarStatusCliente(cliente);
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public Boolean AlterarEnderecoCliente(Cliente cliente) {
            try {
                dbCliente.AlterarEnderecoCliente(cliente);
                return true;
            } catch (Exception) {
                return false;
            }
        }
    }
}
