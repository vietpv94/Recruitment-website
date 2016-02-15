using System;
using System.Data;
using Models.DAO;

namespace Models.Objects
{
    /// <summary>
    /// Summary description for Recruitor
    /// </summary>
    public class Recruitor
    {
        private string _recruitorId;
        private string _recruitorName;
        private CompanySize _companySize;
        private string _companyFullname;
        private string _companyShortname;
        private string _address;
        private string _emailToSendResume;
        private string _phoneToCallForJob;
        private string _email;

        public Recruitor()
        {

        } 
        public Recruitor(string id)
        {
            var dao = new DaoRecruiter();
            DataTable infoTable = dao.GetRecruiterInfoById(Convert.ToInt32(id));
            CompanyFullname = infoTable.Rows[0]["CompanyFullName"].ToString();
            RecruitorId = id;
        }
  
        public Recruitor(string email, string id)
        {
            Email = email;
            RecruitorId = id;
        }
       
        public Recruitor(string email, int id)
        {
            Email = email;
            RecruitorId = id.ToString();
        }

        public Recruitor(string email, string id, string name)
        {
            Email = email;
            RecruitorId = id;
            CompanyFullname = name;
        }

        public Recruitor(string recruitorId, string emailLogin, string companyName, string recruitorName, string phone,
            string address)
        {
            RecruitorId = recruitorId;
            Email = emailLogin;
            CompanyFullname = companyName;
            RecruitorName = recruitorName;
            PhoneToCallForJob = phone;
            Address = address;
        }
        public Recruitor(string companyName, string recruitorName, CompanySize companySize,
           string address)
        {
            CompanyFullname = companyName;
            RecruitorName = recruitorName;
            CompanySize = companySize;
            Address = address;
        }

        public string RecruitorId
        {
            get { return _recruitorId; }
            set { _recruitorId = value; }
        }

        public string RecruitorName
        {
            get { return _recruitorName; }
            set { _recruitorName = value; }
        }

        public CompanySize CompanySize
        {
            get { return _companySize; }
            set { _companySize = value; }
        }

        public string CompanyFullname
        {
            get { return _companyFullname; }
            set { _companyFullname = value; }
        }

        public string CompanyShortname
        {
            get { return _companyShortname; }
            set { _companyShortname = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string EmailToSendResume
        {
            get { return _emailToSendResume; }
            set { _emailToSendResume = value; }
        }

        public string PhoneToCallForJob
        {
            get { return _phoneToCallForJob; }
            set { _phoneToCallForJob = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public void SetFullRecruiterInfo()
        {
            var dao = new DaoRecruiter();
            DataTable infoTable = dao.GetFullRecruiterInfoById(Convert.ToInt32(RecruitorId));

            CompanyFullname = infoTable.Rows[0]["CompanyFullName"].ToString();
            RecruitorName = infoTable.Rows[0]["RecruitorName"].ToString();
            CompanyShortname = infoTable.Rows[0]["CompanyShortName"].ToString();
            EmailToSendResume = infoTable.Rows[0]["EmailToSendResume"].ToString();
            Address = infoTable.Rows[0]["Address"].ToString();
            CompanySize = new CompanySize(infoTable.Rows[0]["CompanySizeID"].ToString(),
                infoTable.Rows[0]["CompanySize"].ToString());
            PhoneToCallForJob = infoTable.Rows[0]["PhoneToCallForJob"].ToString();
        }

        public bool SetFullCompanyInfo(string fullname, string shortname, CompanySize size, string address)
        {
            CompanyFullname = fullname;
            CompanyShortname = shortname;
            CompanySize = size;
            Address = address;
            return SaveCompanyInfo();
        }

        public bool SaveCompanyInfo()
        {
            var dao = new DaoCompany();
            int temp = dao.EditCompanyInfo(Convert.ToInt32(RecruitorId), CompanyFullname, CompanyShortname,
                Convert.ToInt32(CompanySize.CompanySizeId), Address);
            if (temp > 0)
            {
                return true;
            }

            return false;
        }


        public bool SetFullContactInfo(string recruitorName, string phoneContact, string emailContact)
        {
            RecruitorName = recruitorName;
            PhoneToCallForJob = phoneContact;
            EmailToSendResume = emailContact;
            return SaveContactInfo();
        }

        private bool SaveContactInfo()
        {
            var dao = new DaoCompany();
            int temp = dao.EditContactInfo(Convert.ToInt32(RecruitorId), RecruitorName, PhoneToCallForJob,
                EmailToSendResume);
            if (temp > 0)
            {
                return true;
            }

            return false;
        }
    }
}