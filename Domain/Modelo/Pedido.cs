using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain
{
    public class Pedido
    {
        [JsonIgnore]
        public ObjectId _id { get; set; }
        public int ID { get; set; }
    }
}
