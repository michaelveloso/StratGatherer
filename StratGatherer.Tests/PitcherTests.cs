using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StratGatherer.Models;

namespace StratGatherer.Tests
{
    [TestClass]
    public class PitcherTests
    {
        [TestMethod]
        public void MinimumInningsPitchedToKeep_Given100_Returns65()
        {
            Pitcher pitcher = new Pitcher
            {
                InningsPitched = 100
            };

            Assert.AreEqual(65, pitcher.MinimumInningsPitchedToKeep);
        }

        [TestMethod]
        public void MaximumInningsPitched_Given100_Returns115()
        {
            Pitcher pitcher = new Pitcher
            {
                InningsPitched = 100
            };

            Assert.AreEqual(115, pitcher.MaximumInningsPitched);
        }

        [TestMethod]
        public void MaximumGamesStarted_Given100_Returns115()
        {
            Pitcher pitcher = new Pitcher
            {
                GamesStarted = 100
            };

            Assert.AreEqual(115, pitcher.MaximumGamesStarted);
        }
    }
}
