using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StratGatherer.Models;
using System.IO;
using StratGatherer.MySportsFeeds;
using StratGatherer.Csv;

namespace StratGatherer
{
    /// <summary>
    /// Gathers statistics for a given collection of players and prints them to a CSV file.
    /// </summary>
    public static class StatisticsCompiler
    {
        private const string CSV_PLAYERS_TO_QUERY_FILE_NAME = "/FreeAgents2018.csv";
        private const string CSV_STRAT_FIELDING_RATINGS_FILE_NAME = "/2017_strat_ratings.csv";

        /// <summary>
        /// Gathers statistics for a given collection of players and prints them to a CSV file.
        /// </summary>
        public static void CompileStats()
        {
            IEnumerable<PlayerToQuery> playersToQuery = GetPlayersToQuery();
            IEnumerable<Player> players = GetPlayerData(playersToQuery);
            OutputStatistics(players);
        }

        private static IEnumerable<PlayerToQuery> GetPlayersToQuery()
        {
            string fileLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + CSV_PLAYERS_TO_QUERY_FILE_NAME;
            IPlayerSource source = new CsvPlayerSource(fileLocation);
            return source.GetPlayers();
        }

        private static IEnumerable<Player> GetPlayerData(IEnumerable<PlayerToQuery> playersToQuery)
        {
            IEnumerable<Player> playersWithBasicData = GetBasicData(playersToQuery);
            IEnumerable<Player> playersWithFieldingRatings = GetFieldingRatings(playersWithBasicData);
            return playersWithFieldingRatings;
        }

        private static IEnumerable<Player> GetFieldingRatings(IEnumerable<Player> players)
        {
            string fileLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + CSV_STRAT_FIELDING_RATINGS_FILE_NAME;
            IFieldingRatingsRetriever fieldingRatingsRetriever = new CsvFieldingRatingsRetriever(fileLocation);
            return fieldingRatingsRetriever.GetFieldingRatings(players);
        }

        private static IEnumerable<Player> GetBasicData(IEnumerable<PlayerToQuery> playersToQuery)
        {
            IDataRetriever dataRetriever = new MySportsFeedsDataRetriever();
            return dataRetriever.GetStats(playersToQuery);
        }

        private static void OutputStatistics(IEnumerable<Player> players)
        {
            IStatsOutput iStatsOutput = new CsvStatsOutput();
            iStatsOutput.OutputStats(players);
        }
    }
}
