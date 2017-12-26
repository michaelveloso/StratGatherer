using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StratGatherer.Csv
{
    /// <summary>
    /// Reads a csv file and returns each line in a collection of strings.
    /// </summary>
    public static class CsvReader
    {
        /// <summary>
        /// Given a filepath for a csv, reads the csv and parses it into a collection of strings, including the header.
        /// </summary>
        /// <param name="fileLocation">The filepath for the csv.</param>
        /// <returns>A collection of strings, where each string is a line in the csv, including the header.</returns>
        public static IEnumerable<string> ReadCsvWithHeader(string fileLocation)
        {
            return ReadCsv(fileLocation);
        }
        /// <summary>
        /// Given a filepath for a csv, reads the csv and parses it into a collection of strings, excluding the header.
        /// </summary>
        /// <param name="fileLocation">The filepath for the csv.</param>
        /// <returns>A collection of strings, where each string is a line in the csv, excluding the header.</returns>
        public static IEnumerable<string> ReadCsvWithoutHeader(string fileLocation)
        {
            IEnumerable<string> csvLines = ReadCsv(fileLocation);
            return RemoveHeader(csvLines);
        }

        private static IEnumerable<string> ReadCsv(string fileLocation)
        {
            if (!FileIsCsv(fileLocation))
            {
                throw new ArgumentException(string.Format("{0} is not a csv.", fileLocation));
            }

            StreamReader file = new StreamReader(fileLocation);
            string csvLine;
            IList<string> csvLines = new List<string>();

            while ((csvLine = file.ReadLine()) != null)
            {
                csvLines.Add(csvLine);
            }

            return csvLines;
        }

        private static IEnumerable<string> RemoveHeader(IEnumerable<string> csvLines)
        {
            return csvLines.Skip(1).ToList();
        }

        private static bool FileIsCsv(string fileLocation)
        {
            string fileExtension = fileLocation.Substring(fileLocation.Length - 3);
            return fileExtension == "csv";
        }
    }
}
