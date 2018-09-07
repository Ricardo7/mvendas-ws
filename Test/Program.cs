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
            Usuario usuario = new Usuario
            {
                Nome = "Juninho",
                Login = "juninho.play",
                Email = "juninho_play@fodasse.com",
                Senha = "senha",
                Posicao = "Atacante",
                PosicaoSecundaria = "Meia-Atacante"
            };

            //UsuarioRepository dbUser = new UsuarioRepository();

            //dbUser.AddUsuario(usuario);

            //List<Usuario> lista;
            //lista = dbUser.GetListaUsuario();
            //Console.WriteLine(lista[0].Nome);

           UsuarioApplication controle = new UsuarioApplication();

            controle.EditUsuario(usuario);

            Usuario teste = controle.GetUsuario(usuario);

            //Usuario teste = dbUser.ConsultaUsuario(usuario);
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


        }
    }
}
