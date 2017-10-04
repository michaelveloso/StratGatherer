using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StratGatherer.Models;

namespace StratGatherer
{
    /// <summary>
    /// The source of players to gather statistics for.
    /// </summary>
    public interface IPlayerSource
    {
        /// <summary>
        /// Gets a collection of players to gather statistics for.
        /// </summary>
        /// <returns>A collection of players to gather statistics for.</returns>
        IEnumerable<PlayerToQuery> GetPlayers();
    }
}
