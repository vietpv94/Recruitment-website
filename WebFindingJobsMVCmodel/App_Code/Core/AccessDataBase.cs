using System.Data.SqlClient;
using System.Web.Configuration;
using Base;

namespace Core
{
    /// <summary>
    /// Summary description for AccessDataBase
    /// </summary>
    public class AccessDataBase:Utilities
    {
        public SqlConnection Connection;
        public SqlCommand Command;
        public AccessDataBase()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["KenhTimViecLamConnection"].ConnectionString;
            Connection = new SqlConnection(connectionString);
            Command = new SqlCommand();
            Command.Connection = Connection;
        }
    }
}
