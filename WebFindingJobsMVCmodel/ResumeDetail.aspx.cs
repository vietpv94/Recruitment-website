using System;
using System.Web;
using Controllers;
using Models.Objects;

public partial class ResumeDetail : GenaralController
{
    public User User5;
    public string ThumbImg;
    public string LinkCv="";
    private string JobId="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null & Session["Login"] == null)
        {
            Session["url"] = HttpContext.Current.Request.Url.ToString();
            Response.Redirect("Login.aspx");
        }
        LoadPersonalInfo();
        LoadGeneralInfo();
       
        if (Session["JobID"]==null)
        {
            btRecruitAction.Visible = false;
            btRejectResume.Visible = false;
        }
        else
        {
            JobId = Session["JobID"].ToString();
        }
    }

    private void LoadGeneralInfo()
    {
        string resumeid = Request.QueryString["resumeid"];
        var resume = new Resume(resumeid);
        resume.SetFullResumeInfo();
        lbEmailContact.Text = resume.ContactEmail;
        lbCatelory.Text = resume.JobIndustries.JobIndustriesName;
        lbCertificates.Text = resume.Certificate.CertificateName;
        lbExperienceLevel.Text = resume.ExperienceLevel.LevelOfEcperience;
        lbJobPosition.Text = resume.JobPosition.Position;
        lbLangSkill.Text = resume.LangSkill.SkillName;
        lbLocation.Text = resume.Province.NameProvince;
        lbSalaryLevel.Text = resume.JobSalaryLevel.SalaryLevel;
        lbrHocVan.Text = resume.Reference;
        lbrKiNang.Text = resume.Skill;
        lbrThongTin.Text = resume.Literacy;
        lbrWorkExperience.Text = resume.WorkExperience;
        ltrMucTieu.Text = resume.Achievement;
        ltrNoiBat.Text = resume.CareerGoal;

        if (!String.IsNullOrEmpty(resume.Atachment))
        {
            LinkCv = "<a class='btn btn-default' style='position: absolute;right: 20%;top: 75px;'";
            LinkCv += "href='" + resume.Atachment + "'>DownLoad CV<i class='glyphicon glyphicon-download-alt'></i></a>";
        }
    }
    
    private void LoadImage(string userId)
    {
        var user = new User(userId);
        user.SetFullInfo();
        ThumbImg = user.ThumImg;
    }
    private void LoadPersonalInfo()
    {
        User5 = (User)Session["User"];
        if (User5!=null)
        {
            LoadImage(User5.UserId);
            User5.SetFullInfo();
            Session["User"] = User5;
            lbFullName.Text = User5.LastName + " " + User5.FirstName;
            lbGender.Text = User5.Sex.SexName;
            lbDateOfBirth.Text = Convert.ToDateTime(User5.DateBirthDay).ToString("dd/MM/yyyy");
            lbAddress.Text = User5.Address.District.DistrictName + " , " + User5.Address.Province.NameProvince;
        }
        else
        {
            String userId = Request.QueryString["userid"];
            LoadImage(userId);
            divBtnRecruit.Visible = true;
            divBtnUpdate.Visible = false;
            User5=new User(userId);
            User5.SetFullInfo();
            lbFullName.Text = User5.LastName + " " + User5.FirstName;
            lbGender.Text = User5.Sex.SexName;
            lbDateOfBirth.Text = Convert.ToDateTime(User5.DateBirthDay).ToString("dd/MM/yyyy");
            lbAddress.Text = User5.Address.District.DistrictName + " , " + User5.Address.Province.NameProvince;
        }
    
    }

    protected void btRecruitAction_Click(object sender, EventArgs e)
    {
        try
        { 
           
            var recruiter = (Recruitor) Session["Recruitor"];
       
            if (recruiter != null )
            {
                string resumeid = Request.QueryString["resumeid"];
                JavaScriptAleart(RecruitPeople(Convert.ToInt32(recruiter.RecruitorId), Convert.ToInt32(resumeid),Convert.ToInt32(JobId))
                    ? "Đã Tuyển Hồ Sơ Này"
                    : "Không Thành Công!");
            }
            else
            {
                Session["url"] = HttpContext.Current.Request.Url.ToString();
                Response.Redirect("Login.aspx");
            }

        }
        catch (Exception)
        {
            JavaScriptAleart("Nộp Hồ Sơ Thất Bại");
        }
    }
    protected void btUpdate_Click(object sender, EventArgs e)
    {
        string resumeid = Request.QueryString["resumeid"];
        Response.Redirect("NewResume.aspx?resumeId=" + resumeid);
    }

    protected void btRejectResume_OnClick(object sender, EventArgs e)
    {
        Response.Redirect(Session["rewriteurl"].ToString());
    }
}