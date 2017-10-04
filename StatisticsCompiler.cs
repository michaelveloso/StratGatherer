using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StratGatherer.Models;
using System.IO;
using StratGatherer.MySportsFeeds;

namespace StratGatherer
{
    /// <summary>
    /// Gathers statistics for a given collection of players and prints them to a CSV file.
    /// </summary>
    public static class StatisticsCompiler
    {
        private const string CSV_FILE_NAME = "/test.csv";

        /// <summary>
        /// Gathers statistics for a given collection of players and prints them to a CSV file.
        /// </summary>
        public static void CompileStats()
        {
            IEnumerable<PlayerToQuery> playersToQuery = GetPlayersToQuery();
            IEnumerable<Player> players = GetStats(playersToQuery);       
        }

        private static IEnumerable<PlayerToQuery> GetPlayersToQuery()
        {
            string fileLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + CSV_FILE_NAME;
            IPlayerSource source = new CsvPlayerSource(fileLocation);
            return source.GetPlayers();
        }

        private static IEnumerable<Player> GetStats(IEnumerable<PlayerToQuery> playersToQuery)
        {
            IDataRetriever dataRetriever = new MySportsFeedsDataRetriever();
            return dataRetriever.GetStats(playersToQuery);
        }
    }
}
