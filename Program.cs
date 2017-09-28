using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StratGatherer
{
    class Program
    {
        private const string CSV_FILE_NAME = "/test.csv";

        static void Main(string[] args)
        {
            string fileLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + CSV_FILE_NAME;
            IPlayerSource source = new CsvPlayerSource(fileLocation);
            IEnumerable<Player> players = source.GetPlayers();
        }
    }
}
