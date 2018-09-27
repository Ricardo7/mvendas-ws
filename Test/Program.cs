using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
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
            PopulaLocais popula = new PopulaLocais();
            popula.Popula();

            Produto produto = new Produto();
            */
            
            /*
            String teste1 = "2018-01-01 00:00:01";
            String teste2 = "2018-01-01 00:00:03";

            Console.WriteLine("RRRRR"+teste1.CompareTo(teste2));
            */


            /*

            Usuario usuario = new Usuario {
                _id = ObjectId.GenerateNewId(),
                Nome = "Juninho",
                Email = "juninho_play@fodasse.com",
                Senha = "senha",
                Ativo = 1
                

            };

            Console.WriteLine(usuario._id.ToString());


            UsuarioRepository dbUser = new UsuarioRepository();

            dbUser.AddUsuario(usuario);

            //dbUser.EditarUsuario(usuario2);

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
            Console.WriteLine(teste._id.ToString());
            }
            else
            {
                  Console.WriteLine("Senha Incorreta");
              }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            */
            


            /*
            Cliente cliente = new Cliente
            {
                ID = "1",
                Cnpj = "123",
                RazaoSocial = "Tabajara Corp",
                NomeFantasia = "Tabajara Corporation SA",
                Ativo = 1,
                DtCadastro = "2018-03-03 20:00:00",
                DtAtualizacao = "2018-03-03 20:00:00"
            };

            ClienteRepository dbCliente = new ClienteRepository();

            dbCliente.AddCliente(cliente);
            */
            /*
            List<Usuario> lista;
            lista = dbUser.GetListaUsuario();
            Console.WriteLine(lista[0].Nome); 

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
            */           
    

        }
    }
}
