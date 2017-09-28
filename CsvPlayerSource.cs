using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StratGatherer
{
    /// <summary>
    /// Gets a collection of players from a csv file.
    /// </summary>
    public class CsvPlayerSource : IPlayerSource
    {
        public const int FIRST_NAME_INDEX = 0;
        public const int LAST_NAME_INDEX = 1;
        public const int GENERAL_POSITION_INDEX = 2;
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
        public IEnumerable<Player> GetPlayers()
        {
            IEnumerable<string> lines = CsvReader.ReadCsvWithoutHeader(_fileLocation);
            IEnumerable<Player> players = lines.Select(ConvertToPlayer);
            return players;
        }     

        private static Player ConvertToPlayer(string csvPlayerData)
        {
            string[] playerFields = csvPlayerData.Split(SEPARATOR);
            Player player = new Player {
                FirstName = playerFields[FIRST_NAME_INDEX],
                LastName = playerFields[LAST_NAME_INDEX],
                GeneralPosition = ConvertToGeneralPosition(playerFields[GENERAL_POSITION_INDEX])
            };
            return player;
        }

        private static GeneralPosition ConvertToGeneralPosition(string generalPositionValue)
        {
            return (GeneralPosition)Enum.Parse(typeof(GeneralPosition), generalPositionValue);
        }
    }
}
