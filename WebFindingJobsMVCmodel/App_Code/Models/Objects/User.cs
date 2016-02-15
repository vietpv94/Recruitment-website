using System;
using System.Data;
using Models.DAO;

namespace Models.Objects
{
    /// <summary>
    /// Summary description for User
    /// </summary>
    public class User
    {
        private string _userId;
        private string _lastName;
        private string _firstName;
        private DateTime _dateBirthDay;
        private string _email;
        private Sex _sex;
        private Races _races;
        private string _phoneNumber;
        private District _district;
        private Province _province;
        private Address _address;
        private JobIndustries _jobIndustries;
        private string _maximOfLife;
        private string _thumImg;
      

        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public DateTime DateBirthDay
        {
            get { return _dateBirthDay; }
            set { _dateBirthDay = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public Sex Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        public District District
        {
            get { return _district; }
            set { _district = value; }
        }

        public Province Province
        {
            get { return _province; }
            set { _province = value; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public Races Races
        {
            get { return _races; }
            set { _races = value; }
        }

        public string MaximOfLife
        {
            get { return _maximOfLife; }
            set { _maximOfLife = value; }
        }

        public JobIndustries JobIndustries
        {
            get { return _jobIndustries; }
            set { _jobIndustries = value; }
        }

        public string ThumImg
        {
            get { return _thumImg; }
            set { _thumImg = value; }
        }

        public User()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public User(string id)
        {
            UserId = id;
        }
        public User(string email, string id)
        {
            Email = email;
            UserId = id;
        }
        public User(string email, string id, string firstName)
        {
            Email = email;
            UserId = id;
            FirstName = firstName;
        }
        public User(string id, string email, string firstName,DateTime birthDay, Sex sex, Address address)
        {
            UserId = id;
            Email = email;
            DateBirthDay = birthDay;
            Sex = sex;
            PhoneNumber = String.Empty;
            Address = address;
            FirstName = firstName;

        }
        public void SetFullInfo()
        {
            var dao = new DaoUser();
            DataTable infoTable = dao.GetFullUserInforById(Convert.ToInt32(UserId));

            FirstName = infoTable.Rows[0]["FirstName"].ToString();
            LastName = infoTable.Rows[0]["LastName"].ToString();
            DateBirthDay = Convert.ToDateTime(infoTable.Rows[0]["DateOfBirth"]);
            Sex = new Sex(infoTable.Rows[0]["SexID"].ToString(), infoTable.Rows[0]["SexName"].ToString());
            PhoneNumber = infoTable.Rows[0]["PhoneNumber"].ToString();
            Races = new Races(infoTable.Rows[0]["RaceID"].ToString(), infoTable.Rows[0]["RaceName"].ToString());
            Province = new Province( infoTable.Rows[0]["ProvinceID"].ToString(),infoTable.Rows[0]["ProvinceName"].ToString());
            District = new District(infoTable.Rows[0]["DistrictID"].ToString(), infoTable.Rows[0]["DistrictName"].ToString(),
                Province, Convert.ToInt32(infoTable.Rows[0]["Latitude"]), Convert.ToInt32(infoTable.Rows[0]["Longitude"]));
            Address = new Address(Province, District);
            JobIndustries = new JobIndustries(infoTable.Rows[0]["JobIndustryID"].ToString(),infoTable.Rows[0]["JobIndustryName"].ToString());
            MaximOfLife = infoTable.Rows[0]["MaximOfLife"].ToString();
            ThumImg = infoTable.Rows[0]["PhotoPath"].ToString();
        }
        public bool SetFullInfo(string firtname, string lastname, DateTime birthDay, Sex sex, string phoneNumber, JobIndustries job, Address address,
           Races races, string maxim,string thumImg)
        {
            FirstName=firtname;
            LastName = lastname;
            DateBirthDay = birthDay;
            Sex = sex;
            PhoneNumber = phoneNumber;
            JobIndustries = job;
            Address = address;
            Races = races;
            MaximOfLife = maxim;
            ThumImg = thumImg;
            return SaveInfo();
        }

        public bool SaveInfo()
        {
            var dao = new DaoUser();
            int temp = dao.EditUserInfo(Convert.ToInt32(UserId), FirstName,LastName, DateBirthDay, Convert.ToInt32(Sex.SexId), PhoneNumber, Convert.ToInt32(JobIndustries.JobIndutriesId), Convert.ToInt32(Address.District.Id),
                Convert.ToInt32(Races.RaceId), MaximOfLife,ThumImg);
            if (temp > 0)
            {
                return true;
            }

            return false;
        }
   
    }
}