using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.json
{
    public class CurrencyListModel : Base
    {
        [JsonProperty("terms")]
        public string Terms { get; set; }

        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("currencies")]
        public Dictionary<string, string> quotes { get; set; } 
    }
}
