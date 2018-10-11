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
        public int Numero { get; set; }
        public int Situacao { get; set; }
        public int Status { get; set; }
        public string Observacao { get; set; }
        public string DtCriacao { get; set; }
        public string DtAtualizacao { get; set; }
        [JsonProperty("Cliente")]
        public Cliente ClientePedido { get; set; }
        [JsonProperty("CondicaoPagamento")]
        public CondicaoPagamento CondicaoPagamentoPedido { get; set; }
        [JsonProperty("TabelaPreco")]
        public TabelaPrecos TabelaPrecosPedido { get; set; }
        [JsonProperty("ItensPedido")]
        public List<ItemPedido> ListaItemPedido { get; set; }

    }
}
