using System;
using System.Data;
using Core;

namespace Models.DAO
{
    /// <summary>
    /// Summary description for DaoCommonInfo
    /// </summary>
    public class DaoCommonInfo:AccessDataBase
    {
        public DaoCommonInfo()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable GetAllRace()
        {
            try
            {
                Command.CommandText = "SELECT * FROM Race";
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
        public DataTable GetAllLanguageSkill()
        {
            try
            {
                Command.CommandText = "SELECT * FROM Skill";
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
        public DataTable GetAllJobPosition()
        {
            try
            {
                Command.CommandText = "SELECT * FROM JobPosition";
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

        public DataTable GetAllSalaryLevel()
        {
            try
            {
                Command.CommandText = "SELECT * FROM JobSalaryLevel";
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
        public DataTable GetAllExperienceLevel()
        {
            try
            {
                Command.CommandText = "SELECT * FROM ExperienceLevel";
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
        public DataTable GetAllCompanySize()
        {
            try
            {
                Command.CommandText = "SELECT * FROM CompanySize";
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
        public DataTable GetAllProvince()
        {
            try
            {
                Command.CommandText = "GetAllProvince";
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


        public DataTable GetAllDistrictInProvince(string provinceId)
        {
            try
            {
                Command.CommandText = "GetDistrictInProvince";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("ProvinceId", provinceId);
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
        public DataTable GetAllSexs()
        {
            try
            {
                Command.CommandText = "SELECT * FROM Sex";
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
        public DataTable GetAllJobIndustries()
        {
            try
            {
                Command.CommandText = "SELECT * FROM JobIndustries";
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
        public DataTable GetAllCertificates()
        {
            try
            {
                Command.CommandText = "SELECT * FROM Certificates";
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
        public DataTable GetAllWorkTypes()
        {
            try
            {
                Command.CommandText = "SELECT * FROM WorkTypes";
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

    }
}