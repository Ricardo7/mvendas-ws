using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain {
    public class Atividade {
        [JsonIgnore]
        public ObjectId _id { get; set; }
        [JsonProperty("IDAP")]
        public int IDAP { get; set; }
        [JsonProperty("IDWS")]
        public string ID { get; set; }
        public string Assunto { get; set; }
        public string Observacao { get; set; }
        [JsonProperty("Cliente")]
        public Cliente ClienteAtividade { get; set; }
        [JsonProperty("Usuario")]
        public Usuario UsuarioAtividade { get; set; }
        public string DataAtividade { get; set; }
        public string HoraAtividade { get; set; }
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
        public string DataCheckin { get; set; }
        public string DtCadastro { get; set; }
        public string DtAtualizacao { get; set; }
    }
}
