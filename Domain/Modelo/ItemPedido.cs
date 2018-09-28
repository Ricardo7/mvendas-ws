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
        public string ID { get; set; }
        public double Quantidade { get; set; }
        public double VlrUnitario { get; set; }
        public double VlrDesconto { get; set; }
        public double VlrTotal { get; set; }
        public string DataCriacao { get; set; }
        public string DataAtualizacao { get; set; }
        public Produto ProdutoPedido { get; set; }

    }
}
