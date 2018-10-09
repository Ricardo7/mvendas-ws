using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain
{
    public class SegmentoMercado
    {
        [JsonIgnore]
        public ObjectId _id { get; set; }
        [JsonIgnore]
        public int IDAP { get; set; }
        [JsonProperty("IDWS")]
        public string ID { get; set; }
        public string Descricao { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DtCadastro { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DtAtualizacao { get; set; }
    }
}
