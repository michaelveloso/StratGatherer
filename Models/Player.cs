using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratGatherer.Models
{
    /// <summary>
    /// A baseball player.
    /// </summary>
    public abstract class Player
    {
        /// <summary>
        /// The player's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The player's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The player's batting average.
        /// </summary>
        public decimal BattingAverage { get; set; }

        /// <summary>
        /// The player's on-base percentage.
        /// </summary>
        public decimal OnBasePercentage { get; set; }

        /// <summary>
        /// The player's slugging percentage.
        /// </summary>
        public decimal SluggingPercentage { get; set; }

        /// <summary>
        /// Calculates the minimum value a player must reach to be kept for next season.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected int CalculateMinimumToKeep(int value)
        {
            decimal rawAmountToKeep = value * 0.65m;
            return (int)Math.Round(rawAmountToKeep);
        }

        /// <summary>
        /// Calculates the maximum value a player can reach during a Strat-o-Matic season.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected int CalculateMaximum(int value)
        {
            decimal rawMaximum = value * 1.15m;
            return (int)Math.Round(rawMaximum);
        }

        /// <summary>
        /// Gets the full name of the player.
        /// </summary>
        /// <returns>The full name of the player.</returns>
        public string FullName
        {
            get 
            {
                return FirstName + " " + LastName;
            }            
        }
    }
}
