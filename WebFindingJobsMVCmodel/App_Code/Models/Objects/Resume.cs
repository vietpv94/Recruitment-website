using System;
using System.Collections.Generic;
using System.Data;
using Models.DAO;

namespace Models.Objects
{
    /// <summary>
    /// Summary description for Resume
    /// </summary>
    public class Resume
    {
        private JobPosition _jobPosition;
        private JobIndustries _jobIndustries;
        private JobSalaryLevel _jobSalaryLevel;
        private Province _province;
        private WorkType _workType;
        private ExperienceLevel _experienceLevel;
        private string _resumeName;
        private string _contactEmail;
        private string _achievement;
        private User _user;
        private LangSkill _langSkill;
        private string _careerGoal;
        private string _workExperience;
        private string _literacy;
        private string _skill;
        private string _reference;
        private string _resumeId;
        private string _atachment;
        private Certificate _certificate;
        private int _rank;
        public Resume()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public Resume(string id, string name)
        {
            ResumeId = id;
            ResumeName = name;
        }    public Resume(string id, int rank)
        {
            ResumeId = id;
            Rank = rank;
        }
        
        public Resume(User user)
        {
            User = user;
        }

        public Resume(string resumeid)
        {

            ResumeId = resumeid;
        }
        public JobPosition JobPosition
        {
            get { return _jobPosition; }
            set { _jobPosition = value; }
        }

        public JobIndustries JobIndustries
        {
            get { return _jobIndustries; }
            set { _jobIndustries = value; }
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

        public string ResumeName
        {
            get { return _resumeName; }
            set { _resumeName = value; }
        }

        public string ContactEmail
        {
            get { return _contactEmail; }
            set { _contactEmail = value; }
        }

        public string Achievement
        {
            get { return _achievement; }
            set { _achievement = value; }
        }

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public LangSkill LangSkill
        {
            get { return _langSkill; }
            set { _langSkill = value; }
        }

        public string CareerGoal
        {
            get { return _careerGoal; }
            set { _careerGoal = value; }
        }

        public string WorkExperience
        {
            get { return _workExperience; }
            set { _workExperience = value; }
        }

        public string Literacy
        {
            get { return _literacy; }
            set { _literacy = value; }
        }

        public string Skill
        {
            get { return _skill; }
            set { _skill = value; }
        }

        public string Reference
        {
            get { return _reference; }
            set { _reference = value; }
        }

        public string ResumeId
        {
            get { return _resumeId; }
            set { _resumeId = value; }
        }

        public Certificate Certificate
        {
            get { return _certificate; }
            set { _certificate = value; }
        }

        public string Atachment
        {
            get { return _atachment; }
            set { _atachment = value; }
        }

        public int Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        public bool SetFullResumeInfo(string resumeTitle, Certificate certificate, JobSalaryLevel salary,
            LangSkill langSkill, Province location, JobIndustries category, JobPosition expectedPosition,
            ExperienceLevel jobExperienceLevel, WorkType worktype, string jobAchievement, string careerGoal,
            string experience, string literacy, string skill, string reference, User user, string contactMail, string attachment)
        {

            ResumeName = resumeTitle;
            Certificate = certificate;
            JobSalaryLevel = salary;
            LangSkill = langSkill;
            Province = location;
            JobIndustries = category;
            JobPosition = expectedPosition;
            ExperienceLevel = jobExperienceLevel;
            WorkType = worktype;
            Achievement = jobAchievement;
            CareerGoal = careerGoal;
            WorkExperience = experience;
            Literacy = literacy;
            Skill = skill;
            Reference = reference;
            User = user;
            ContactEmail = contactMail;
            Atachment = attachment;
            return SaveResumeInfo();
        }
        public bool SetFullResumeInfoUpdate(string resumeTitle, Certificate certificate, JobSalaryLevel salary,
            LangSkill langSkill, Province location, JobIndustries category, JobPosition expectedPosition,
            ExperienceLevel jobExperienceLevel, WorkType worktype, string jobAchievement, string careerGoal,
            string experience, string literacy, string skill, string reference, User user, string contactMail, string resumeId, string attachFile)
        {
            ResumeId = resumeId;
            ResumeName = resumeTitle;
            Certificate = certificate;
            JobSalaryLevel = salary;
            LangSkill = langSkill;
            Province = location;
            JobIndustries = category;
            JobPosition = expectedPosition;
            ExperienceLevel = jobExperienceLevel;
            WorkType = worktype;
            Achievement = jobAchievement;
            CareerGoal = careerGoal;
            WorkExperience = experience;
            Literacy = literacy;
            Skill = skill;
            Reference = reference;
            User = user;
            ContactEmail = contactMail;
            Atachment = attachFile;
            return SaveResumeInfoUpdate();
        }

        private bool SaveResumeInfoUpdate()
        {
            var dao = new DaoResume();
            var temp = dao.AddAResumeInfoUpdate(ResumeName, Convert.ToInt32(Certificate.CertificateId),
                Convert.ToInt32(JobSalaryLevel.JobSalaryLevelId),
                Convert.ToInt32(LangSkill.SillId), Convert.ToInt32(Province.Id),
                Convert.ToInt32(JobIndustries.JobIndutriesId), Convert.ToInt32(JobPosition.JobPositionId)
                , Convert.ToInt32(ExperienceLevel.ExperianceLevelId), Convert.ToInt32(WorkType.WorkTypeId), Achievement,
                CareerGoal, WorkExperience, Literacy, Skill, Reference, Convert.ToInt32(User.UserId), ContactEmail, Convert.ToInt32(ResumeId), Atachment);
            if (temp > 0)
            {
                return true;
            }
            return false;
        }

        private bool SaveResumeInfo()
        {
            var dao = new DaoResume();
            var temp = dao.AddAResumeInfo(ResumeName, Convert.ToInt32(Certificate.CertificateId),
                Convert.ToInt32(JobSalaryLevel.JobSalaryLevelId),
                Convert.ToInt32(LangSkill.SillId), Convert.ToInt32(Province.Id),
                Convert.ToInt32(JobIndustries.JobIndutriesId), Convert.ToInt32(JobPosition.JobPositionId)
                , Convert.ToInt32(ExperienceLevel.ExperianceLevelId), Convert.ToInt32(WorkType.WorkTypeId), Achievement,
                CareerGoal, WorkExperience, Literacy, Skill, Reference, Convert.ToInt32(User.UserId), ContactEmail, Atachment);
            if (temp > 0)
            {
                return true;
            }
            return false;
        }

        public void SetFullResumeInfo()
        {
            var dao = new DaoResume();
            DataTable infoTable = dao.GetFullResumeInfoById(Convert.ToInt32(ResumeId));
            Certificate = new Certificate(infoTable.Rows[0]["CertificateID"].ToString(), infoTable.Rows[0]["CertificateName"].ToString());
            LangSkill = new LangSkill(infoTable.Rows[0]["SkillID"].ToString(), infoTable.Rows[0]["SkillName"].ToString());
            JobSalaryLevel = new JobSalaryLevel(infoTable.Rows[0]["SalaryLevelID"].ToString(), infoTable.Rows[0]["SalaryLevel"].ToString());
            Province = new Province(infoTable.Rows[0]["ProvinceID"].ToString(), infoTable.Rows[0]["ProvinceName"].ToString());
            JobIndustries = new JobIndustries(infoTable.Rows[0]["JobIndustryID"].ToString(), infoTable.Rows[0]["JobIndustryName"].ToString());
            JobPosition = new JobPosition(infoTable.Rows[0]["JobPositionID"].ToString(), infoTable.Rows[0]["JobPositionName"].ToString());
            User=new User(infoTable.Rows[0]["UserID"].ToString());
            ExperienceLevel = new ExperienceLevel(infoTable.Rows[0]["ExperienceLevelID"].ToString(), infoTable.Rows[0]["ExperienceLevelName"].ToString());
            WorkType = new WorkType(infoTable.Rows[0]["WorkTypeID"].ToString(), infoTable.Rows[0]["WorkTypeName"].ToString());
            Achievement = infoTable.Rows[0]["ACHIEVEMENTS"].ToString();
            CareerGoal = infoTable.Rows[0]["CAREER_GOALS"].ToString();
            WorkExperience = infoTable.Rows[0]["WORK_EXPERIENCE"].ToString();
            Literacy = infoTable.Rows[0]["LITERACY"].ToString();
            Skill = infoTable.Rows[0]["SKILLS"].ToString();
            Reference = infoTable.Rows[0]["REFERENCE"].ToString();
            ContactEmail = infoTable.Rows[0]["ContactEmail"].ToString();
            ResumeName = infoTable.Rows[0]["ResumeName"].ToString();
            Atachment = infoTable.Rows[0]["ATTACHMENT"].ToString();
        }

        public List<Jobs> JobRanking( int userId)
        {
            try
            {
                var dao = new DaoJobs();
                DataTable tableData = dao.GetAllJobs(userId);
                var listRankJobs = new List<Jobs>();
                if (tableData != null && tableData.Rows.Count > 0)
                {

                    foreach (DataRow dataRow in tableData.Rows)
                    {
                        int rank = 1;
                        rank += Province.Id == dataRow["ProvinceID"].ToString() ? 3 : 0;
                        rank += JobPosition.JobPositionId == dataRow["JobPositionID"].ToString() ? 1 : 0;
                        rank += JobSalaryLevel.JobSalaryLevelId == dataRow["SalaryLevelID"].ToString() ? 1 : 0;
                        rank += WorkType.WorkTypeId == dataRow["WorkTypeID"].ToString() ? 1 : 0;
                        rank += JobIndustries.JobIndutriesId == dataRow["JobIndustryID"].ToString() ? 1 : 0;
                        rank += ExperienceLevel.ExperianceLevelId == dataRow["ExperienceLevelID"].ToString() ? 1 : 0;
                        rank += Certificate.CertificateId == dataRow["CertificateID"].ToString() ? 1 : 0;
                        switch (LangSkill.SillId)
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
                        var job = new Jobs(dataRow["JobID"].ToString(),rank);
                        job.SetFullJobInfo();
                        listRankJobs.Add(job);
                    }
                }
                return listRankJobs;
            }
            catch (Exception exception)
            {
                Console.Write(exception);
                return null;
            }
        }

    }
}