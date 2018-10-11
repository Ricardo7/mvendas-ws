using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain {

    public class ItemPedido {

        [JsonIgnore]
        public ObjectId _id { get; set; }
        [JsonIgnore]
        public string ID { get; set; }
        public double Quantidade { get; set; }
        public double VlrUnitario { get; set; }
        public double VlrDesconto { get; set; }
        public double VlrTotal { get; set; }
        public string DtCadastro { get; set; }
        public string DtAtualizacao { get; set; }
        [JsonProperty("Produto")]
        public Produto ProdutoPedido { get; set; }

    }
}
