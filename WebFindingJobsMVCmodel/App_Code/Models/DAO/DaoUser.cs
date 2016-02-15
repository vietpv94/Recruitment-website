using System;
using System.Data;
using Core;

namespace Models.DAO
{
    /// <summary>
    /// Summary description for DaoUser
    /// </summary>
    public class DaoUser : AccessDataBase
    {
        public DaoUser()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable GetFullUserInforById(int userId)
        {
            try
            {
                Command.CommandText = "GetFullUserInfoById";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("UserId", userId);
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
        public DataTable GetUserInfoByEmailLogin(string emailLogin, int type)
        {
            try
            {
                Command.CommandText = "GetUserInfoByEmailLogin";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("EmailLogin", emailLogin);
                Command.Parameters.AddWithValue("Type", type);
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
        public int EditUserInfo(int userId, string firstName, string lastName, DateTime birthDay, int sexId, string phoneNumber, int jobId, int districtId, int raceId, string maxim, string thumbImg)
        {
            try
            {
                Command.CommandText = "EditUserInfo";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("UserID", userId);
                Command.Parameters.AddWithValue("FirstName", firstName);
                Command.Parameters.AddWithValue("LastName", lastName);
                Command.Parameters.AddWithValue("DateOfBirth", birthDay);
                Command.Parameters.AddWithValue("SexID", sexId);
                Command.Parameters.AddWithValue("PhoneNumber", phoneNumber);
                Command.Parameters.AddWithValue("JobIndustryID", jobId);
                Command.Parameters.AddWithValue("DistrictID", districtId);
                Command.Parameters.AddWithValue("RaceID", raceId);
                Command.Parameters.AddWithValue("MaximOfLife", maxim);
                Command.Parameters.AddWithValue("ThumImg", thumbImg);
                Connection.Open();
                int returnValue = Convert.ToInt32(Command.ExecuteScalar());

                return returnValue;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }
        public DataTable GetUserAccounts()
        {
            try
            {
                Command.CommandText = "GetUserAcounts";
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
     
        #region Dành cho admin
        public DataTable GetAccounts()
        {
            try
            {
                Command.CommandText = "GetAdminAcounts";
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

        public int BlockAnAcount(int userId)
        {
            try
            {
                Command.CommandText = "BlockAnAccount";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("UserID", userId);
                Connection.Open();
                int returnValue = Convert.ToInt32(Command.ExecuteScalar());
                return returnValue;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int UnlockAnAcount(int userId)
        {
            try
            {
                Command.CommandText = "UnlockAnAccount";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("UserID", userId);
                Connection.Open();
                int returnValue = Convert.ToInt32(Command.ExecuteScalar());
                return returnValue;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }
        public int BlockAnRecruitorAcount(int userId)
        {
            try
            {
                Command.CommandText = "BlockAnRecrutorAccount";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("UserID", userId);
                Connection.Open();
                int returnValue = Convert.ToInt32(Command.ExecuteScalar());
                return returnValue;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int UnlockAnRecruterAcount(int userId)
        {
            try
            {
                Command.CommandText = "UnlockAnRecrutorAccount";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("UserID", userId);
                Connection.Open();
                int returnValue = Convert.ToInt32(Command.ExecuteScalar());
                return returnValue;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }
        #endregion

    }
}