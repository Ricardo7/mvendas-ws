using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain
{
    public class Cliente
    {
        [JsonIgnore]
        public ObjectId _id { get; set; }
        [JsonProperty("IDAP")]
        public int ID { get; set; }
        public string Cod { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public int Cep { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public int Status { get; set; }
        public int Ativo { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime DtAtualizacao { get; set; }
        public Cidade CidadeCliente { get; set; }
        public SegmentoMercado SegmentoMercadoCliente { get; set; }

    }
}
