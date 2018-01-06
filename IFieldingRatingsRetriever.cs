using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StratGatherer.Models;

namespace StratGatherer
{
    /// <summary>
    /// Retrieves Strat-o-matic fielding ratings from a given source.
    /// </summary>
    public interface IFieldingRatingsRetriever
    {
        IEnumerable<Player> GetFieldingRatings(IEnumerable<Player> players);
    }
}
