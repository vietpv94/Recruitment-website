namespace Models.Objects
{

    /// <summary>
    /// Summary description for District
    /// </summary>
    public class District
    {
        private string _id;
        private string _districtName;
        private decimal _latitude;
        private decimal _longitude;
        private Province _province;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string DistrictName
        {
            get { return _districtName; }
            set { _districtName = value; }
        }

        public decimal Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        public decimal Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        public Province Province
        {
            get { return _province; }
            set { _province = value; }
        }

        public District(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Id = string.Empty;
            DistrictName = string.Empty;
            Province = new Province();
        }

        public District()
        {

        }

        public District(string id, string name)
        {
            Id = id;
            DistrictName = name;
        }

        public District(string id, string name, Province province, decimal latitude, decimal longitude)
        {
            Id = id;
            DistrictName = name;
            Province = province;
            Latitude = latitude;
            Longitude = longitude;
        }

        public District(string id, string name, Province province)
        {
            Id = id;
            DistrictName = name;
            Latitude = 0;
            Longitude = 0;
            Province = province;
        }
    }
}