using System;
using System.Data;
using System.Linq;
using System.Text;
using Controllers;

namespace UI
{
    public partial class UiFindJobs : JobsController
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string key=Request.QueryString["KeyWord"];
                txtKeywords.Text = key;
                LoadDatas();
            }

        }

        private void LoadDatas()
        {
            if (txtKeywords.Text!=null)
            {
                SearchJobs();
            }
            else
            {
                BindRepeater(rptSearchResult, GetJobs("0", "0", "0", "0", "0", "0", "0", "0"));
                divMessages.InnerHtml = "<p class='text-info'> Có " + rptSearchResult.Items.Count + " công việc phù hợp";
            }
            LoadRegions();
            LoadJobCategories();
            LoadJobLevel();
            LoadSalaryLevel();
            LoadJobExperiences();
            LoadDegreeLevel();
            LoadJobTimes();
        }
        private void LoadJobTimes()
        {
            if (GetAllWorkTypes() != null && GetAllWorkTypes().Rows.Count > 0)
            {
                BindDropDownList(ddlJobTimes, GetAllWorkTypes(), "WorkTypeName", "WorkTypeID", "Kiểu công việc");
            }
        }

        private void LoadDegreeLevel()
        {
            if (GetAllCertificates() != null && GetAllCertificates().Rows.Count > 0)
            {
                BindDropDownList(ddlDegreeLevel, GetAllCertificates(), "CertificateName", "CertificateID", "Trình độ");
            }
        }

        private void LoadJobExperiences()
        {
            if (GetAllExperienceLevel() != null && GetAllExperienceLevel().Rows.Count > 0)
            {
                BindDropDownList(ddlJobExperiences, GetAllExperienceLevel(), "ExperienceLevelName", "ExperienceLevelID", "Kinh nghiệm");
            }
        }

        private void LoadSalaryLevel()
        {
            if (GetAllSalaryLevel() != null && GetAllSalaryLevel().Rows.Count > 0)
            {
                BindDropDownList(ddlSalaryLevel, GetAllSalaryLevel(), "SalaryLevel", "SalaryLevelID", "Mức lương");
            }
        }

        private void LoadJobLevel()
        {
            if (GetAllJobPosition() != null && GetAllJobPosition().Rows.Count > 0)
            {
                BindDropDownList(ddlJobLevel, GetAllJobPosition(), "JobPositionName", "JobPositionID", "Chức vụ");
            }
        }

        private void LoadJobCategories()
        {
            if (GetAllJobs() != null && GetAllJobs().Rows.Count > 0)
            {
                BindDropDownList(ddlJobCategories, GetAllJobs(), "JobIndustryName", "JobIndustryID", "Ngành nghề");
            }
        }

        private void LoadRegions()
        {
            if (GetAllProvine() != null && GetAllProvine().Rows.Count > 0)
            {
                BindDropDownList(ddlRegions, GetAllProvine(), "ProvinceName", "ProvinceID", "Địa điểm");
            }
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
        //  Response.Redirect("FindJobs.aspx?KeyWord=" + txtKeywords.Text);
          LoadDatas();
        }

        private void SearchJobs()
        {
            DataTable dataTable = GetJobs(ddlDegreeLevel.SelectedValue, ddlSalaryLevel.SelectedValue, ddlRegions.SelectedValue,
               ddlJobCategories.SelectedValue, ddlJobLevel.SelectedValue, ddlJobExperiences.SelectedValue,
               ddlJobTimes.SelectedValue, "0");
            var dataRows = from dataRow in dataTable.AsEnumerable()
                           where
                               RemoveSign4VietnameseString(dataRow.Field<string>("FullTitle").ToLower())
                                   .Contains(RemoveSign4VietnameseString(txtKeywords.Text.Trim().ToLower()))
                           select dataRow;
            if (dataRows.Any())
            {
                divMessages.InnerHtml = "<p class='text-info'> Có " + dataRows.Count() + " công việc phù hợp";
                BindRepeater(rptSearchResult, dataRows.CopyToDataTable());
            }
            else
            {
                BindRepeater(rptSearchResult, new DataTable());
                divMessages.InnerHtml = "<p class='text-danger'> Không tìm thấy công việc phù hợp </p>";

            }
        }

        private string RemoveUnicode(string inputString)
        {
            string asAscii = Encoding.ASCII.GetString(
                Encoding.Convert(
                    Encoding.UTF8,
                    Encoding.GetEncoding(
                        Encoding.ASCII.EncodingName,
                        new EncoderReplacementFallback(string.Empty),
                        new DecoderExceptionFallback()
                        ),
                    Encoding.UTF8.GetBytes(inputString)
                    )
                );
            return asAscii;
        }
        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            ddlDegreeLevel.SelectedIndex = 0;
            ddlJobCategories.SelectedIndex = 0;
            ddlJobExperiences.SelectedIndex = 0;
            ddlJobLevel.SelectedIndex = 0;
            ddlJobTimes.SelectedIndex = 0;
            ddlRegions.SelectedIndex = 0;
            ddlSalaryLevel.SelectedIndex = 0;
            txtKeywords.Text = string.Empty;
            LoadDatas();
            Response.Redirect("FindJobs.aspx");
        }
    }
}