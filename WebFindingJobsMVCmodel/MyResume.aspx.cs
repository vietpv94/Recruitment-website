using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Controllers;
using Models.Objects;

public partial class MyResume : ResumeController
{
    public User User3;
    public string ThumbImg;
    private string _resumeId=String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null & Session["Login"] == null)
        {

            Response.Redirect("Login.aspx");
        }
        User3 = (User)Session["User"];
        if (!IsPostBack)
        {
            LoadSavedWorks();
            LoadAppliedJobs();
            LoadMyResumes();
        }
        if (User3 != null) LoadImage(User3.UserId);

    }

    private int Comparison(Jobs jobs1, Jobs jobs2)
    {
        if (jobs2 != null && (jobs1 != null && jobs1.Rank > jobs2.Rank))
            return -1; //Lớn hơn
        if (jobs1 != null && (jobs2 != null && jobs2.Rank > jobs1.Rank))
            return 1;//Nhở hơn
        return 0;//Bằng nhau
    }
    public string BuidRecomendJobs()
    {

        if (String.IsNullOrEmpty(_resumeId))
        {
            return "Bạn cần đăng hồ sơ để hệ thống có thể tự động tìm những công việc phù hợp với hồ sơ của bạn.";
        }
        else
        {
            var buider = new StringBuilder();

            var resume = new Resume(_resumeId);
            resume.SetFullResumeInfo();
            var list = resume.JobRanking(Convert.ToInt32(User3.UserId));
            list.Sort(Comparison);
            foreach (Jobs jobs in list.Take(3))
            {
                buider.AppendLine("<li>");
                buider.AppendLine("<h4><a href='");
                buider.AppendLine(jobs.RewriteUrl);
                buider.AppendLine("?jobid=");
                buider.AppendLine(jobs.JobId);
                buider.AppendLine("'>");
                buider.AppendLine(jobs.JobTitle);
                buider.AppendLine("</a></h4>");
                buider.AppendLine(" <p class='time'>");
                buider.AppendLine(String.Format("{0:dd/MM/yyyy}", DateTime.Parse(jobs.ExpiredDate.ToString())));
                buider.AppendLine("|");
                buider.AppendLine(jobs.Province.NameProvince);
                buider.AppendLine("</p>");
                buider.AppendLine(" <p class='name'>");
                buider.AppendLine(jobs.Recruitor.CompanyFullname);
                buider.AppendLine("</p>");
                buider.AppendLine(" <p class='add'>");
                buider.AppendLine(jobs.Recruitor.Address);
                buider.AppendLine("</p><hr/></li>");
            }
            return buider.ToString();
        }
    }

    private void LoadImage(string userId)
    {
        var user = new User(userId);
        user.SetFullInfo();
        ThumbImg = user.ThumImg;
    }
    private void LoadMyResumes()
    {
        DataTable data = GetAllMyResumes(Convert.ToInt32(User3.UserId));
        if (data != null &&data.Rows.Count>0 )
        {
            my_resume.Visible = false;
            BindRepeater(rptItems, data);
            _resumeId = data.Rows[0]["ResumeID"].ToString();
        }
        else
        {
            _resumeId = String.Empty;
        }
        
    }

    private void LoadAppliedJobs()
    {
        User3 = (User)Session["User"];
        var data = GetAllAppliedJobs(Convert.ToInt32(User3.UserId));
        if (data != null)
        {
            no_job_apply.Visible = false;

            BindRepeater(rptAppliedJobs, data);
        }

    }

    private void LoadSavedWorks()
    {
        User3 = (User)Session["User"];
        var data = GetAllSavedJobs(Convert.ToInt32(User3.UserId));
        if (data != null )
        {
            saved_works.Visible = false;
            BindRepeater(rptSavedWorks, data);
        }
    }
    protected void btDelete_OnCommandrpt(object sender, CommandEventArgs e)
    {

        var isDelete = DeleteASavedJob(Convert.ToInt32(e.CommandName));
        if (isDelete)
        {
            Response.Redirect("MyResume.aspx");
        }
        JavaScriptAleart("Xóa Thất Bại");
    }

    protected void btDeleteApplied_OnCommand(object sender, CommandEventArgs e)
    {
        var isDelete = DeleteAnAppliedJob(Convert.ToInt32(e.CommandName));
        if (isDelete)
        {
            Response.Redirect("MyResume.aspx");
        }
        JavaScriptAleart("Xóa Thất Bại");
    }

    protected void btDeleteMyResume_OnCommand(object sender, CommandEventArgs e)
    {
        User3 = (User)Session["User"];
        var isDelete = DeleteAResume(Convert.ToInt32(e.CommandName), Convert.ToInt32(User3.UserId));
        if (isDelete)
        {
            Response.Redirect("MyResume.aspx");
        }
        JavaScriptAleart("Xóa Thất Bại");
    }

    protected void btEditMyResume_OnCommand(object sender, CommandEventArgs e)
    {
        Response.Redirect("NewResume.aspx?resumeId=" + e.CommandName);
    }

    protected void btActive_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            var isUpdate = UpdateAllResumeUnActive(Convert.ToInt32(User3.UserId));
            var isActive = UpdateJobsActiveByUser(Convert.ToInt32(e.CommandName));
            if (isUpdate && isActive)
            {
                Response.Redirect("MyResume.aspx");
            }
            JavaScriptAleart("Cập Nhật Thất Bại");
        }
        catch (Exception exception)
        {
            JavaScriptAleart(exception.Message);
            throw;
        }
    }

    protected void btUnActive_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            var isUnActive = UpdateJobsUnActiveByUser(Convert.ToInt32(e.CommandName));
            if (isUnActive)
            {
                Response.Redirect("MyResume.aspx");
            }
            JavaScriptAleart("Cập Nhật Thất Bại");
        }
        catch (Exception exception)
        {
            JavaScriptAleart(exception.Message);
            throw;
        }
    }
    protected bool ActionButtons(string index)
    {

        return index.Equals("1");
    }
    protected bool ActionButtons2(string index)
    {
        return !index.Equals("1");
    }

    protected void btCreateNewResume_OnClick(object sender, EventArgs e)
    {
        DataTable data = GetAllMyResumes(Convert.ToInt32(User3.UserId));
        if (data.Rows.Count >= 3)
        {
            JavaScriptAleart("Bạn đã tạo tối đa 3 hồ sơ. Vui lòng kiểm tra lại");
            return;
        }
        Response.Redirect("NewResume.aspx");
    }
}

