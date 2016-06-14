namespace SqlServerExample.Classes
{
    using System;
    using System.Data.SqlClient;
    using Interfaces;
    using System.Configuration;

    public class DbConnectionHandler : IHandleDbConnection
    {
        private readonly ILog Logger;

        public SqlConnection Con { get; set; }

        private readonly string SqlConnectionString = ConfigurationManager.AppSettings["SqlConnectionString"];

        public DbConnectionHandler(ILog logger)
        {
            Logger = logger;
        }

        public bool GetConnection()
        {
            var connected = false;

            if (Con == null)
            {
                try
                {
                    Con = new SqlConnection(SqlConnectionString);
                    Logger.Trace("Connected to DB");
                    connected = true;
                }
                catch (Exception e)
                {
                    Logger.Fatal("Unable to connect to database. " + e.Message);
                    Environment.Exit(1);
                }
            }

            return connected;
        }
    }
}
