using System;
using System.Data;
using Core;

namespace Models.DAO
{
    /// <summary>
    /// Summary description for DaoResume
    /// </summary>
    public class DaoResume : AccessDataBase
    {
        public DaoResume()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable GetResumeInfo()
        {
            try
            {
                Command.CommandText = "get_ads_resumes";
                Command.CommandType = CommandType.StoredProcedure;
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

        public DataTable GetResumeRecommended()
        {
            try
            {
                Command.CommandText = "get_all_recommend_resume";
                Command.CommandType = CommandType.StoredProcedure;
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
        public DataTable GetResumeActive(int userId)
        {
            try
            {
                Command.CommandText = "GetResumeActiveByUser";
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
        public int SetResumeRecruitedByRecruiter(int recrutorId, int resumeId,int jobId)
        {
            try
            {
                Command.CommandText = "SetResumeRecruitedByRecruiter";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("RecruitorID", recrutorId);
                Command.Parameters.AddWithValue("ResumeID", resumeId);
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

        public int DeleteAResumeByUser(int resumeId, int userId)
        {
            try
            {
                Command.CommandText = "DeleteAResumeByUser";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("ResumeID", resumeId);
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

        public int AddAResumeInfoUpdate(string resumeName, int certificateId, int jobSalaryLevelId, int skillId, int provinceId,
            int jobIndutriesId, int jobPositionId, int experianceLevelId, int workTypeId, string achievement, string careerGoal,
            string workExperience, string literacy, string skill, string reference, int userId, string contactMail, int resumeId, string attachFile)
        {
            try
            {
                Command.CommandText = "UpdateAResumeInfo";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("ResumeName", resumeName);
                Command.Parameters.AddWithValue("CertificateId", certificateId);
                Command.Parameters.AddWithValue("JobSalaryLevelId", jobSalaryLevelId);
                Command.Parameters.AddWithValue("SkillID", skillId);
                Command.Parameters.AddWithValue("JobIndutriesId", jobIndutriesId);
                Command.Parameters.AddWithValue("JobPositionId", jobPositionId);
                Command.Parameters.AddWithValue("ExperienceLevelId", experianceLevelId);
                Command.Parameters.AddWithValue("WorkTypeId", workTypeId);
                Command.Parameters.AddWithValue("Achievement", achievement);
                Command.Parameters.AddWithValue("CareerGoal", careerGoal);
                Command.Parameters.AddWithValue("WorkExperience", workExperience);
                Command.Parameters.AddWithValue("Literacy", literacy);
                Command.Parameters.AddWithValue("Skill", skill);
                Command.Parameters.AddWithValue("Reference", reference);
                Command.Parameters.AddWithValue("UserId", userId);
                Command.Parameters.AddWithValue("ProvinceID", provinceId);
                Command.Parameters.AddWithValue("ContactMail", contactMail);
                Command.Parameters.AddWithValue("ResumeID", resumeId);
                Command.Parameters.AddWithValue("AttachFile", attachFile);
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



        public DataTable FilterResumes(string certificateId, string jobSalaryLevelId, string provinceId, string jobIndutriesId, string jobPositionId, string experienceLevelId, string workTypeId, string userid, string langskillid, string sexid)
        {
            try
            {
                Command.CommandText = "SearchResumeByIds";

                Command.Parameters.AddWithValue("CertificateID", certificateId);
                Command.Parameters.AddWithValue("JobSalaryLevelID", jobSalaryLevelId);
                Command.Parameters.AddWithValue("ProvinceID", provinceId);
                Command.Parameters.AddWithValue("JobIndutriesID", jobIndutriesId);
                Command.Parameters.AddWithValue("JobPositionID", jobPositionId);
                Command.Parameters.AddWithValue("ExperienceLevelID", experienceLevelId);
                Command.Parameters.AddWithValue("WorkTypeID", workTypeId);
                Command.Parameters.AddWithValue("UserID", userid);
                Command.Parameters.AddWithValue("SexID", sexid);
                Command.Parameters.AddWithValue("LangSkillID", langskillid);
                Command.CommandType = CommandType.StoredProcedure;
                Connection.Open();
                var reader = Command.ExecuteReader();
                var dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
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
        public DataTable GetResumeAppliedJob(int jobid)
        {
            try
            {
                Command.CommandText = "get_ads_resumes2";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("JobID", jobid);
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
        public DataTable GetResumeRecruitedJob(int jobid)
        {
            try
            {
                Command.CommandText = "get_resume_recruited";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("JobID", jobid);
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
        internal DataTable GetAllMyResumes(int userId)
        {
            try
            {
                Command.CommandText = "GetResumeByUser";
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

        public DataTable GetFullResumeInfoById(int resumeId)
        {
            try
            {
                Command.CommandText = "GetFullResumeInfoById";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("ResumeID", resumeId);
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

        public int UpdateJobsUnActiveByUser(int resumeId)
        {

            try
            {
                Command.CommandText = "UpdateJobsUnActiveByUser";
                Command.CommandType = CommandType.StoredProcedure;
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
        public int UpdateJobsActiveByUser(int resumeId)
        {

            try
            {
                Command.CommandText = "UpdateJobsActiveByUser";
                Command.CommandType = CommandType.StoredProcedure;
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
        public int UpdateAllResumeUnActive(int userId)
        {

            try
            {
                Command.CommandText = "UpdateAllResumeUnActiveByUser";
                Command.CommandType = CommandType.StoredProcedure;
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

        public int AddAResumeInfo(string resumeName, int certificateId, int jobSalaryLevelId, int skillId, int provinceId,
           int jobIndutriesId, int jobPositionId, int experianceLevelId, int workTypeId, string achievement, string careerGoal,
           string workExperience, string literacy, string skill, string reference, int userId, string contactMail, string attachFile)
        {
            try
            {
                Command.CommandText = "AddAResumeInfo";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("ResumeName", resumeName);
                Command.Parameters.AddWithValue("CertificateId", certificateId);
                Command.Parameters.AddWithValue("JobSalaryLevelId", jobSalaryLevelId);
                Command.Parameters.AddWithValue("SkillID", skillId);
                Command.Parameters.AddWithValue("JobIndutriesId", jobIndutriesId);
                Command.Parameters.AddWithValue("JobPositionId", jobPositionId);
                Command.Parameters.AddWithValue("ExperienceLevelId", experianceLevelId);
                Command.Parameters.AddWithValue("WorkTypeId", workTypeId);
                Command.Parameters.AddWithValue("Achievement", achievement);
                Command.Parameters.AddWithValue("CareerGoal", careerGoal);
                Command.Parameters.AddWithValue("WorkExperience", workExperience);
                Command.Parameters.AddWithValue("Literacy", literacy);
                Command.Parameters.AddWithValue("Skill", skill);
                Command.Parameters.AddWithValue("Reference", reference);
                Command.Parameters.AddWithValue("UserId", userId);
                Command.Parameters.AddWithValue("ProvinceID", provinceId);
                Command.Parameters.AddWithValue("ContactMail", contactMail);
                Command.Parameters.AddWithValue("FileAttach", attachFile);
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

    }
}