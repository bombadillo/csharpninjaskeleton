namespace LaserAndCrmAddressAnalysis.Classes
{
    using Interfaces;

    public class App : IApp
    {
        private readonly ILog Logger;

        public App(ILog logger)
        {
            Logger = logger;
        }

        public void Run()
        {
            Logger.Trace("Started");         
        }
    }
}
