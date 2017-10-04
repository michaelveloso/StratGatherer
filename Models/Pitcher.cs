using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratGatherer.Models
{
    /// <summary>
    /// A pitcher.
    /// </summary>
    public class Pitcher : Player
    {
        /// <summary>
        /// The number of real-world games started by this pitcher.
        /// </summary>
        public int GamesStarted { get; set; }

        /// <summary>
        /// The number of real-world inningg started by this pitcher. Partial innings are rounded down.
        /// </summary>
        public int InningsPitched { get; set; }

        /// <summary>
        /// The maximum starts this pitcher can make in a Strat season.
        /// </summary>
        public int MaximumGamesStarted
        {
            get
            {
                return this.CalculateMaximum(GamesStarted);
            }
        }

        /// <summary>
        /// The maximum number of innings this pitcher can pitch in a Strat season.
        /// </summary>
        public int MaximumInningsPitched
        {
            get
            {
                return this.CalculateMaximum(InningsPitched);
            }
        }

        /// <summary>
        /// The minimum number of innings this pitcher must pitch to be kept for next Strat season.
        /// </summary>
        public int MinimumInningsPitchedToKeep
        {
            get
            {
                return this.CalculateMinimumToKeep(InningsPitched);
            }
        }
    }
}
