using System;
using System.Data;
using Core;

namespace Models.DAO
{
    /// <summary>
    /// Summary description for DaoJobs
    /// </summary>
    public class DaoJobs:AccessDataBase
    {
        public DaoJobs()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int DeleteAnAppliedJob(int jobId)
        {
            try
            {
                Command.CommandText = "deletesAJobApplied";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("JobID", jobId);
                Connection.Open();
                var returnValues = Convert.ToInt32(Command.ExecuteScalar());
                return returnValues;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int SetJobSavedByUser(int userId, int jobId)
        {
            try
            {
                Command.CommandText = "SetJobSavedByUser";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("JobID", jobId);
                Command.Parameters.AddWithValue("UserID", userId);
                Connection.Open();
                var returnValues = Convert.ToInt32(Command.ExecuteScalar());
                return returnValues;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int SetJobAppliedByUser(int userId, int jobId, int resumeId)
        {
            try
            {
                Command.CommandText = "SetJobAppliedByUser";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("JobID", jobId);
                Command.Parameters.AddWithValue("UserID", userId);
                Command.Parameters.AddWithValue("ResumeID", resumeId);
                Connection.Open();
                var returnValues = Convert.ToInt32(Command.ExecuteScalar());
                return returnValues;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }

        public DataTable GetAllSavedJobss(int userId)
        {
            try
            {
                Command.CommandText = "GetAllJobSavedByUser";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("UserID", userId);
                Connection.Open();
                var reader = Command.ExecuteReader();
                var dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
            }
            catch (Exception)
            {
                return null;
            }
            finally { Connection.Close(); }
        }

        public DataTable GetAllAppliedJobs(int userId)
        {
            try
            {
                Command.CommandText = "GetAllJobAppliedByUser";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("UserID", userId);
                Connection.Open();
                var reader = Command.ExecuteReader();
                var dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
            }
            catch (Exception)
            {
                return null;
            }
            finally { Connection.Close(); }
        }

        public int DeleteASavedJob(int jobid)
        {
            try
            {
                Command.CommandText = "deletesJobSaved";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("JobID", jobid);
                Connection.Open();
                var returnValues = Convert.ToInt32(Command.ExecuteScalar());
                return returnValues;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }
      
        public int AddAJobInfo(string jobTitle, int certificateId, int jobSalaryLevelId, int provinceId,
          int jobIndutriesId, string contentDetail, string description, DateTime expiredDate,
          int jobpositionId, int experienceLevelId, int worktypeId, int recruitorId, int numsApplicant)
        {
            try
            {
                Command.CommandText = "AddAJobInfo";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("JobTitle", jobTitle);
                Command.Parameters.AddWithValue("CertificateID", certificateId);
                Command.Parameters.AddWithValue("JobSalaryLevelID", jobSalaryLevelId);
                Command.Parameters.AddWithValue("ProvinceID", provinceId);
                Command.Parameters.AddWithValue("JobIndutriesID", jobIndutriesId);
                Command.Parameters.AddWithValue("ContentDetail", contentDetail);
                Command.Parameters.AddWithValue("Description", description);
                Command.Parameters.AddWithValue("ExpiredDate", expiredDate);
                Command.Parameters.AddWithValue("JobPositionID", jobpositionId);
                Command.Parameters.AddWithValue("ExperienceLevelID", experienceLevelId);
                Command.Parameters.AddWithValue("WorkTypeID", worktypeId);
                Command.Parameters.AddWithValue("RecruiterID", recruitorId);
                Command.Parameters.AddWithValue("NumsApplicant", numsApplicant);
                Connection.Open();
                var returnValue = Convert.ToInt32(Command.ExecuteScalar());
                return returnValue;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }
        public DataTable FilterJobs(string certificateId, string jobSalaryLevelId, string provinceId, string jobIndutriesId, string jobPositionId, string experienceLevelId, string workTypeId, string recruiterId)
        {
            try
            {
                Command.CommandText = "SearchJobByIds";
                Command.Parameters.AddWithValue("CertificateID", certificateId);
                Command.Parameters.AddWithValue("JobSalaryLevelID", jobSalaryLevelId);
                Command.Parameters.AddWithValue("ProvinceID", provinceId);
                Command.Parameters.AddWithValue("JobIndutriesID", jobIndutriesId);
                Command.Parameters.AddWithValue("JobPositionID", jobPositionId);
                Command.Parameters.AddWithValue("ExperienceLevelID", experienceLevelId);
                Command.Parameters.AddWithValue("WorkTypeID", workTypeId);
                Command.Parameters.AddWithValue("RecruiterID", recruiterId);
                Command.CommandType = CommandType.StoredProcedure;
                Connection.Open();
                var reader = Command.ExecuteReader();
                var dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                Connection.Close();
            }
        }
        
        public DataTable GetFullJobInforById(int jobid)
        {
            try
            {
                Command.CommandText = "GetFullJobInforById";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("JobID", jobid);
                Connection.Open();
                var reader = Command.ExecuteReader();
                var dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
        public void LoadAppliedJobs(string userID)
        {
            try
            {

                Command.CommandText = "get_applied_jobs_details";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("UserID", userID);
                Connection.Open();

            }
            catch (Exception ex)
            {
                return;
            }
        }
        public DataTable GetAllJobsByRecruiter(int recruiterId)
        {
            try
            {
                Command.CommandText = "GetAllJobByRecruiter";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("RecruitorID", recruiterId);
                Connection.Open();
                var reader = Command.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int UpdateAJobInfo(string jobTitle, int certificateId, int jobSalaryLevelId, int provinceId,
            int jobIndutriesId, string contentDetail, string description, DateTime expiredDate,
            int jobpositionId, int experienceLevelId, int worktypeId, int recruitorId, int numsApplicant, int jobId)
        {
            try
            {
                Command.CommandText = "UpdateAJobInfo";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("JobTitle", jobTitle);
                Command.Parameters.AddWithValue("CertificateID", certificateId);
                Command.Parameters.AddWithValue("JobSalaryLevelID", jobSalaryLevelId);
                Command.Parameters.AddWithValue("ProvinceID", provinceId);
                Command.Parameters.AddWithValue("JobIndutriesID", jobIndutriesId);
                Command.Parameters.AddWithValue("ContentDetail", contentDetail);
                Command.Parameters.AddWithValue("Description", description);
                Command.Parameters.AddWithValue("ExpiredDate", expiredDate);
                Command.Parameters.AddWithValue("JobPositionID", jobpositionId);
                Command.Parameters.AddWithValue("ExperienceLevelID", experienceLevelId);
                Command.Parameters.AddWithValue("WorkTypeID", worktypeId);
                Command.Parameters.AddWithValue("RecruiterID", recruitorId);
                Command.Parameters.AddWithValue("NumsApplicant", numsApplicant);
                Command.Parameters.AddWithValue("JobID", jobId);
                Connection.Open();
                var returnValue = Convert.ToInt32(Command.ExecuteScalar());
                return returnValue;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int DeleteAJobByRecuiter(int jobId)
        {
            try
            {
                Command.CommandText = "DeleteAJobByRecuiter";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("JobID", jobId);
                Connection.Open();
                var returnValues = Convert.ToInt32(Command.ExecuteScalar());
                return returnValues;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }
        public DataTable GetJobsByAdmin()
        {
            try
            {
                Command.CommandText = "GetAllJobsByAdmin";
                Command.CommandType = CommandType.StoredProcedure;
                Connection.Open();
                var reader = Command.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int UpdateJobsHotByAdmin(int jobId)
        {
            try
            {
                Command.CommandText = "UpdateJobsHotByAdmin";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("JobID", jobId);
                Connection.Open();
                int returnValue = Convert.ToInt32(Command.ExecuteScalar());
                return returnValue;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }
        public int UpdateJobsUnHotByAdmin(int jobId)
        {
            try
            {
                Command.CommandText = "UpdateJobsUnHotByAdmin";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("JobID", jobId);
                Connection.Open();
                int returnValue = Convert.ToInt32(Command.ExecuteScalar());
                return returnValue;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }
        public int DeleteJobsByAdmin(int jobId)
        {
            try
            {
                Command.CommandText = "DeleteJobsByAdmin";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("JobID", jobId);
                Connection.Open();
                int returnValue = Convert.ToInt32(Command.ExecuteScalar());
                return returnValue;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }

        public DataTable GetAllJobs(int userId)
        {
            try
            {
                Command.CommandText = "get_all_jobs";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("UserID", userId);
                Connection.Open();
                var reader = Command.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}