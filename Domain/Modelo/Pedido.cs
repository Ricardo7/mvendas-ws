﻿using System;
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
        public string ID { get; set; }
        public int Situacao { get; set; }
        public string DataCriacao { get; set; }
        public string DataAtualizacao { get; set; }
        public List<ItemPedido> ListaItemPedido { get; set; }
        public Cliente ClientePedido { get; set; }
        public CondicaoPagamento CondicaoPagamentoPedido { get; set; }
        public TabelaPrecos TabelaPrecosPedido { get; set; }

    }
}
