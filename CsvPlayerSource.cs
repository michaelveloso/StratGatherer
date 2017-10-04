using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using StratGatherer.Models;

namespace StratGatherer
{
    /// <summary>
    /// Gets a collection of players from a csv file.
    /// </summary>
    public class CsvPlayerSource : IPlayerSource
    {
        public const int FIRST_NAME_INDEX = 0;
        public const int LAST_NAME_INDEX = 1;
        public const char SEPARATOR = ',';

        private string _fileLocation;

        public CsvPlayerSource(string fileLocation)
        {
            _fileLocation = fileLocation;
        }

        /// <summary>
        /// Gets a collection of players.
        /// </summary>
        /// <returns>A collection of players.</returns>
        public IEnumerable<PlayerToQuery> GetPlayers()
        {
            IEnumerable<string> lines = CsvReader.ReadCsvWithoutHeader(_fileLocation);
            IEnumerable<PlayerToQuery> players = lines.Select(ConvertToPlayer);
            return players;
        }     

        private static PlayerToQuery ConvertToPlayer(string csvPlayerData)
        {
            string[] playerFields = csvPlayerData.Split(SEPARATOR);
            PlayerToQuery player = new PlayerToQuery {
                FirstName = playerFields[FIRST_NAME_INDEX],
                LastName = playerFields[LAST_NAME_INDEX]
            };
            return player;
        }
    }
}
