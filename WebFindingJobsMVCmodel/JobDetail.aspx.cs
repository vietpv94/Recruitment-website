using System;
using System.Web;
using System.Web.UI.WebControls;
using Controllers;
using Models.DAO;
using Models.Objects;

public partial class JobDetail : JobsController
{
    public Jobs Jobs2;
    public User User2;
    private int ResumeID;
    protected void Page_Load(object sender, EventArgs e)
    {
        var recruitor = (Recruitor)Session["Recruitor"];
        if (recruitor != null)
        {
            divBtnJobDetail.Visible = false;
            divRecomendJobs.Visible = false;
        }
        if (!IsPostBack)
        {
            LoadDatas();
        }



    }

    private void LoadDatas()
    {
        BindRepeater(rptSearchResult, GetCompanyInfo());
        string jobId = Request.QueryString["jobid"];

        Jobs2 = new Jobs(jobId);
        Jobs2.SetFullJobInfo();
        txtAddress.Text = Jobs2.Recruitor.Address;
        txtCompanyName.Text = Jobs2.Recruitor.CompanyFullname;
        txtCompanySize.Text = Jobs2.Recruitor.CompanySize.SizeOfCompany;
        txtDateLine.Text = Convert.ToDateTime(Jobs2.ExpiredDate).ToString("dd/MM/yyyy");
        txtJobContent.Text = Jobs2.ContentDetail;
        txtJobDescription.Text = Jobs2.Description;
        txtRecruterName.Text = Jobs2.Recruitor.RecruitorName;
        txtExperienceLevel.Text = Jobs2.ExperienceLevel.LevelOfEcperience;
        txtCertificate.Text = Jobs2.Certificate.CertificateName;
        txtCatelogy.Text = Jobs2.JobIndustries.JobIndustriesName;
        txtJobPosition.Text = Jobs2.JobPosition.Position;
        txtSalary.Text = Jobs2.JobSalaryLevel.SalaryLevel;
        txtLocation.Text = Jobs2.Province.NameProvince;
        txtWorktype.Text = Jobs2.WorkType.WorkTypeName;
    }
    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        var keyWord = "";
        keyWord = txtKeywords.Text;
        Response.Redirect("FindJobs.aspx?KeyWord=" + keyWord);
    }
    protected void btApplyJob_Click(object sender, EventArgs e)
    {
        try
        {
            User2 = (User)Session["User"];
            if (User2 != null)
            {
                var dataNumber = GetAllAppliedJobs(Convert.ToInt32(User2.UserId)).Rows.Count;
                if (dataNumber >= 3)
                {
                    JavaScriptAleart("Bạn chỉ được ứng tuyển tối đa 3 công việc");
                    return;
                }
                int jobid = Convert.ToInt32(Request.QueryString["jobid"]);
                var dao = new DaoResume();
                var resumeid = Convert.ToInt32(dao.GetResumeActive(Convert.ToInt32(User2.UserId)).Rows[0]["ResumeID"]);
                JavaScriptAleart(ApplyJobs(Convert.ToInt32(User2.UserId), jobid, resumeid)
                    ? "Nộp Hồ Sơ Thành Công"
                    : "Nộp Hồ Sơ Thất Bại, Hồ Sơ Của Bạn Có Thể Đã Được Nộp Trước Đó");

            }
            else
            {
                Session["url"] = HttpContext.Current.Request.Url.ToString();
                Response.Redirect("Login.aspx");
            }
        }
        catch (Exception exception)
        {
            JavaScriptAleart(exception.Message);
        }

    }
    protected void btSaveJob_Click(object sender, EventArgs e)
    {
        try
        {
            User2 = (User)Session["User"];
            if (User2 != null)
            {
                var dataNumber = GetAllSavedJobs(Convert.ToInt32(User2.UserId)).Rows.Count;
                if (dataNumber >= 5)
                {
                    JavaScriptAleart("Bạn chỉ được lưu tối đa 5 công việc");
                    return;
                }
                int jobid = Convert.ToInt32(Request.QueryString["jobid"]);
                JavaScriptAleart(SaveJobs(Convert.ToInt32(User2.UserId), jobid)
                    ? "Lưu Hồ Sơ Thành Công"
                    : "Lưu Hồ Sơ Thất Bại");
            }
            else
            {
                Session["url"] = HttpContext.Current.Request.Url.ToString();
                Response.Redirect("Login.aspx");
            }

        }
        catch (Exception)
        {
            JavaScriptAleart("Lưu Hồ Sơ Thất Bại");
        }

    }


}