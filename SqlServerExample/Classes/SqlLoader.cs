namespace SqlServerExample.Classes
{
    using System.Configuration;
    using Interfaces;

    public class SqlLoader : ILoadSql
    {
        private readonly IReadFiles FileReader;

        public SqlLoader(IReadFiles fileReader)
        {
            FileReader = fileReader;
        }

        public string LoadFromFile(string fileName, object[] arguments = null)
        {
            var sqlFolder = ConfigurationManager.AppSettings["SqlDirectory"];
            var sqlFileLocation = string.Format("{0}{1}.sql", sqlFolder, fileName);
            var sql = FileReader.ReadFileToString(sqlFileLocation);
            return sql;
        }
    }
}