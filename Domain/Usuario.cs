using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;


namespace Domain
{
    public class Usuario
    {
        public ObjectId _id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int TipoUsuario { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Endereco { get; set; }
        public string Torcedor { get; set; }
        public string Posicao { get; set; }
        public string PosicaoSecundaria { get; set; }
        //public DateTime DataNascimento { get; set; }

    }
}
