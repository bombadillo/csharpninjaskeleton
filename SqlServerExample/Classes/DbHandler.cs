namespace SqlServerExample.Classes
{
    using System;
    using System.Linq;
    using Dapper;
    using Interfaces;
    using System.Collections.Generic;

    public class DbHandler<T> : IHandleDb<T>
    {
        private readonly IHandleDbConnection DbConnectionHandler;
        private readonly ILoadSql SqlLoader;

        public DbHandler(IHandleDbConnection dbConnectionHandler, ILoadSql sqlLoader)
        {
            DbConnectionHandler = dbConnectionHandler;
            SqlLoader = sqlLoader;
        }

        public T GetById(string sqlFile, int id)
        {
            var sql = SqlLoader.LoadFromFile(sqlFile);
            DbConnectionHandler.GetConnection();

            using (var con = DbConnectionHandler.Con)
            {
                return con.Query<T>(sql, new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<T> GetAll(string sqlFile, object queryArguments = null,
            object[] templateArguments = null)
        {
            var sql = SqlLoader.LoadFromFile(sqlFile, templateArguments);

            DbConnectionHandler.GetConnection();

            using (var con = DbConnectionHandler.Con)
            {
                return con.Query<T>(sql, queryArguments);
            }
        }


        public T GetByCustomSql(string sqlFile, object queryArguments = null, object[] templateArguments = null)
        {
            var sql = SqlLoader.LoadFromFile(sqlFile, templateArguments);
            DbConnectionHandler.GetConnection();

            using (var con = DbConnectionHandler.Con)
            {
                return con.Query<T>(sql, queryArguments).FirstOrDefault();
            }
        }

        public bool Insert(string sqlFile, object queryArguments = null, object[] templateArguments = null)
        {
            var sql = SqlLoader.LoadFromFile(sqlFile, templateArguments);
            DbConnectionHandler.GetConnection();

            try
            {
                using (var con = DbConnectionHandler.Con)
                {
                    var result = con.Execute(sql, queryArguments);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
