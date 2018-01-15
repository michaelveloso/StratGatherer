﻿using System;
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
        /// Outputs the statistics for a collection of players in a given format.
        /// </summary>
        /// <param name="players">The collection of players to output stats for.</param>
        /// <param name="formatter">The formatter to use when creating the output.</param>
        void OutputStats(IEnumerable<Player> players, IFormatter formatter);
    }
}
