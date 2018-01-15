using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StratGatherer.Models;

namespace StratGatherer.Csv
{
    public class CsvDraftFormatter : IFormatter
    {
        private StringBuilder _stringBuilder;
        private IEnumerable<Player> _players;

        public CsvDraftFormatter()
        {
            _stringBuilder = new StringBuilder();
        }

        public string Format(IEnumerable<Player> players)
        {
            _players = players;
            AddHeader();
            AddPlayers();
            return _stringBuilder.ToString();
        }

        private void AddHeader()
        {
            _stringBuilder.AppendLine("Last,First,A,2,3,4,5,6,7,8,9,ACT,BA,OBP,SLG");
        }

        private void AddPlayers()
        {
            IEnumerable<Player> sortedPlayers = _players.OrderBy(player => player.FirstName).OrderBy(player => player.LastName);
            foreach (Player player in sortedPlayers)
            {
                _stringBuilder.AppendLine(FormatPlayer(player));
            }
        }

        private string FormatPlayer(Player player)
        {
            if (player is Batter)
            {
                return FormatBatter(player);
            }
            else
            {
                return FormatPitcher(player);
            }
        }

        private string FormatBatter(Player player)
        {
            Batter batter = player as Batter;
            List<string> batterStats = new List<string> {
                batter.LastName,
                batter.FirstName,
                String.Empty,
                batter.FieldingRatings[Position.Catcher],
                batter.FieldingRatings[Position.FirstBase],
                batter.FieldingRatings[Position.SecondBase],
                batter.FieldingRatings[Position.ThirdBase],
                batter.FieldingRatings[Position.Shortstop],
                batter.FieldingRatings[Position.LeftField],
                batter.FieldingRatings[Position.CenterField],
                batter.FieldingRatings[Position.RightField],
                batter.PlateAppearances.ToString(),
                batter.BattingAverage.ToString("0.###"),
                batter.OnBasePercentage.ToString("0.###"),
                batter.SluggingPercentage.ToString("0.###"),
            };

            return string.Join(",", batterStats);
        }

        private string FormatPitcher(Player player)
        {
            Pitcher pitcher = player as Pitcher;
            List<string> pitcherStats = new List<string> {
                pitcher.LastName,
                pitcher.FirstName,
                String.Empty,
                String.Empty,
                String.Empty,
                String.Empty,
                String.Empty,
                String.Empty,
                String.Empty,
                String.Empty,
                String.Empty,
                FormatPitcherAppearances(pitcher),
                pitcher.BattingAverage.ToString("0.###"),
                pitcher.OnBasePercentage.ToString("0.###"),
                pitcher.SluggingPercentage.ToString("0.###")
            };

            return string.Join(",", pitcherStats);
        }

        private string FormatPitcherAppearances(Pitcher pitcher)
        {
            return string.Format("{0} / {1}", pitcher.InningsPitched, pitcher.GamesStarted);
        }
    }
}
