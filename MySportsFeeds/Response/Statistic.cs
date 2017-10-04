using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StratGatherer.MySportsFeeds.Response
{
    public class Statistic
    {
        [JsonProperty("@category")]
        public string Category { get; set; }

        [JsonProperty("@abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("#text")]
        public string Value { get; set; }
    }
}
