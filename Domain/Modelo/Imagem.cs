﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain {

    public class Imagem {

        [JsonIgnore]
        public ObjectId _id { get; set; }
        [JsonProperty("ID")]
        public string ID { get; set; }
        public string ProdutoID { get; set; }
        public string Nome { get; set; }
        public string Caminho { get; set; }
        public int Tamanho { get; set; }
        public string DtCriacao { get; set; }
        public string DtAtualizacao { get; set; }

    }
}
