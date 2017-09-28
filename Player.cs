using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratGatherer
{
    /// <summary>
    /// The data on a baseball player.
    /// </summary>
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GeneralPosition GeneralPosition { get; set; }
    }
}
