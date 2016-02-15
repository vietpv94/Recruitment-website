namespace Models.Objects
{
    /// <summary>
    /// Summary description for JobIndustries
    /// </summary>
    public class JobIndustries
    {
        private string _jobIndutriesId;
        private string _jobIndustriesName;

        public JobIndustries(string id, string name)
        {
            JobIndustriesName = name;
            JobIndutriesId = id;
        }

        public JobIndustries()
        {
            JobIndustriesName = "";
            JobIndutriesId = "";
        }

        public JobIndustries(int id,string name)
        {
            JobIndustriesName = name;
            JobIndutriesId = id.ToString();
        }

        public string JobIndustriesName
        {
            get { return _jobIndustriesName; }
            set { _jobIndustriesName = value; }
        }

        public string JobIndutriesId
        {
            get { return _jobIndutriesId; }
            set { _jobIndutriesId = value; }
        }
    }
}