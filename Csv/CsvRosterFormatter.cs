using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StratGatherer.Models;

namespace StratGatherer.Csv
{
    /// <summary>
    /// Formats a collection of players into a csv-ready string.
    /// </summary>
    public class CsvRosterFormatter : IFormatter
    {
        private StringBuilder _stringBuilder;
        private IEnumerable<Player> _players;

        public CsvRosterFormatter()
        {
            _stringBuilder = new StringBuilder();
        }

        public string Format(IEnumerable<Player> players)
        {
            _players = players;
            AddBattingSection();
            _stringBuilder.AppendLine();
            AddPitchingSection();
            return _stringBuilder.ToString();
        }

        private void AddBattingSection()
        {
            AddBattingHeader();
            AddBatters();
        }

        private void AddPitchingSection()
        {
            AddPitchingHeader();
            AddPitchers();
        }

        private void AddBattingHeader()
        {
            _stringBuilder.AppendLine("Last Name,First Name,C,1B,2B,3B,SS,LF,CF,RF,PA,Min PA,Max PA,BA,OBP,SLG");
        }

        private void AddBatters()
        {
            foreach(Player player in _players)
            {
                Batter batter = player as Batter;
                if (batter != null)
                {
                    _stringBuilder.AppendLine(Format(batter));
                }
            }
        }

        private void AddPitchingHeader()
        {
            _stringBuilder.AppendLine("Last Name,First Name,GS,Max GS,IP,Min IP,Max IP,BA,OBP,SLG");
        }

        private void AddPitchers()
        {
            foreach (Player player in _players)
            {
                Pitcher pitcher = player as Pitcher;
                if (pitcher != null)
                {
                    _stringBuilder.AppendLine(Format(pitcher));
                }
            }
        }
        
        private string Format(Batter batter)
        {
            List<string> batterStats = new List<string> {
                batter.LastName,
                batter.FirstName,
                batter.FieldingRatings[Position.Catcher],
                batter.FieldingRatings[Position.FirstBase],
                batter.FieldingRatings[Position.SecondBase],
                batter.FieldingRatings[Position.ThirdBase],
                batter.FieldingRatings[Position.Shortstop],
                batter.FieldingRatings[Position.LeftField],
                batter.FieldingRatings[Position.CenterField],
                batter.FieldingRatings[Position.RightField],
                batter.PlateAppearances.ToString(),
                batter.MinimumPlateAppearancesToKeep.ToString(),
                batter.MaximumPlateAppearances.ToString(),
                batter.BattingAverage.ToString("0.###"),
                batter.OnBasePercentage.ToString("0.###"),
                batter.SluggingPercentage.ToString("0.###")
            };

            return string.Join(",", batterStats);
        }

        private string Format(Pitcher pitcher)
        {
            List<string> pitcherStats = new List<string>
            {
                pitcher.LastName,
                pitcher.FirstName,
                pitcher.GamesStarted.ToString(),
                pitcher.MaximumGamesStarted.ToString(),
                pitcher.InningsPitched.ToString(),
                pitcher.MinimumInningsPitchedToKeep.ToString(),
                pitcher.MaximumInningsPitched.ToString(),
                pitcher.BattingAverage.ToString(),
                pitcher.OnBasePercentage.ToString(),
                pitcher.SluggingPercentage.ToString()
            };

            return string.Join(",", pitcherStats);
        }
    }
}
