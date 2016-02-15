using System;
using System.Collections.Generic;
using System.Data;
using Models.DAO;

namespace Models.Objects
{
    /// <summary>
    /// Summary description for Jobs
    /// </summary>
    public class Jobs
    {
        private string _jobId;
        private Recruitor _recruitor;
        private JobPosition _jobPosition;
        private JobSalaryLevel _jobSalaryLevel;
        private Province _province;
        private WorkType _workType;
        private ExperienceLevel _experienceLevel;
        private Certificate _certificate;
        private DateTime _expiredDate;
        private JobIndustries _jobIndustries;
        private string _jobTitle;
        private string _contentDetail;
        private string _description;
        private string _rewriteUrl;
        private string _numsApplicant;
        private int _rank;
        public Jobs()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region contructor
        public Jobs(string id)
        {
            JobId = id;
        }

        public Jobs(string id, int rank)
        {
            JobId = id;
            Rank = rank;
        }
        public string JobId
        {
            get { return _jobId; }
            set { _jobId = value; }
        }

        public Recruitor Recruitor
        {
            get { return _recruitor; }
            set { _recruitor = value; }
        }

        public JobPosition JobPosition
        {
            get { return _jobPosition; }
            set { _jobPosition = value; }
        }

        public JobSalaryLevel JobSalaryLevel
        {
            get { return _jobSalaryLevel; }
            set { _jobSalaryLevel = value; }
        }

        public Province Province
        {
            get { return _province; }
            set { _province = value; }
        }

        public WorkType WorkType
        {
            get { return _workType; }
            set { _workType = value; }
        }

        public ExperienceLevel ExperienceLevel
        {
            get { return _experienceLevel; }
            set { _experienceLevel = value; }
        }

        public Certificate Certificate
        {
            get { return _certificate; }
            set { _certificate = value; }
        }

        public DateTime ExpiredDate
        {
            get { return _expiredDate; }
            set { _expiredDate = value; }
        }

        public JobIndustries JobIndustries
        {
            get { return _jobIndustries; }
            set { _jobIndustries = value; }
        }

        public string JobTitle
        {
            get { return _jobTitle; }
            set { _jobTitle = value; }
        }

        public string ContentDetail
        {
            get { return _contentDetail; }
            set { _contentDetail = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string RewriteUrl
        {
            get { return _rewriteUrl; }
            set { _rewriteUrl = value; }
        }

        public string NumsApplicant
        {
            get { return _numsApplicant; }
            set { _numsApplicant = value; }
        }

        public int Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }
        #endregion
        public void SetFullJobInfo()
        {
            var dao = new DaoJobs();
            DataTable infoTable = dao.GetFullJobInforById(Convert.ToInt32(JobId));

            ContentDetail = infoTable.Rows[0]["ContentDetail"].ToString();
            Description = infoTable.Rows[0]["Description"].ToString();
            JobTitle = infoTable.Rows[0]["FullTitle"].ToString();
            NumsApplicant = infoTable.Rows[0]["NumsApplicant"].ToString();
            ExpiredDate = Convert.ToDateTime(infoTable.Rows[0]["ExpiredDate"]);
            JobSalaryLevel = new JobSalaryLevel(infoTable.Rows[0]["SalaryLevelID"].ToString(), infoTable.Rows[0]["SalaryLevel"].ToString());
            JobIndustries = new JobIndustries(infoTable.Rows[0]["JobIndustryID"].ToString(), infoTable.Rows[0]["JobIndustryName"].ToString());
            Province = new Province(infoTable.Rows[0]["ProvinceID"].ToString(), infoTable.Rows[0]["ProvinceName"].ToString());
            JobPosition = new JobPosition(infoTable.Rows[0]["JobPositionID"].ToString(), infoTable.Rows[0]["JobPositionName"].ToString());
            JobIndustries = new JobIndustries(infoTable.Rows[0]["JobIndustryID"].ToString(), infoTable.Rows[0]["JobIndustryName"].ToString());
            WorkType = new WorkType(infoTable.Rows[0]["WorkTypeID"].ToString(), infoTable.Rows[0]["WorkTypeName"].ToString());
            Certificate = new Certificate(infoTable.Rows[0]["CertificateID"].ToString(), infoTable.Rows[0]["CertificateName"].ToString());
            ExperienceLevel = new ExperienceLevel(infoTable.Rows[0]["ExperienceLevelID"].ToString(), infoTable.Rows[0]["ExperienceLevelName"].ToString());
            RewriteUrl = infoTable.Rows[0]["RewriteUrl"].ToString();
            var companySize = new CompanySize(infoTable.Rows[0]["CompanySizeID"].ToString(), infoTable.Rows[0]["CompanySize"].ToString());
            Recruitor = new Recruitor(infoTable.Rows[0]["CompanyFullName"].ToString(), infoTable.Rows[0]["RecruitorName"].ToString(), companySize, infoTable.Rows[0]["Address"].ToString());
        }


        public int SetFullJobInfo(string jobTitle, Certificate certificate, JobSalaryLevel salary,
            Province location, JobIndustries category, string jobDatail, string jobDescription,
            DateTime expiredDate, JobPosition jobPosition, ExperienceLevel experience, WorkType type, Recruitor recruitor, string numsApplicant)
        {
            JobTitle = jobTitle;
            Certificate = certificate;
            JobSalaryLevel = salary;
            Province = location;
            JobIndustries = category;
            ContentDetail = jobDatail;
            Description = jobDescription;
            ExpiredDate = expiredDate;
            WorkType = type;
            JobPosition = jobPosition;
            ExperienceLevel = experience;
            Recruitor = recruitor;
            NumsApplicant = numsApplicant;
            return SaveJobInfo();
        }

        private int SaveJobInfo()
        {
            var dao = new DaoJobs();
            var temp = dao.AddAJobInfo(JobTitle, Convert.ToInt32(Certificate.CertificateId),
                Convert.ToInt32(JobSalaryLevel.JobSalaryLevelId),
                Convert.ToInt32(Province.Id), Convert.ToInt32(JobIndustries.JobIndutriesId), ContentDetail, Description,
                ExpiredDate, Convert.ToInt32(JobPosition.JobPositionId), Convert.ToInt32(ExperienceLevel.ExperianceLevelId),
                Convert.ToInt32(WorkType.WorkTypeId), Convert.ToInt32(Recruitor.RecruitorId), Convert.ToInt32(NumsApplicant));
            if (temp > 0)
            {
                return temp;
            }
            return 0;
        }

        public bool SetFullJobInfo(string jobTitle, Certificate certificate, JobSalaryLevel salary,
            Province location, JobIndustries category, string jobDatail,
            string jobDescription, DateTime deadLine, JobPosition jobPostion,
            ExperienceLevel jobExperienceLevel, WorkType worktype,
            Recruitor recruitor, string numsApplicant, string jobid)
        {
            JobId = jobid;
            JobTitle = jobTitle;
            Certificate = certificate;
            JobSalaryLevel = salary;
            Province = location;
            JobIndustries = category;
            ContentDetail = jobDatail;
            Description = jobDescription;
            ExpiredDate = deadLine;
            WorkType = worktype;
            JobPosition = jobPostion;
            ExperienceLevel = jobExperienceLevel;
            Recruitor = recruitor;
            NumsApplicant = numsApplicant;
            return SaveJobInfoUpdate();
        }

        private bool SaveJobInfoUpdate()
        {
            var dao = new DaoJobs();
            var temp = dao.UpdateAJobInfo(JobTitle, Convert.ToInt32(Certificate.CertificateId),
                Convert.ToInt32(JobSalaryLevel.JobSalaryLevelId),
                Convert.ToInt32(Province.Id), Convert.ToInt32(JobIndustries.JobIndutriesId), ContentDetail, Description,
                ExpiredDate, Convert.ToInt32(JobPosition.JobPositionId), Convert.ToInt32(ExperienceLevel.ExperianceLevelId),
                Convert.ToInt32(WorkType.WorkTypeId), Convert.ToInt32(Recruitor.RecruitorId), Convert.ToInt32(NumsApplicant), Convert.ToInt32(JobId));
            if (temp > 0)
            {
                return true;
            }
            return false;
        }
        public List<Resume> ResumesRanking()
        {
            try
            {
                var dao = new DaoResume();
                DataTable tableData = dao.GetResumeRecommended();
                var listRankResumes = new List<Resume>();

                if (tableData != null && tableData.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in tableData.Rows)
                    {
                        int rank = 1;
                        rank += JobPosition.JobPositionId == dataRow["JobPositionID"].ToString() ? 1 : 0;
                        rank += WorkType.WorkTypeId == dataRow["WorkTypeID"].ToString() ? 1 : 0;
                        rank += ExperienceLevel.ExperianceLevelId == dataRow["ExperienceLevelID"].ToString() ? 1 : 0;
                        rank += Certificate.CertificateId == dataRow["CertificateID"].ToString() ? 1 : 0;
                        rank += JobIndustries.JobIndutriesId == dataRow["JobIndustryID"].ToString() ? 1 : 0;
                        rank += JobSalaryLevel.JobSalaryLevelId == dataRow["SalaryLevelID"].ToString() ? 1 : 0;
                        switch (dataRow["SkillID"].ToString())
                        {

                            case "1":
                            case "2":
                                rank += 0;
                                break;
                            case "3":
                                rank += 1;
                                break;
                            case "4":
                            case "7":
                            case "8":
                            case "9":
                            case "10":
                                rank += 2;
                                break;
                            case "5":
                            case "6":
                                rank += 3;
                                break;
                            case "11":
                                rank -= 2;
                                break;
                            default: break;
                        }
                        var resume = new Resume(dataRow["ResumeID"].ToString(), rank);
                        resume.SetFullResumeInfo();
                        listRankResumes.Add(resume);
                    }
                }
                return listRankResumes;
            }
            catch (Exception exception)
            {
                
                Console.Write(exception);
                return null;
            }
        }
    }
}