using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StratGatherer.Models;

namespace StratGatherer
{
    public interface IDataRetriever
    {
        IEnumerable<Player> GetStats(IEnumerable<PlayerToQuery> playersToQuery);
    }
}
