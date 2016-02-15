namespace Models.Objects
{
    /// <summary>
    /// Summary description for Address
    /// </summary>
    public class Address
    {
        private Province _province;
        private District _district;

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

        public Address(Province province, District district)
        {
            this.Province = province;
            this.District = district;
        }

        public Address()
        {
            Province = new Province();
            District = new District();
        }
    }
}