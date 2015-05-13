namespace LaserAndCrmAddressAnalysis.Classes
{
    using Interfaces;
    using System.Configuration;
    using System.Collections.Generic;

    public class App : IApp
    {
        private readonly ILog Logger;
        private readonly IReadCsv CsvReader;

        private readonly string LaserDataFile = ConfigurationManager.AppSettings["LaserDataFile"];
        private List<string[]> LaserDataContents; 

        public App(ILog logger, IReadCsv csvReader)
        {
            Logger = logger;
            CsvReader = csvReader;
        }

        public void Run()
        {
            Logger.Trace("Started");

            GetLaserContents();
        }

        private void GetLaserContents()
        {
            Logger.Trace("GetLaserContents()");

            var bRead = CsvReader.ReadFile(LaserDataFile);

            LaserDataContents = (bRead) ? CsvReader.CsvList : null;
        }
    }
}
