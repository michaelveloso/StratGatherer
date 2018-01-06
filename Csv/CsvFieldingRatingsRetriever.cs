using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StratGatherer.Converters;
using StratGatherer.Models;

namespace StratGatherer.Csv
{
    public class CsvFieldingRatingsRetriever : IFieldingRatingsRetriever
    {
        private Dictionary<string, Batter> _stratRatings = new Dictionary<string,Batter>();
        private string _fileLocation;

        public CsvFieldingRatingsRetriever(string fileLocation)
        {
            _fileLocation = fileLocation;
        }

        public IEnumerable<Player> GetFieldingRatings(IEnumerable<Player> players)
        {
            CompileStratRatings();
            IEnumerable<Player> playersWithFieldingRatings = players.Select(AddFieldingRatings);
            return playersWithFieldingRatings;
        }

        private void CompileStratRatings()
        {
            IEnumerable<string> lines = CsvReader.ReadCsvWithoutHeader(_fileLocation);
            foreach (string line in lines)
            {
                Batter batter = StratCsvLineToBatterConverter.Convert(line);
                if (!_stratRatings.ContainsKey(batter.FullName))
                {
                    _stratRatings.Add(batter.FullName, batter);
                }
            }
        }

        private Player AddFieldingRatings(Player player)
        {
            if (player is Batter)
            {
                Batter batter = player as Batter;
                batter.FieldingRatings = _stratRatings[batter.FullName].FieldingRatings;
                return batter;
            }
            else
            {
                return player;
            }
        }
    }
}
