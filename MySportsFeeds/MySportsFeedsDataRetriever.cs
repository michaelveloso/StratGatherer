using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StratGatherer.Models;
using StratGatherer.Converters;
using StratGatherer.MySportsFeeds.Response;

namespace StratGatherer.MySportsFeeds
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
        public IEnumerable<Player> GetStats(IEnumerable<PlayerToQuery> playersToQuery)
        {
            MySportsFeedsResponse response = MySportsFeedsClient.Query(playersToQuery);

            IEnumerable<Player> pitchers = ExtractPitchers(response);
            IEnumerable<Player> batters = ExtractBatters(response);
            return batters.Concat(pitchers);
        }

        private IEnumerable<Player> ExtractPitchers(MySportsFeedsResponse rawResponse)
        {
            return rawResponse.CumulativePlayerStats.PlayerStatsEntries
                .Where(IsPitcher)
                .Select(MySportsFeedsToPitcherConverter.Convert);
        }

        private IEnumerable<Player> ExtractBatters(MySportsFeedsResponse rawResponse)
        {
            return rawResponse.CumulativePlayerStats.PlayerStatsEntries
                .Where(IsBatter)
                .Select(MySportsFeedsToBatterConverter.Convert);
        }

        private bool IsPitcher(PlayerStatsEntry playerStatsEntry)
        {
            return playerStatsEntry.Player.Position == "P";
        }

        private bool IsBatter(PlayerStatsEntry playerStatsEntry)
        {
            return !IsPitcher(playerStatsEntry);
        }
    }
}
