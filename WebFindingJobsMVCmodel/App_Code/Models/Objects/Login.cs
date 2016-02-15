using System;
using System.Data;
using Base;
using Models.DAO;

namespace Models.Objects
{
    /// <summary>
    /// Summary description for Login
    /// </summary>
    public class Login:Utilities
    {
        private string _emailLogin;
        private string _password;
        private DateTime _registrationTime;


        public string EmailLogin
        {
            get { return _emailLogin; }
            set { _emailLogin = value; }
        }

        public DateTime RegistrationTime
        {
            get { return _registrationTime; }
            set { _registrationTime = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public Login()
        {
        }
        public Login(string emaillogin, string pass, DateTime registrationDate)
        {
            EmailLogin = emaillogin;
            Password = Md5Encrypt(pass);
            RegistrationTime = registrationDate;
        }
        public Login(string emailLogin, string pass)
        {
            EmailLogin = emailLogin;
            Password = Md5Encrypt(pass);
            RegistrationTime = DateTime.Now;
        }

        public bool CheckAdmin(int userId)
        {
            var dao = new DaoLogin();
            int isAdmin = dao.CheckIsadmin(userId);
            if (isAdmin != 0)
            {
                return true;
            }
            return false;
        }
        public int CheckLogin()
        {
            var daObject = new DaoLogin();
            int vcl = daObject.CheckLogin(EmailLogin, Password);
            if (vcl != 0)
            {
                return vcl;
            }
            return 0;
        }

        public void GetFullInfo()
        {
            var dataAccess = new DaoLogin();
            var dataTable = dataAccess.GetLoginInfo(EmailLogin);
            EmailLogin = dataTable.Rows[0]["EmailLogin"].ToString();
            Password = dataTable.Rows[0]["PassWordLogin"].ToString();
            RegistrationTime = Convert.ToDateTime(dataTable.Rows[0]["RegistrationDate"]);
        }

        public DataTable GetUserInfo(int type)
        {
            try
            {
                var dao = new DaoUser();
                return dao.GetUserInfoByEmailLogin(EmailLogin, type);
            }
            catch (Exception )
            {
                return null;
            }
               
        }

        public bool ChangePassWord(string newPassWord)
        {
            var dao = new DaoLogin();
            return dao.ChangePassWord(EmailLogin, newPassWord);
        }
    }
}