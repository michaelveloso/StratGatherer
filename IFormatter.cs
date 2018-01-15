using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StratGatherer.Models;

namespace StratGatherer
{
    /// <summary>
    /// Provides an output format.
    /// </summary>
    public interface IFormatter
    {
        /// <summary>
        /// Turns a collection of players into an output string.
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        string Format(IEnumerable<Player> players);
    }
}
