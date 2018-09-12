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
        [JsonProperty("ID")]
        public int IDAP { get; set; }
        [JsonProperty("IDWS")]
        public int ID { get; set; }
        public string Descricao { get; set; }
    }
}
