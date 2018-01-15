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
        /// <summary>
        /// The player's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The player's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The concatenated name for quering MySportsFeeds.
        /// </summary>
        public string ConcatenatedName
        {
            get
            {
                return string.Format("{0}-{1}", FirstName.ToLower(), LastName.ToLower());
            }
        }

        /// <summary>
        /// The concatenated name for quering MySportsFeeds.
        /// </summary>
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

    }
}
