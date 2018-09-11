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

        public int ID { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public Pais Pais_Estado { get; set; }
    }
}
