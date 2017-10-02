using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StratGatherer.MySportsFeeds;
using StratGatherer.Models;

namespace StratGatherer
{
    public class MySportsFeedsDataRetriever : IDataRetriever
    {
        public IEnumerable<Player> GetStats(IEnumerable<PlayerToQuery> playersToQuery)
        {
            MySportsFeedsResponse response = MySportsFeedsClient.Query(playersToQuery);

            //TODO: parse response into collection of Players
            return new List<Player>();
        }
    }
}
