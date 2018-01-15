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
        IDictionary<string, Player> _allPlayers;

        /// <summary>
        /// Gets stats from MySportsFeeds for a given collection of players.
        /// </summary>
        /// <param name="playersToQuery">The players to query stats for.</param>
        /// <returns>A collection of players with their statistics.</returns>
        public IEnumerable<Player> GetStats(IEnumerable<PlayerToQuery> playersToQuery)
        {
            MySportsFeedsResponse response = MySportsFeedsClient.Query();
            _allPlayers = ExtractPlayers(response);
            IEnumerable<Player> players = playersToQuery.Select(TryAddPlayer);
            return players;            
        }

        private Player TryAddPlayer(PlayerToQuery playerToQuery)
        {
            try
            {
                return _allPlayers[playerToQuery.FullName];
            }
            catch
            {
                return new Batter
                {
                    FirstName = playerToQuery.FirstName,
                    LastName = playerToQuery.LastName
                };
            }
        }

        private IDictionary<string, Player> ExtractPlayers(MySportsFeedsResponse response){            
            IEnumerable<Player> pitchers = ExtractPitchers(response);
            IEnumerable<Player> batters = ExtractBatters(response);
            IEnumerable<Player> players = batters.Concat(pitchers);
            IDictionary<string, Player> playerDictionary = new Dictionary<string, Player>();
            foreach (Player player in players)
            {                
                playerDictionary[player.FullName] = player;
            }
            return playerDictionary;
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
