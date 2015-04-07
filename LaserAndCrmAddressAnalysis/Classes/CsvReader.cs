

namespace LaserAndCrmAddressAnalysis.Classes
{
    using System.Collections.Generic;
    using System.IO;
    using Interfaces;

    public class CsvReader : IReadCsv
    {

        public bool ReadFile(string fileName)
        {
            var reader = new StreamReader(File.OpenRead(fileName));
            var csvList = new List<string[]>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                csvList.Add(values);
            }

            CsvList = csvList;

            return csvList.Count > 0;
        }


        public List<string[]> CsvList { get; set; }
    }
}
