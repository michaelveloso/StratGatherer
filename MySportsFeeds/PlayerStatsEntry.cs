using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StratGatherer.MySportsFeeds
{
    public class PlayerStatsEntry
    {
        [JsonProperty("player")]
        public MySportsFeedsPlayer Player { get; set; }

        [JsonProperty("stats")]
        public Dictionary<string, Statistic> Statistics { get; set; }
    }
}
