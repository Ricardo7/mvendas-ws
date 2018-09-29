using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain
{
    public class Cidade
    {
        [JsonIgnore]
        public ObjectId _id { get; set; }
        [JsonProperty("IDWS")]
        public string ID { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        [JsonProperty("Estado")]
        public Estado Estado_Cidade { get; set; }
        public string DtCadastro { get; set; }
        public string DtAtualizacao { get; set; }
    }
}
