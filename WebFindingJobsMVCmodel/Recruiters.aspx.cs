using System;
using System.Data;
using Controllers;
using Models.Objects;

public partial class Recruiters : ResumeController
{
    public Recruitor Recruitor1;
    public Jobs Jobs1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDatas();
        }
    }

    private void LoadDatas()
    {
        LoadRegions();
        LoadJobCategories();
        LoadJobLevel();
        LoadSalaryLevel();
        LoadJobExperiences();
        LoadDegreeLevel();
        LoadJobTimes();
        LoadSex();
        LoadLangSkill();
    }
    private void LoadJobTimes()
    {
        if (GetAllWorkTypes() != null && GetAllWorkTypes().Rows.Count > 0)
        {
            BindDropDownList(ddlWorktype, GetAllWorkTypes(), "WorkTypeName", "WorkTypeID", "----Không Chọn----");
        }
    }

    private void LoadDegreeLevel()
    {
        if (GetAllCertificates() != null && GetAllCertificates().Rows.Count > 0)
        {
            BindDropDownList(ddlCertificate, GetAllCertificates(), "CertificateName", "CertificateID", "----Không Chọn----");
        }
    }

    private void LoadSex()
    {
        if (GetAllSexs()!=null&& GetAllSexs().Rows.Count>0)
        {
            BindDropDownList(ddlSex, GetAllSexs(), "SexName", "SexID", "----Không Chọn----");
        }
    }

    private void LoadLangSkill()
    {
        if (GetAllLanguageSkill()!=null&& GetAllLanguageSkill().Rows.Count>0)
        {
            BindDropDownList(ddlLangSkill, GetAllLanguageSkill(), "SkillName", "SkillID", "----Không Chọn----");
        }
    }

    private void LoadJobExperiences()
    {
        if (GetAllExperienceLevel() != null && GetAllExperienceLevel().Rows.Count > 0)
        {
            BindDropDownList(ddlExperienceLevel, GetAllExperienceLevel(), "ExperienceLevelName", "ExperienceLevelID", "----Không Chọn----");
        }
    }

    private void LoadSalaryLevel()
    {
        if (GetAllSalaryLevel() != null && GetAllSalaryLevel().Rows.Count > 0)
        {
            BindDropDownList(dllSalarylevel, GetAllSalaryLevel(), "SalaryLevel", "SalaryLevelID", "----Không Chọn----");
        }
    }

    private void LoadJobLevel()
    {
        if (GetAllJobPosition() != null && GetAllJobPosition().Rows.Count > 0)
        {
            BindDropDownList(dllJobPosition, GetAllJobPosition(), "JobPositionName", "JobPositionID", "----Không Chọn----");
        }
    }

    private void LoadJobCategories()
    {
        if (GetAllJobs() != null && GetAllJobs().Rows.Count > 0)
        {
            BindDropDownList(ddlCatelogy, GetAllJobs(), "JobIndustryName", "JobIndustryID", "----Không Chọn----");
        }
    }

    private void LoadRegions()
    {
        if (GetAllProvine() != null && GetAllProvine().Rows.Count > 0)
        {
            BindDropDownList(ddlLocation, GetAllProvine(), "ProvinceName", "ProvinceID", "----Không Chọn----");
        }
    }
    private void SearchJobs()
    {
        DataTable dataTable = GetResumes(ddlCertificate.SelectedValue, dllSalarylevel.SelectedValue, ddlLocation.SelectedValue,
           ddlCatelogy.SelectedValue, dllJobPosition.SelectedValue, ddlExperienceLevel.SelectedValue,
           ddlWorktype.SelectedValue, "0",ddlLangSkill.SelectedValue,ddlSex.SelectedValue);
        var fromyear = Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(txtToAge.Text);
        var toyear = Convert.ToInt32(DateTime.Now.Year - Convert.ToInt32(txtFromAge.Text));
        Session["SearchResult"] = dataTable;
        Session["Ages"] = new Ages(fromyear, toyear);
    }
    protected void btSearchResume_Click(object sender, EventArgs e)
    {
        SearchJobs();
      
        Response.Redirect("ListProfiles.aspx?keyword="+tbKeyword.Text);
    }
}