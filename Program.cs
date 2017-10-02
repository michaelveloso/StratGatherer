using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DotNetEnv;
using StratGatherer.Models;

namespace StratGatherer
{
    class Program
    {
        private const string CSV_FILE_NAME = "/test.csv";

        static void Main(string[] args)
        {
            DotNetEnv.Env.Load();
            IEnumerable<PlayerToQuery> playersToQuery = GetPlayersToQuery();
            IEnumerable<CompiledPlayer> players = GetStats(playersToQuery);            
        }

        private static IEnumerable<PlayerToQuery> GetPlayersToQuery()
        {
            string fileLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + CSV_FILE_NAME;
            IPlayerSource source = new CsvPlayerSource(fileLocation);
            return source.GetPlayers();
        }

        private static IEnumerable<CompiledPlayer> GetStats(IEnumerable<PlayerToQuery> playersToQuery)
        {
            IDataRetriever dataRetriever = new MySportsFeedsDataRetriever();
            return dataRetriever.GetStats(playersToQuery);
        }
    }
}
