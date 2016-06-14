namespace SqlServerExample.Interfaces
{
    using System.Data.SqlClient;

    public interface IHandleDbConnection
    {
        SqlConnection Con { get; set; }
        bool GetConnection();
    }
}
