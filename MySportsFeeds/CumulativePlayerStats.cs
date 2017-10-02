using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StratGatherer.MySportsFeeds
{
    public class CumulativePlayerStats
    {
        [JsonProperty("lastUpdatedOn")]
        public DateTime LastUpdatedOn { get; set; }

        [JsonProperty("playerstatsentry")]
        public List<PlayerStatsEntry> PlayerStatsEntries { get; set; }
    }
}
