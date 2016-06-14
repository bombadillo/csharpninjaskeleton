namespace SqlServerExample.Interfaces
{
    using System.Collections.Generic;

    public interface IHandleDb<T>
    {
        T GetById(string sqlFile, int id);
        T GetByCustomSql(string sqlFile, object queryArguments = null, object[] templateArguments = null);
        IEnumerable<T> GetAll(string sqlFile, object queryArguments = null, object[] templateArguments = null);
        bool Insert(string sqlFile, object queryArguments = null, object[] templateArguments = null);
    }
}
