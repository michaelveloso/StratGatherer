using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StratGatherer.Models;

namespace StratGatherer
{
    /// <summary>
    /// Retrieves player data.
    /// </summary>
    public interface IDataRetriever
    {
        /// <summary>
        /// Gets stats from a data source for a given collection of players.
        /// </summary>
        /// <param name="playersToQuery">The players to query stats for.</param>
        /// <returns>A collection of players with their statistics.</returns>
        IEnumerable<Player> GetStats(IEnumerable<PlayerToQuery> playersToQuery);
    }
}
