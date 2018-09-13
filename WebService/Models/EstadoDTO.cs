using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using Newtonsoft.Json;

namespace WebService
{
    public class EstadoDTO
    {
        [JsonProperty("cod")]
        public int Cod { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public Estado estado { get; set; }

    }
}