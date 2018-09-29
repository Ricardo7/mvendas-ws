using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain{

    public class Usuario {

        [JsonIgnore]
        public ObjectId _id { get; set; }
        [JsonProperty("IDWS")]
        public string ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Ativo { get; set; }
        public string Token { get; set; }
    }
}
