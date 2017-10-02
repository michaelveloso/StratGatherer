using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratGatherer.Models
{
    /// <summary>
    /// The data on a baseball player.
    /// </summary>
    public class PlayerToQuery
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GeneralPosition GeneralPosition { get; set; }

        public string ConcatenatedName
        {
            get
            {
                return string.Format("{0}-{1}", FirstName.ToLower(), LastName.ToLower());
            }
        }
    }
}
