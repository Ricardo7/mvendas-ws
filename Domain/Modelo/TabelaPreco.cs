using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain {

    public class TabelaPrecos {

        [JsonIgnore]
        public ObjectId _id { get; set; }
        [JsonProperty("IDWS")]
        public string ID { get; set; }
        public string Cod { get; set; }
        public string Descricao { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DtCriacao { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DtAtualizacao { get; set; }
        public List<ItemTabelaPreco> ItensTabelaPrecos { get; set; }
    }
}
