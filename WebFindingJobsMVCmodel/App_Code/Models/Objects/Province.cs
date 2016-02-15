using System.Collections.Generic;
using System.Data;
using Models.DAO;

namespace Models.Objects
{
    /// <summary>
    /// Summary description for Province
    /// </summary>
 
    
    public class Province
    {
        private string _nameProvince;
        private string _id;
     
        public string NameProvince
        {
            get { return _nameProvince; }
            set { _nameProvince = value; }
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Province()
        {
            NameProvince = string.Empty;
            Id = string.Empty;
        }

        public Province(string id, string name)
        {
            NameProvince = name;
            Id = id;
        }

        public Province(int id, string name)
        {
            NameProvince = name;
            Id = id.ToString();
        }

        public static List<Province> GetAllProvinces()
        {
            var returnListProvinces = new List<Province>();
            var dataTable = new DataTable();
            var dao = new DaoCommonInfo();
            dataTable = dao.GetAllProvince();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var province = new Province(dataTable.Rows[i]["ProvinceId"].ToString(), dataTable.Rows[i]["ProvinceName"].ToString());
                    returnListProvinces.Add(province);
                }
            }
            return returnListProvinces;
        } 

    }
}