using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StratGatherer.Models;
using StratGatherer.MySportsFeeds;
using StratGatherer.MySportsFeeds.Response;

namespace StratGatherer.Converters
{
    /// <summary>
    /// Converts a PlayerStatsEntry into a Batter.
    /// </summary>
    public static class MySportsFeedsToBatterConverter
    {
        /// <summary>
        /// Converts a PlayerStatsEntry into a Batter.
        /// </summary>
        /// <param name="batterEntry">A PlayerStatsEntry for a batter.</param>
        /// <returns>A batter.</returns>
        public static Batter Convert(PlayerStatsEntry batterEntry)
        {
            return new Batter
            {
                FirstName = batterEntry.Player.FirstName,
                LastName = batterEntry.Player.LastName,
                PlateAppearances = ConvertStringToInt(batterEntry.Statistics["PlateAppearances"].Value),
                BattingAverage = ConvertStringToDecimal(batterEntry.Statistics["BattingAvg"].Value),
                OnBasePercentage = ConvertStringToDecimal(batterEntry.Statistics["BatterOnBasePct"].Value),
                SluggingPercentage = ConvertStringToDecimal(batterEntry.Statistics["BatterSluggingPct"].Value),
            };
        }

        private static decimal ConvertStringToDecimal(string value)
        {
            return System.Convert.ToDecimal(value);
        }

        private static int ConvertStringToInt(string value)
        {
            return System.Convert.ToInt32(value);
        }
    }
}
