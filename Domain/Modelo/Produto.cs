﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain
{
    public class Produto
    {
        [JsonIgnore]
        public ObjectId _id { get; set; }
        [JsonProperty("IDWS")]
        public string ID { get; set; }
        public string Cod { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DtCadastro { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DtAtualizacao { get; set; }

    }
}
