﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratGatherer.Models
{
    /// <summary>
    /// A player who plays the field.
    /// </summary>
    public class Batter : Player
    {
        /// <summary>
        /// The number of plate appearances made by this player in the real-world season.
        /// </summary>
        public int PlateAppearances { get; set; }
        
        /// <summary>
        /// The minimum number of plate appearances a player must reach to be kept for next Strat season.
        /// </summary>
        public int MinimumPlateAppearancesToKeep { 
            get
            {
                return this.CalculateMinimumToKeep(PlateAppearances);
            }
        }      

        /// <summary>
        /// The maximum number of plate appearances a player can have in a Strat season.
        /// </summary>
        public int MaximumPlateAppearances
        {
            get
            {
                return this.CalculateMaximum(PlateAppearances);
            }
        }
    }
}
