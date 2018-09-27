using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Domain
{
    class Produto
    {
        public ObjectId _id { get; set; }
        public int ID { get; set; }
    }
}
