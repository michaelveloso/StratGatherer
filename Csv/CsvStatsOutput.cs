using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StratGatherer;
using StratGatherer.Models;

namespace StratGatherer.Csv
{
    /// <summary>
    /// Outputs the stats for a collection of players into a CSV file.
    /// </summary>
    public class CsvStatsOutput : IStatsOutput
    {
        private const string FILENAME = @"\players.csv";

        /// <summary>
        /// Outputs the stats for a collection of players into a given format for a CSV file.
        /// </summary>
        /// <param name="players">The collection of players to output stats for.</param>
        /// <param name="formatter">The formatter to use.</param>
        public void OutputStats(IEnumerable<Player> players, IFormatter formatter)
        {
            string formattedStats = formatter.Format(players);
            PrintCsv(formattedStats);
        }
        
        private void PrintCsv(string formattedStats)
        {
            string desktopFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = desktopFolderPath + FILENAME;
            System.IO.File.WriteAllText(filePath, formattedStats);
        }
    }
}
