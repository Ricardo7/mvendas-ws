using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class ClienteDTO
    {
        public int ID { get; set; }
        public string Segmento { get; set; }
        public int Cnpj { get; set; }
        public string Razao_Social { get; set; }
        public string Nome_Fan { get; set; }
        public int Ins_Est { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public DateTime Dt_Criacao { get; set; }
        public DateTime Dt_Atualizacao { get; set; }
        public string Status { get; set; }
        public int Ativo { get; set; }
    }
}