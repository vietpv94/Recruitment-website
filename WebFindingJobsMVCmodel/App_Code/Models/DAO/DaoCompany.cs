using System;
using System.Data;
using Core;

namespace Models.DAO
{
    /// <summary>
    /// Summary description for DaoCompany
    /// </summary>
    public class DaoCompany:AccessDataBase
    {
        public DaoCompany()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable GetCompanyInfo()
        {
            try
            {
                Command.CommandText = "get_ads_jobs";
                Command.CommandType = CommandType.StoredProcedure;
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
        public int EditCompanyInfo(int recruitorid, string companyFullname, string companyShortname, int companysizeid, string address)
        {
            try
            {
                Command.CommandText = "EditCompanyInfo";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("RecruitorID", recruitorid);
                Command.Parameters.AddWithValue("CompanyFullName", companyFullname);
                Command.Parameters.AddWithValue("CompanyShortName", companyShortname);
                Command.Parameters.AddWithValue("CompanySizeId", companysizeid);
                Command.Parameters.AddWithValue("Address", address);
                Connection.Open();
                var returnValues = Convert.ToInt32(Command.ExecuteScalar());
                return returnValues;
            }
            catch (Exception)
            {
                return 0;
            }
            finally { Connection.Close(); }
        }

        public int EditContactInfo(int recruitorId, string recruitorName, string phoneToCallForJob, string emailToSendResume)
        {
            try
            {
                Command.CommandText = "EditContactInfo";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("RecruitorID", recruitorId);
                Command.Parameters.AddWithValue("RecruitorName", recruitorName);
                Command.Parameters.AddWithValue("PhoneToCallForJob", phoneToCallForJob);
                Command.Parameters.AddWithValue("EmailToSendResume", emailToSendResume);
                Connection.Open();
                var returnValues = Convert.ToInt32(Command.ExecuteScalar());
                return returnValues;
            }
            catch (Exception)
            {
                return 0;
            }
            finally { Connection.Close(); }
        }
    }
}