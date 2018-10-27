using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain {
    public class Configuracoes {

        [JsonIgnore]
        public ObjectId _id { get; set; }
        public string ID { get; set; }
        public string TempoMaxSemSinc { get; set; }
        public string TempoEntreCadaSinc { get; set; }
        public string PeriodoParaIndicadores { get; set; }

    }
}
