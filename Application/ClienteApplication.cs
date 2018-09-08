using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain;
using MongoDB.Driver;

namespace Application
{
    public class ClienteApplication
    {
        private ClienteRepository dbCliente;

        public ClienteApplication()
        {
            dbCliente = new ClienteRepository();
        }

        public Cliente GetCliente(Cliente cliente)
        {
            try
            {
                return dbCliente.ConsultaCliente(cliente);
            }
            catch (Exception)
            {
                Cliente vazio = new Cliente();
                return vazio;
            }
        }

        public List<Cliente> GetListaClientes()
        {
            try
            {
                return dbCliente.GetListaClientes();
            }
            catch (Exception)
            {
                List<Cliente> ListaClientesvazio = new List<Cliente>();

                return ListaClientesvazio;
            }
        }

        public Boolean AddCliente(Cliente cliente)
        {
            try
            {
                Cliente consultaExiste;
                consultaExiste = dbCliente.ConsultaCliente(cliente);

                if (consultaExiste == null)
                {
                    dbCliente.AddCliente(cliente);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean AlterarStatusCliente(Cliente cliente)
        {
            try
            {
                dbCliente.AlterarStatusCliente(cliente);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean AlterarEnderecoCliente(Cliente cliente)
        {
            try
            {
                dbCliente.AlterarEnderecoCliente(cliente);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
