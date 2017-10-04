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
    public class PlayerToQueryTests
    {
        [TestMethod]
        public void ConcatenatedName_ReturnsCorrectlyFormattedName()
        {
            //Arrange
            PlayerToQuery player = new PlayerToQuery
            {
                FirstName = "Firstname",
                LastName = "Lastname"
            };

            //Act
            string concatenatedName = player.ConcatenatedName;

            //Assert
            Assert.AreEqual("firstname-lastname", player.ConcatenatedName);
        }
    }
}
