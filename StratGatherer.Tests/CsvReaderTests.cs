using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StratGatherer;
using StratGatherer.Csv;
using System.IO;

namespace StratGatherer.Tests
{
    [TestClass]
    public class CsvReaderTests
    {
        private static string TEST_FILE_NAME = "/test.csv";

        private string _fileLocation;

        public CsvReaderTests()
        {
            _fileLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + TEST_FILE_NAME;
        }

        [TestMethod]
        public void ReadCsvWithHeader_FromTestFile_IncludesHeader()
        {
            //Arrange

            //Act
            IEnumerable<string> testPlayers = CsvReader.ReadCsvWithHeader(_fileLocation);
            string header = testPlayers.ToList().First();
            string[] fields = header.Split(',');

            //Assert
            Assert.AreEqual("FirstName", fields[0]);
            Assert.AreEqual("LastName", fields[1]);
        }

        [TestMethod]
        public void ReadCsvWithoutHeader_FromTestFile_ExcludesHeader()
        {
            //Arrange

            //Act
            IEnumerable<string> testPlayers = CsvReader.ReadCsvWithoutHeader(_fileLocation);
            string firstLine = testPlayers.ToList().First();
            string[] fields = firstLine.Split(',');

            //Assert
            Assert.AreNotEqual("FirstName", fields[0]);
            Assert.AreNotEqual("LastName", fields[1]);
        }

        [TestMethod]
        public void ReadCsvWithHeader_FromTestFile_IncludesAllPlayerLines()
        {
            //Arrange

            //Act
            IEnumerable<string> testPlayers = CsvReader.ReadCsvWithHeader(_fileLocation);

            string firstPlayer = testPlayers.ToList()[1];
            string[] firstPlayerFields = firstPlayer.Split(',');

            string secondPlayer = testPlayers.ToList()[2];
            string[] secondPlayerFields = secondPlayer.Split(',');

            //Assert
            Assert.AreEqual("Aaron", firstPlayerFields[0]);
            Assert.AreEqual("Aaronson", firstPlayerFields[1]);

            Assert.AreEqual("Zeke", secondPlayerFields[0]);
            Assert.AreEqual("Zachary", secondPlayerFields[1]);
        }

        [TestMethod]
        public void ReadCsvWithoutHeader_FromTestFile_IncludesAllPlayerLines()
        {
            //Arrange

            //Act
            IEnumerable<string> testPlayers = CsvReader.ReadCsvWithoutHeader(_fileLocation);

            string firstPlayer = testPlayers.ToList()[0];
            string[] firstPlayerFields = firstPlayer.Split(',');

            string secondPlayer = testPlayers.ToList()[1];
            string[] secondPlayerFields = secondPlayer.Split(',');

            //Assert
            Assert.AreEqual("Aaron", firstPlayerFields[0]);
            Assert.AreEqual("Aaronson", firstPlayerFields[1]);

            Assert.AreEqual("Zeke", secondPlayerFields[0]);
            Assert.AreEqual("Zachary", secondPlayerFields[1]);
        }
    }
}
