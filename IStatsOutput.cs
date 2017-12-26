using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StratGatherer.Models;

namespace StratGatherer
{
    /// <summary>
    /// Outputs the statistics for a collection of players.
    /// </summary>
    public interface IStatsOutput
    {
        /// <summary>
        /// Outputs the statistics for a collection of players.
        /// </summary>
        /// <param name="Players">The collection of players to output stats for.</param>
        void OutputStats(IEnumerable<Player> Players);
    }
}
