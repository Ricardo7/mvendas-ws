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
            Cliente consultaExiste = new Cliente(); ;
            try {
                consultaExiste = new Cliente();
               // consultaExiste = dbCliente.ConsultaCliente(cliente);

                if (consultaExiste == null && consultaExiste.ID == null) {
                    Cliente cadastrado = dbCliente.AddCliente(cliente);

                    return cadastrado;
                } else {
                    return consultaExiste;
                }
                
            } catch (Exception) {
                return consultaExiste;
            }
        }

        public Cliente EditarCliente(Cliente cliente) {
            Cliente consultaExiste = new Cliente(); ;
            try {
                consultaExiste = dbCliente.ConsultaCliente(cliente);

                if (consultaExiste.ID == null) {
                    Cliente editado = dbCliente.EditarCliente(cliente);
                    return editado;

                } else {
                    return consultaExiste;
                }

            } catch (Exception) {
                return consultaExiste;
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
