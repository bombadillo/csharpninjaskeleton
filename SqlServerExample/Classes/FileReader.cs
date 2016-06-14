namespace SqlServerExample.Classes
{
    using System;
    using Interfaces;
    using System.IO;

    public class FileReader : IReadFiles
    {
        private readonly ILog Logger;

        public FileReader(ILog logger)
        {
            Logger = logger;
        }

        public string ReadFileToString(string fileName)
        {
            string contents;

            try
            {
                contents = File.ReadAllText(fileName);
            }
            catch (Exception e)
            {
                contents = null;
                Logger.Error(e.Message + e.StackTrace);
            }

            return contents;
        }
    }
}