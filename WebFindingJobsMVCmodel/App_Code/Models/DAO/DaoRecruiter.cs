using System;
using System.Data;
using Core;

namespace Models.DAO
{
    /// <summary>
    /// Summary description for DaoRecruiter
    /// </summary>
    public class DaoRecruiter:AccessDataBase
    {
        public DaoRecruiter()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetRecruitorInfoByEmail(string email)
        {
            try
            {
                Command.CommandText = "GetRecruiterLoginInfo";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("EmailLogin", email);
                Connection.Open();
                var reader = Command.ExecuteReader();
                var dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
            }
            catch (Exception )
            {
                
                return null;
                
            }
            finally
            {
                Connection.Close();
            }
        }
        public DataTable GetRecruiterAccounts()
        {
            try
            {
                Command.CommandText = "GetRcruitorAcounts";
                Command.CommandType = CommandType.StoredProcedure;
                Connection.Open();
                var reader = Command.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
        public DataTable GetFullRecruiterInfoById(int recruiterId)
        {
            try
            {
                Command.CommandText = "GetFullRecruiterInfoById";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("RecruitorID", recruiterId);
                Connection.Open();
                var reader = Command.ExecuteReader();
                var dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }  
        public DataTable GetRecruiterInfoById(int recruiterId)
        {
            try
            {
                Command.CommandText = "GetRecruiterInfoById";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("RecruitorID", recruiterId);
                Connection.Open();
                var reader = Command.ExecuteReader();
                var dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}