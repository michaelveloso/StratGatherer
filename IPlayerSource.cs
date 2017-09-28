using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratGatherer
{
    /// <summary>
    /// The source of players to gather information for.
    /// </summary>
    public interface IPlayerSource
    {
        /// <summary>
        /// Gets a collection of players to gather information for.
        /// </summary>
        /// <returns>A collection of players to gather information for.</returns>
        IEnumerable<Player> GetPlayers();
    }
}
