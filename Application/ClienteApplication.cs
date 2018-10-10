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

        public ClienteApplication() {
            dbCliente = new ClienteRepository();
        }

        public Cliente GetCliente(Cliente cliente) {
            try {
                return dbCliente.ConsultaCliente(cliente);
            } catch (Exception) {
                Cliente vazio = new Cliente();
                return vazio;
            }
        }

        public List<Cliente> GetListaClientes() {
            try {
                return dbCliente.GetListaClientes();
            } catch (Exception) {
                List<Cliente> ListaClientesvazio = new List<Cliente>();

                return ListaClientesvazio;
            }
        }

        public List<Cliente> GetListaClientesAtualizados(string data) {
            try {
                return dbCliente.GetListaClientesAtualizados(data);
            } catch (Exception) {
                List<Cliente> ListaClientesvazio = new List<Cliente>();

                return ListaClientesvazio;
            }
        }

        public Cliente AddCliente(Cliente cliente) {
            Cliente consultaExiste;
            try {
                consultaExiste = dbCliente.ConsultaCnpjExiste(cliente);

                if (consultaExiste == null) {
                    Cliente cadastrado = dbCliente.AddCliente(cliente);

                    return cadastrado;
                } else {
                    //throw new Exception("Cliente já cadastrado");
                    return null;
                }
                
            } catch {
                //throw ex.Message;
                return null;
            }
        }

        public Cliente EditarCliente(Cliente cliente) {
            Cliente consultaExiste;
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
