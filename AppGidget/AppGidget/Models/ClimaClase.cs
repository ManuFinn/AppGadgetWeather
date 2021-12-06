using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AppGidget.Models
{
    public class ClimaClase
    {
        // {"weather":{"main":"clouds","description":"broken clouds","temperature":18.19},
        // "datetime":{"date":"2021-12-06","time":"3:37 PM","isday":true}}

        [JsonProperty("main")]
        public string main { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("temperature")]
        public float temperature { get; set; }

        [JsonProperty("date")]
        public DateTime date { get; set; }

        [JsonProperty("time")]
        public DateTime time { get; set; }

        [JsonProperty("isday")]
        public bool isday { get; set; }

    }
}
