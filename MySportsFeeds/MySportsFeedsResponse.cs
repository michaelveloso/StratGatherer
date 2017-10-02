using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StratGatherer.MySportsFeeds
{
    public class MySportsFeedsResponse
    {
        [JsonProperty("cumulativeplayerstats")]
        public CumulativePlayerStats CumulativePlayerStats { get; set; }
    }
}
