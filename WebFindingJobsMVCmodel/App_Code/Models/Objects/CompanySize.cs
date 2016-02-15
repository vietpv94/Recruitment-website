namespace Models.Objects
{
    /// <summary>
    /// Summary description for CompanySize
    /// </summary>
    public class CompanySize
    {
        private string _companySizeId;
        private string _sizeOfCompany;

        public CompanySize()
        {
            CompanySizeId = string.Empty;
            SizeOfCompany = string.Empty;
        }

        public CompanySize(string id, string size)
        {
            CompanySizeId = id;
            SizeOfCompany = size;
        }

        public CompanySize(int id, string size)
        {
            CompanySizeId = id.ToString();
            SizeOfCompany = size;
        }

        public string CompanySizeId
        {
            get { return _companySizeId; }
            set { _companySizeId = value; }
        }

        public string SizeOfCompany
        {
            get { return _sizeOfCompany; }
            set { _sizeOfCompany = value; }
        }
    }
}