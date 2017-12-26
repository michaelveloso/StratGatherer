using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StratGatherer;
using StratGatherer.Models;
using StratGatherer.Csv;
using System.IO;

namespace StratGatherer.Tests
{
    [TestClass]
    public class CsvPlayerSourceTests
    {
        private const string TEST_FILE_NAME = "/test.csv";

        [TestMethod]
        public void CsvPlayerSource_TestCsv_ReturnsAllPlayers()
        {
            //Arrange
            string fileLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + TEST_FILE_NAME;
            CsvPlayerSource csvPlayerSource = new CsvPlayerSource(fileLocation);

            //Act
            List<PlayerToQuery> players = csvPlayerSource.GetPlayers().ToList();
            PlayerToQuery aaronAaronson = players[0];
            PlayerToQuery zekeZachary = players[1];

            //Assert
            Assert.AreEqual("Aaron", aaronAaronson.FirstName);
            Assert.AreEqual("Aaronson", aaronAaronson.LastName);

            Assert.AreEqual("Zeke", zekeZachary.FirstName);
            Assert.AreEqual("Zachary", zekeZachary.LastName);
        }
    }
}
