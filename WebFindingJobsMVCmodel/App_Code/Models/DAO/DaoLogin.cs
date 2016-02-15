using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using Core;


namespace Models.DAO
{
    /// <summary>
    /// Summary description for DaoLogin
    /// </summary>
    public class DaoLogin:AccessDataBase
    {
        public DaoLogin()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable GetLoginInfo(string emailLogin)
        {
            try
            {
                Command.CommandText = "GetLoginInfo";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("EmailLogin", emailLogin);
                Connection.Open();
                var reader = Command.ExecuteReader();
                var data = new DataTable();
                data.Load(reader);
                return data;
            }
            catch (Exception exception)
            {
                return null;
                throw exception;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int CheckLogin(string email, string password)
        {
            try
            {
                Command.CommandText = "CheckLogin";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("EmailLogin", email);
                Command.Parameters.AddWithValue("Password", password);
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

        public int CheckIsadmin(int userId)
        {
            try
            {
                Command.CommandText = "SELECT  [IsAdmin]  FROM [dbo].[User] Where UserID=@UserID and IsAdmin=1";
                Command.CommandType = CommandType.Text;
                Command.Parameters.AddWithValue("@UserID", userId);
                Connection.Open();
                int returnValue = Convert.ToInt32(Command.ExecuteScalar());
                return returnValue;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
        }
        public bool CheckExistUser(string emailLogin)
        {
            try
            {
                Command.CommandText = "CheckExistLoginName";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("EmailLogin", emailLogin);
                Connection.Open();
                int returnValues = Convert.ToInt32(Command.ExecuteScalar());
                if (returnValues == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
        public bool CheckExistRecruitor(string emailLogin)
        {
            try
            {
                Command.CommandText = "CheckExistRecuitor";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("EmailLoginAsRecruitor", emailLogin);
                Connection.Open();
                int returnValues = Convert.ToInt32(Command.ExecuteScalar());
                if (returnValues == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
        public int AddARecruitorQuickly(string emailLogin, string recruitorName, string companyName, string address,
         string phone, int companysizeId)
        {
            try
            {
                Command.CommandText = "AddARecruitorQuickly";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("Email", emailLogin);
                Command.Parameters.AddWithValue("RecruitorName", recruitorName);
                Command.Parameters.AddWithValue("CompanyName", companyName);
                Command.Parameters.AddWithValue("Address", address);
                Command.Parameters.AddWithValue("PhoneToCallForJob", phone);
                Command.Parameters.AddWithValue("CompanySizeID", companysizeId);
                Connection.Open();
                var returnValues = Convert.ToInt32(Command.ExecuteScalar());
                return returnValues;
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
        public int AddAnUserQuickly(string emailLogin, string firstName, string lastName, DateTime dateOfBirth, int sexId, int typeUser)
        {
            try
            {
                Command.CommandText = "AddAnUserQuickly";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("Email", emailLogin);
                Command.Parameters.AddWithValue("FirstName", firstName);
                Command.Parameters.AddWithValue("LastName", lastName);
                Command.Parameters.AddWithValue("DateOfBirth", dateOfBirth);
                Command.Parameters.AddWithValue("SexID", sexId);
                Command.Parameters.AddWithValue("IsAdmin", typeUser);
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
  public int AddAnAdminQuickly(string emailLogin, string firstName, string lastName, DateTime dateOfBirth, string phone, int typeUser)
        {
            try
            {
                Command.CommandText = "AddAnAdminQuickly";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("Email", emailLogin);
                Command.Parameters.AddWithValue("FirstName", firstName);
                Command.Parameters.AddWithValue("LastName", lastName);
                Command.Parameters.AddWithValue("DateOfBirth", dateOfBirth);
                Command.Parameters.AddWithValue("Phone", phone);
                Command.Parameters.AddWithValue("IsAdmin", typeUser);
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

        public int AddARecruitorLogin(string emailLogin, string loginPass, int recruitorId,string randomCode, DateTime registrationDate)
        {
            string pass = Md5Encrypt(loginPass);
            try
            {
                Command.CommandText = "AddARegistrationAsRecruitor";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("EmailLogin", emailLogin);
                Command.Parameters.AddWithValue("PassWord", pass);
                Command.Parameters.AddWithValue("RecruitorID", recruitorId);
                Command.Parameters.AddWithValue("RandomCode", randomCode);
                Command.Parameters.AddWithValue("RegistrationDate", registrationDate);
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
        public int AddALogin(string emailLogin, string loginPass, int userId, string Captcha, DateTime registrationDate)
        {
            string pass = Md5Encrypt(loginPass);
            try
            {
                Command.CommandText = "AddARegistrationAdmin";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("EmailLogin", emailLogin);
                Command.Parameters.AddWithValue("PassWord", pass);
                Command.Parameters.AddWithValue("UserID", userId);
                Command.Parameters.AddWithValue("Captcha", Captcha);
                Command.Parameters.AddWithValue("RegistrationDate", registrationDate);
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
        public bool ChangePassWord(string emailLogin, string passWord)
        {
            string newPass = Md5Encrypt(passWord);
            try
            {
                Command.CommandText = "ChangePassWord";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("EmailLogin", emailLogin);
                Command.Parameters.AddWithValue("PassWord", newPass);
                Connection.Open();
                int returnValues = Convert.ToInt32(Command.ExecuteScalar());
                Connection.Close();
                if (returnValues == 1)
                {
                    return true;
                }
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }

        public DataSet VerifyInfo(string vefifyCode)
        {
            try
            {
                var da=new SqlDataAdapter();
                Command.CommandText = "VerifyAccount";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("VerifyCode", vefifyCode);
                da.SelectCommand = Command;
                var data = new DataSet();
                Connection.Open();
                da.Fill(data);
                return data;
            }
            catch (Exception exception)
            {
                Console.Write(exception.ToString());
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
        public DataSet VerifyRecruitorInfo(string vefifyCode)
        {
            try
            {
                var da = new SqlDataAdapter();
                Command.CommandText = "VerifyAccountForRecruitor";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("VerifyCode", vefifyCode);
                da.SelectCommand = Command;
                var data = new DataSet();
                Connection.Open();
                da.Fill(data);
                return data;
            }
            catch (Exception exception)
            {
                Console.Write(exception.ToString());
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }

        public object RecoverPassInfo( string email,string token)
        {
            string newPass = Md5Encrypt(token);
            try
            {
                Command.CommandText = "RecoverPassword";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("Email", email);
                Command.Parameters.AddWithValue("Token", newPass);
                Connection.Open();
                object returnValues = Command.ExecuteScalar();
                return returnValues;
            }
            catch (Exception exception)
            {
                Console.Write(exception.ToString());
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }

        public object ResetPass(string email, string passWord,string token)
        {
            string newPass = Md5Encrypt(passWord);
            try
            {
                Command.CommandText = "ResetPassword";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("EmailLogin", email);
                Command.Parameters.AddWithValue("Password", newPass);
                Command.Parameters.AddWithValue("Token", token);
                Connection.Open();
                object returnValues = Command.ExecuteScalar();
                return returnValues;
            }
            catch (Exception exception)
            {
                Console.Write(exception.ToString());
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}