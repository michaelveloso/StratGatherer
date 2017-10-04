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
    /// Converts a PlayerStatsEntry into a Pitcher.
    /// </summary>
    public static class MySportsFeedsToPitcherConverter
    {
        /// <summary>
        /// Converts a PlayerStatsEntry into a Pitcher.
        /// </summary>
        /// <param name="pitcherEntry">The pitcher PlayerStatsEntry to convert.</param>
        /// <returns>A Pitcher.</returns>
        public static Pitcher Convert(PlayerStatsEntry pitcherEntry)
        {
            return new Pitcher
            {
                FirstName = pitcherEntry.Player.FirstName,
                LastName = pitcherEntry.Player.LastName,
                GamesStarted = ConvertStringToInt(pitcherEntry.Statistics["GamesStarted"].Value),
                InningsPitched = (int)Math.Round(ConvertStringToDecimal(pitcherEntry.Statistics["InningsPitched"].Value)),
                BattingAverage = ConvertStringToDecimal(pitcherEntry.Statistics["PitchingAvg"].Value),
                OnBasePercentage = ConvertStringToDecimal(pitcherEntry.Statistics["PitcherOnBasePct"].Value),
                SluggingPercentage = ConvertStringToDecimal(pitcherEntry.Statistics["PitcherSluggingPct"].Value),
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
