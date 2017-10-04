using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StratGatherer.Models;

namespace StratGatherer.Tests
{
    [TestClass]
    public class BatterTests
    {
        [TestMethod]
        public void MinimumPlateAppearancesToKeep_Given100_Returns65()
        {
            Batter batter = new Batter
            {
                PlateAppearances = 100
            };

            Assert.AreEqual(65, batter.MinimumPlateAppearancesToKeep);
        }

        [TestMethod]
        public void MaximumPlateAppearances_Given100_Returns65()
        {
            Batter batter = new Batter
            {
                PlateAppearances = 100
            };

            Assert.AreEqual(115, batter.MaximumPlateApperances);
        }
    }
}
