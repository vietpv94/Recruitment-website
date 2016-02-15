using System.Data;
using Base;
using Models.DAO;

namespace Controllers
{
    /// <summary>
    /// Summary description for GenaralController
    /// </summary>
    public class GenaralController : CoreBase
    {
        public GenaralController()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        protected DataTable GetAllProvine()
        {
            var dao = new DaoCommonInfo();
            return dao.GetAllProvince();
        }

        protected DataTable GetAllCompanySize()
        {
            var dao = new DaoCommonInfo();
            return dao.GetAllCompanySize();
        }
        protected DataTable GetAllJobPosition()
        {
            var dao = new DaoCommonInfo();
            return dao.GetAllJobPosition();
        }
        protected DataTable GetAllExperienceLevel()
        {
            var dao = new DaoCommonInfo();
            return dao.GetAllExperienceLevel();
        }
        protected DataTable GetAllCertificates()
        {
            var dao = new DaoCommonInfo();
            return dao.GetAllCertificates();
        }
        protected DataTable GetAllSalaryLevel()
        {
            var dao = new DaoCommonInfo();
            return dao.GetAllSalaryLevel();
        }
        protected DataTable GetAllWorkTypes()
        {
            var dao = new DaoCommonInfo();
            return dao.GetAllWorkTypes();
        }
        protected DataTable GetAllRaces()
        {
            var dao = new DaoCommonInfo();
            return dao.GetAllRace();
        }

        protected DataTable GetAllDistrictInProvince(string provinceId)
        {
            var dao = new DaoCommonInfo();
            return dao.GetAllDistrictInProvince(provinceId);
        }
        protected DataTable GetAllSexs()
        {
            var dao = new DaoCommonInfo();
            return dao.GetAllSexs();
        }

        protected DataTable GetAllLanguageSkill()
        {
            var dao = new DaoCommonInfo();
            return dao.GetAllLanguageSkill();
        }
        public DataTable GetAllMyResumes(int userId)
        {
            var dt = new DaoResume();
            return dt.GetAllMyResumes(userId);
        }

        public bool UpdateJobsUnActiveByUser(int resumeId)
        {
            var dt =new DaoResume();
            return dt.UpdateJobsUnActiveByUser(resumeId)>0;
        }

        public bool UpdateJobsActiveByUser(int resumeId)
        {
            var dt = new DaoResume();
            return dt.UpdateJobsActiveByUser(resumeId) > 0;
        }

        public bool UpdateAllResumeUnActive(int userId)
        {
            var dt = new DaoResume();
            return dt.UpdateAllResumeUnActive(userId) > 0;
        }
        protected DataTable GetCompanyInfo()
        {
            var dao = new DaoCompany();
            return dao.GetCompanyInfo();
        }
        public bool DeleteASavedJob(int jobId)
        {
            var dt = new DaoJobs();
            return dt.DeleteASavedJob(jobId) > 0;
        
        }
        protected bool SaveJobs(int userId, int jobId)
        {
            var dao = new DaoJobs();
            return dao.SetJobSavedByUser(userId, jobId) > 0;
        
        }
        protected bool ApplyJobs(int userId, int jobId, int resumeId)
        {
            var dao = new DaoJobs();
            return dao.SetJobAppliedByUser(userId, jobId, resumeId) > 0;

        }
        protected bool RecruitPeople(int recruiterId, int resumeId, int jobId)
        {
            var dao = new DaoResume();
            return dao.SetResumeRecruitedByRecruiter(recruiterId, resumeId, jobId) > 0;
        }
        protected DataTable GetAllJobs()
        {
            var dao = new DaoCommonInfo();
            return dao.GetAllJobIndustries();
        }
        public bool DeleteAnAppliedJob(int jobId)
        {
            var dt = new DaoJobs();
            return dt.DeleteAnAppliedJob(jobId) > 0;
        }
        protected DataTable GetAllAppliedJobs(int userId)
        {
            var dao = new DaoJobs();
            return dao.GetAllAppliedJobs(userId);
        }
        protected DataTable GetAllSavedJobs(int userId)
        {
            var dao = new DaoJobs();
            return dao.GetAllSavedJobss(userId);
        }

        protected bool BlockAcount(int userId)
        {
            var dt = new DaoUser();
            return dt.BlockAnAcount(userId) > 0;
        }

        protected bool UnlockAcount(int userId)
        {
            var dt = new DaoUser();
            return dt.UnlockAnAcount(userId) > 0;

        }
        protected bool BlockRecruiterAcount(int recId)
        {
            var dt = new DaoUser();
            return dt.BlockAnRecruitorAcount(recId) > 0;

        }
        protected bool DeleteJobsByAdmin(int jobId)
        {
            var dt = new DaoJobs();
            return dt.DeleteJobsByAdmin(jobId) > 0;
           
        }
        protected bool UpdateJobsHotByAdmin(int jobId)
        {
            var dt = new DaoJobs();
            return dt.UpdateJobsHotByAdmin(jobId) > 0;
        }

        protected bool UpdateJobsUnHotByAdmin(int jobId)
        {
            var dt = new DaoJobs();
            return dt.UpdateJobsUnHotByAdmin(jobId) > 0;

        }
        protected bool UnlockRecrutorAcount(int recId)
        {
            var dt = new DaoUser();
            return dt.UnlockAnRecruterAcount(recId) > 0;
        }

    }
}