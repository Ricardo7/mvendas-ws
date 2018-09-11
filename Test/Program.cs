using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Domain;
using Repository;
using Application;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            /*

            Usuario usuario = new Usuario
            {
                ID = 1,
                Nome = "Juninho",
                Email = "juninho_play@fodasse.com",
                Senha = "senha",
                Ativo = 1

            };

            UsuarioRepository dbUser = new UsuarioRepository();

            dbUser.AddUsuario(usuario);

            //List<Usuario> lista;
            //lista = dbUser.GetListaUsuario();
            //Console.WriteLine(lista[0].Nome);

          // UsuarioApplication controle = new UsuarioApplication();

            //controle.EditUsuario(usuario);

            //Usuario teste = controle.GetUsuario(usuario);

            Usuario teste = dbUser.ConsultaUsuario(usuario);
            if (teste.Senha == usuario.Senha)
            {
            Console.WriteLine(teste.Nome);
             }
            else
            {
                  Console.WriteLine("Senha Incorreta");
              }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            */

            Cliente cliente = new Cliente
            {
                ID = 1,
                Cnpj = "123",
                RazaoSocial = "Tabajara Corp",
                NomeFantasia = "Tabajara Corporation SA",
                Ativo = 1
            };

            /*ClienteRepository dbCliente = new ClienteRepository();

            dbCliente.AddCliente(cliente);

            List<Usuario> lista;
            lista = dbUser.GetListaUsuario();
            Console.WriteLine(lista[0].Nome); */

            ClienteApplication controle = new ClienteApplication();

            controle.AddCliente(cliente);

            Cliente teste = controle.GetCliente(cliente);

            //Cliente teste = dbCliente.ConsultaCliente(cliente);

            if (teste.ID == cliente.ID)
            {
                Console.WriteLine(teste.NomeFantasia);
            }
            else
            {
                Console.WriteLine("Senha Incorreta");
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();



        }
    }
}
