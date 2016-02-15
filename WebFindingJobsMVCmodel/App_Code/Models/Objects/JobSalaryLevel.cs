namespace Models.Objects
{
    /// <summary>
    /// Summary description for JobSalaryLevel
    /// </summary>
    public class JobSalaryLevel
    {
        private string _jobSalaryLevelId;
        private string _salaryLevel;

        public JobSalaryLevel()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public JobSalaryLevel(string id, string level)
        {
            JobSalaryLevelId = id;
            SalaryLevel = level;
        }

        public string JobSalaryLevelId
        {
            get { return _jobSalaryLevelId; }
            set { _jobSalaryLevelId = value; }
        }

        public string SalaryLevel
        {
            get { return _salaryLevel; }
            set { _salaryLevel = value; }
        }
    }
}