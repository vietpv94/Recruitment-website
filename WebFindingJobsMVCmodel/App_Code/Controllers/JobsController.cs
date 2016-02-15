using System;
using System.Data;
using Models.DAO;

namespace Controllers
{
    /// <summary>
    /// Summary description for JobsController
    /// </summary>
    public class JobsController:GenaralController
    {
        public JobsController()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable GetFullJobInforById(int jobid)
        {
            var dao = new DaoJobs();
            return dao.GetFullJobInforById(jobid);
        }

     
        protected DataTable GetAllJobsByRecruiter(string recruiterId)
        {
            var dao = new DaoJobs();
            return dao.GetAllJobsByRecruiter(Convert.ToInt32(recruiterId));
        }

        protected DataTable GetJobs(string certificateId, string jobSalaryLevelId, string provinceId, string jobIndutriesId, string jobPositionId, string experienceLevelId, string workTypeId, string recruiterId)
        {
            var dao = new DaoJobs();
            return dao.FilterJobs(certificateId, jobSalaryLevelId, provinceId, jobIndutriesId, jobPositionId, experienceLevelId, workTypeId, recruiterId);
        }
    
        public bool DeleteAJobByRecuiter(int jobId)
        {
            var dt = new DaoJobs();
            if (dt.DeleteAJobByRecuiter(jobId) > 0)
            {
                return true;
            }
            return false;
        }

       
    }
}