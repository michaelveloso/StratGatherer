using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StratGatherer.MySportsFeeds;
using StratGatherer.Models;

namespace StratGatherer
{
    /// <summary>
    /// Retrieves stats from MySportsFeeds.
    /// </summary>
    public class MySportsFeedsDataRetriever : IDataRetriever
    {
        /// <summary>
        /// Gets stats from MySportsFeeds for a given collection of players.
        /// </summary>
        /// <param name="playersToQuery">The players to query stats for.</param>
        /// <returns>A collection of players with their statistics.</returns>
        public IEnumerable<CompiledPlayer> GetStats(IEnumerable<PlayerToQuery> playersToQuery)
        {
            MySportsFeedsResponse response = MySportsFeedsClient.Query(playersToQuery);

            //TODO: parse response into collection of Compiled Players
            return new List<CompiledPlayer>();
        }
    }
}
