using System;
using System.Data;
using Models.DAO;

namespace Controllers
{
    /// <summary>
    /// Summary description for ResumeController
    /// </summary>
    public class ResumeController : GenaralController
    {
        public ResumeController()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        protected DataTable GetResumeInfo()
        {
            var dao = new DaoResume();
            return dao.GetResumeInfo();
        }
        protected DataTable GetResumeAppliedJob(string jobid)
        {
            var dao = new DaoResume();
            return dao.GetResumeAppliedJob(Convert.ToInt32(jobid));
        }

        protected DataTable GetResumeRecruitedJob(string jobid)
        {
            var dao = new DaoResume();
            return dao.GetResumeRecruitedJob(Convert.ToInt32(jobid));
        }
        protected DataTable GetResumes(string certificateId, string jobSalaryLevelId, string provinceId, string jobIndutriesId, string jobPositionId, string experienceLevelId, string workTypeId, string userid, string langskillid, string sexid)
        {
            var dao = new DaoResume();
            return dao.FilterResumes(certificateId, jobSalaryLevelId, provinceId, jobIndutriesId, jobPositionId, experienceLevelId, workTypeId, userid, langskillid, sexid);
        }
        public bool DeleteAResume(int resumeId, int userId)
        {
            var dt = new DaoResume();
            if (dt.DeleteAResumeByUser(resumeId, userId) > 0)
            {
                return true;
            }
            return false;
        }

    }
}