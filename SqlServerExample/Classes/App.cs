namespace SqlServerExample.Classes
{
    using System.Configuration;
    using Interfaces;
    using Models;

    public class App : IApp
    {
        private readonly ILog Logger;
        private readonly IHandleDb<Test> DbHandler;

        private readonly string TestSql = ConfigurationManager.AppSettings["SqlTest"];

        public App(ILog logger, IHandleDb<Test> dbHandler)
        {
            Logger = logger;
            DbHandler = dbHandler;
        }

        public void Run()
        {
            Logger.Info("App started");

            var models = DbHandler.GetAll(TestSql);

            Logger.Info("App ended");
        }
    }
}
