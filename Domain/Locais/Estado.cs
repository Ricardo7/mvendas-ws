using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain
{
    public class Estado
    {
        [JsonIgnore]
        public ObjectId _id { get; set; }

        [JsonProperty("ID")]
        public int IDAP { get; set; }
        [JsonProperty("IDWS")]
        public string ID { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        [JsonProperty("Pais")]
        public Pais Pais_Estado { get; set; }
    }
}
