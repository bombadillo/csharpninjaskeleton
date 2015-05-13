namespace LaserAndCrmAddressAnalysis.Classes
{
    using Interfaces;
    using System.Configuration;
    using System.Collections.Generic;

    public class App : IApp
    {
        private readonly ILog Logger;
        private readonly IReadCsv CsvReader;

        public App(ILog logger, IReadCsv csvReader)
        {
            Logger = logger;
            CsvReader = csvReader;
        }

        public void Run()
        {
            Logger.Trace("Started");         
        }
    }
}
