using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StratGatherer.Models;

namespace StratGatherer.Converters
{
    /// <summary>
    /// Converts a csv line with Strat's fielding format and converts it into a Batter with fielding ratings.
    /// </summary>
    public static class StratCsvLineToBatterConverter
    {
        private const char SEPARATOR = ',';

        private const int FIRST_NAME_INDEX = 3;
        private const int LAST_NAME_INDEX = 2;
        private const int CATCHER_RATING_INDEX = 6;
        private const int FIRSTBASE_RATING_INDEX = 7;
        private const int SECONDBASE_RATING_INDEX = 8;
        private const int THIRDBASE_RATING_INDEX = 9;
        private const int SHORTSTOP_RATING_INDEX = 10;
        private const int LEFTFIELD_RATING_INDEX = 11;
        private const int CENTERFIELD_RATING_INDEX = 12;
        private const int RIGHTFIELD_RATING_INDEX = 13;

        /// <summary>
        /// Converts a strat fielding rating csv line and converts it into a Batter with fielding ratings.
        /// </summary>
        /// <param name="stratCsvLine">A csv line with Strat's fielding ratings.</param>
        /// <returns>A batter with name and fielding ratings.</returns>
        public static Batter Convert(string stratCsvLine)
        {
            string[] playerFields = stratCsvLine.Split(SEPARATOR);
            Batter batter = new Batter
            {
                FirstName = NormalizeName(playerFields[FIRST_NAME_INDEX]),
                LastName = NormalizeName(playerFields[LAST_NAME_INDEX]),
                FieldingRatings = ExtractFieldingRatings(playerFields)
            };
            return batter;
        }

        private static string NormalizeName(string name)
        {
            if (EndsInNumber(name))
            {
                return name.Substring(0, name.Length - 2);
            }

            return name;
        }

        private static bool EndsInNumber(string token) 
        {
            string lastCharacter = token.Substring(token.Length - 1);
            int tempValue;
            return (Int32.TryParse(lastCharacter, out tempValue));
        }

        private static Dictionary<Position, string> ExtractFieldingRatings(string[] playerFields)
        {
            Dictionary<Position, string> fieldingRatings = new Dictionary<Position, string>();
            fieldingRatings[Position.Catcher] = NormalizeFieldingValue(playerFields[CATCHER_RATING_INDEX]);
            fieldingRatings[Position.FirstBase] = NormalizeFieldingValue(playerFields[FIRSTBASE_RATING_INDEX]);
            fieldingRatings[Position.SecondBase] = NormalizeFieldingValue(playerFields[SECONDBASE_RATING_INDEX]);
            fieldingRatings[Position.ThirdBase] = NormalizeFieldingValue(playerFields[THIRDBASE_RATING_INDEX]);
            fieldingRatings[Position.Shortstop] = NormalizeFieldingValue(playerFields[SHORTSTOP_RATING_INDEX]);
            fieldingRatings[Position.LeftField] = NormalizeFieldingValue(playerFields[LEFTFIELD_RATING_INDEX]);
            fieldingRatings[Position.CenterField] = NormalizeFieldingValue(playerFields[CENTERFIELD_RATING_INDEX]);
            fieldingRatings[Position.RightField] = NormalizeFieldingValue(playerFields[RIGHTFIELD_RATING_INDEX]);
            return fieldingRatings;
        }

        private static string NormalizeFieldingValue(string rawValue)
        {
            if (String.IsNullOrEmpty(rawValue.Trim()))
            {
                return null;
            }
            return rawValue.Substring(0, 1);
        }
    }
}
