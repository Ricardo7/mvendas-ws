using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain {

    public class ItemTabelaPreco {

        [JsonIgnore]
        public ObjectId _id { get; set; }
        public string ID { get; set; }
        public double VlrUnitario { get; set; }
        public double MaxDesconto { get; set; }
        [JsonProperty("Produto")]
        public Produto ProdutoTabelaPreco { get; set; }
    }
}
