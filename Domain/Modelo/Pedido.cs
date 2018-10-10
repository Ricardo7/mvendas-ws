using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain
{
    public class Pedido {

        [JsonIgnore]
        public ObjectId _id { get; set; }
        [JsonProperty("IDAP")]
        public int IDAP { get; set; }
        [JsonProperty("IDWS")]
        public string ID { get; set; }
        public int Situacao { get; set; }
        public string DtCriacao { get; set; }
        public string DtAtualizacao { get; set; }
        public List<ItemPedido> ListaItemPedido { get; set; }
        public Cliente ClientePedido { get; set; }
        public CondicaoPagamento CondicaoPagamentoPedido { get; set; }
        public TabelaPrecos TabelaPrecosPedido { get; set; }

    }
}
