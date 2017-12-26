﻿using System;
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
    public class CsvFormatter
    {
        private StringBuilder _stringBuilder;
        private IEnumerable<Player> _players;

        /// <summary>
        /// Formats a collection of players into a csv-ready string.
        /// </summary>
        /// <param name="players">The collection of players to format.</param>
        /// <returns>The string to output into a csv.</returns>
        public static string FormatPlayers(IEnumerable<Player> players)
        {
            CsvFormatter csvFormatter = new CsvFormatter(players);
            return csvFormatter.Format();
        }

        private CsvFormatter(IEnumerable<Player> players)
        {
            _players = players;
            _stringBuilder = new StringBuilder();
        }

        private string Format()
        {
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
            _stringBuilder.AppendLine("Last Name,First Name,Plate Appearances,Min PA,Max PA,Batting Average,On-Base Percentage,Slugging Percentage");
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
            _stringBuilder.AppendLine("Last Name,First Name,Games Started,Max GS,Innings Pitched,Min IP,Max IP,Batting Average,On-Base Percentage,Slugging Percentage");
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
                batter.PlateAppearances.ToString(),
                batter.MinimumPlateAppearancesToKeep.ToString(),
                batter.MaximumPlateAppearances.ToString(),
                batter.BattingAverage.ToString(),
                batter.OnBasePercentage.ToString(),
                batter.SluggingPercentage.ToString()
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
