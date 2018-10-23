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
        [JsonProperty("ID")]
        public string ID { get; set; }
        public string Assunto { get; set; }
        public string Observacao { get; set; }
        public string ClienteID { get; set; }
        public string UsuarioID { get; set; }
        public string DtAtividade { get; set; }
        public string DtCadastro { get; set; }
        public string DtAtualizacao { get; set; }
    }
}
