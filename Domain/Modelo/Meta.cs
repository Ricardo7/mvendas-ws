﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain {

    public class Meta {

        [JsonIgnore]
        public ObjectId _id { get; set; }
        [JsonProperty("IDWS")]
        public string ID { get; set; }
        public double Estimado { get; set; }
        public double Realizado { get; set; }
    }
}
