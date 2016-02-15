using System;
using System.Data;
using System.ServiceModel.Channels;
using System.Text;
using Controllers;
using Models.Objects;

public partial class NewResume : GenaralController
{
    public User User1;
    public Resume Resume1;
    public string ThumbImg;
    public string LinkCv = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        User1 = (User)Session["User"];

        if (!IsPostBack)
        {
            LoadDatas();
        }

    }

    private void LoadDatas()
    {
        var resumeId = Request.QueryString["resumeId"];
        if (resumeId != null)
        {
            LoadResumeHaveBeenCreated(resumeId);
        }
        if (!String.IsNullOrEmpty(LinkCv))
        {
            resume_attachment.Visible = true;
        }
        BindDropDownList(ddlRegions, GetAllProvine(), "ProvinceName", "ProvinceID");

        BindDropDownList(ddlExpectedSalary, GetAllSalaryLevel(), "SalaryLevel", "SalaryLevelID");

        BindDropDownList(ddlExpectedPosition, GetAllJobPosition(), "JobPositionName", "JobPositionID");

        BindDropDownList(ddlCategories, GetAllJobs(), "JobIndustryName", "JobIndustryID");

        BindDropDownList(ddlDegrees, GetAllCertificates(), "CertificateName", "CertificateID");

        BindDropDownList(ddlExp, GetAllExperienceLevel(), "ExperienceLevelName", "ExperienceLevelID");

        BindDropDownList(ddlworktype, GetAllWorkTypes(), "WorkTypeName", "WorkTypeID");

        BindDropDownList(ddlLangSkill, GetAllLanguageSkill(), "SkillName", "SkillID");
    }

    private void LoadImage(string userId)
    {
        var user = new User(userId);
        user.SetFullInfo();
        ThumbImg = user.ThumImg;
    }
    private void LoadResumeHaveBeenCreated(string resumeid)
    {
        var resume = new Resume(resumeid);
        resume.SetFullResumeInfo();
        BindDropDownList(ddlRegions, GetAllProvine(), "ProvinceName", "ProvinceID");
        ddlRegions.SelectedValue = resume.Province.Id;

        BindDropDownList(ddlExpectedSalary, GetAllSalaryLevel(), "SalaryLevel", "SalaryLevelID");
        ddlExpectedSalary.SelectedValue = resume.JobSalaryLevel.JobSalaryLevelId;

        BindDropDownList(ddlExpectedPosition, GetAllJobPosition(), "JobPositionName", "JobPositionID");
        ddlExpectedPosition.SelectedValue = resume.JobPosition.JobPositionId;

        BindDropDownList(ddlCategories, GetAllJobs(), "JobIndustryName", "JobIndustryID");
        ddlCategories.SelectedValue = resume.JobIndustries.JobIndutriesId;

        BindDropDownList(ddlDegrees, GetAllCertificates(), "CertificateName", "CertificateID");
        ddlDegrees.SelectedValue = resume.Certificate.CertificateId;

        BindDropDownList(ddlExp, GetAllExperienceLevel(), "ExperienceLevelName", "ExperienceLevelID");
        ddlExp.SelectedValue = resume.ExperienceLevel.ExperianceLevelId;

        BindDropDownList(ddlworktype, GetAllWorkTypes(), "WorkTypeName", "WorkTypeID");
        ddlworktype.SelectedValue = resume.WorkType.WorkTypeId;

        BindDropDownList(ddlLangSkill, GetAllLanguageSkill(), "SkillName", "SkillID");
        ddlLangSkill.SelectedValue = resume.LangSkill.SillId;
        txtDescription.Text = resume.LangSkill.Description;
        ta1.Value = resume.Achievement;
        ta2.Value = resume.CareerGoal;
        ta3.Value = resume.WorkExperience;
        ta6.Value = resume.Literacy;
        ta5.Value = resume.Skill;
        ta4.Value = resume.Reference;
        txtContactMail.Text = resume.ContactEmail;
        txtResumeName.Text = resume.ResumeName;
        LinkCv = resume.Atachment;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable data = GetAllMyResumes(Convert.ToInt32(User1.UserId));
            if (data.Rows.Count >= 3)
            {
                JavaScriptAleart("Bạn đã tạo tối đa 3 hồ sơ. Vui lòng kiểm tra lại");
                return;
            }
            var resumeTitle = txtResumeName.Text;
            var user = new User(User1.Email, User1.UserId);
            var certificate = new Certificate(ddlDegrees.SelectedValue, ddlDegrees.SelectedItem.Text);
            var salary = new JobSalaryLevel(ddlExpectedSalary.SelectedValue, ddlExpectedSalary.SelectedItem.Text);
            var langSkill = new LangSkill(ddlLangSkill.SelectedValue, ddlLangSkill.SelectedItem.Text, txtDescription.Text);
            var location = new Province(ddlRegions.SelectedValue, ddlRegions.SelectedItem.Text);
            var category = new JobIndustries(ddlCategories.SelectedValue, ddlCategories.SelectedItem.Text);
            //var curentPostion = new JobPosition(ddlCurrentPosition.SelectedValue, ddlCurrentPosition.SelectedItem.Text);
            var expectedPosition = new JobPosition(ddlExpectedPosition.SelectedValue,
                ddlExpectedPosition.SelectedItem.Text);
            var jobExperienceLevel = new ExperienceLevel(ddlExp.SelectedValue,
                ddlExp.SelectedItem.Text);
            var worktype = new WorkType(ddlworktype.SelectedValue, ddlworktype.SelectedItem.Text);
            var jobAchievement = ta1.Value;
            var careerGoal = ta2.Value;
            var experience = ta3.Value;
            var literacy = ta6.Value;
            var skill = ta5.Value;
            var reference = ta4.Value;
            var contactmail = txtContactMail.Text;
            var attachmentPath = "";
            if (this.fuResume.HasFile)
            {
                string imgThumb = "E:\\DOCUMENTS\\School\\ASP.NETWorkSpaces\\WebFindingJobsMVCmodel\\FileSticky\\" + this.fuResume.FileName;
                this.fuResume.SaveAs(imgThumb);
                attachmentPath = "/FileSticky/" + this.fuResume.FileName;
            }
            Resume1 = new Resume();

            var returnValue = false;
            var query = Request.QueryString["resumeId"];
            if (query != null)
            {
                returnValue = Resume1.SetFullResumeInfoUpdate(resumeTitle, certificate, salary, langSkill, location,
                    category, expectedPosition, jobExperienceLevel, worktype,
                    jobAchievement, careerGoal, experience, literacy, skill, reference, user, contactmail, query, attachmentPath);
            }
            else
            {
                returnValue = Resume1.SetFullResumeInfo(resumeTitle, certificate, salary, langSkill, location, category, expectedPosition, jobExperienceLevel, worktype,
               jobAchievement, careerGoal, experience, literacy, skill, reference, user, contactmail, attachmentPath);
            }
            if (returnValue)
            {
                JavaScriptAleart("Thực hiện thành công");
            }
            else
            {
                JavaScriptAleart("Thực hiện không thành công. Vui lòng load lại trang và thử lại");
            }
        }
        catch (Exception exception)
        {

            JavaScriptAleart(exception.Message);

        }
    }

    protected void changeAvatar_Click(object sender, EventArgs e)
    {
    }

    protected void resume_attachment_del_Click(object sender, EventArgs e)
    {
    }

    protected void txtResumeName_OnTextChanged(object sender, EventArgs e)
    {
        lbNameResume.Text = txtResumeName.Text;
    }

    protected void ddlDegrees_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        lbCertificate.Text = ddlDegrees.SelectedItem.Text;
    }

    protected void ddlExp_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        lbExperienceLevel.Text = ddlExp.SelectedItem.Text;
    }

    protected void ddlLangSkill_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        lbLangSkill.Text = ddlLangSkill.SelectedItem.Text;
    }

    protected void LoadReviewResume()
    {
        ltrEmail2.Text = txtContactMail.Text;
        //ltrEmail.Text = txtContactMail.Text;
        lbJobPosition.Text = ddlExpectedPosition.SelectedItem.Text;
        lbLocation.Text = ddlRegions.SelectedItem.Text;
        lbCategory.Text = ddlCategories.SelectedItem.Text;
        lbSalaryLevel.Text = ddlExpectedSalary.SelectedItem.Text;
        lbCertificate.Text = ddlDegrees.SelectedItem.Text;
        lbWorkType.Text = ddlworktype.SelectedItem.Text;
        lbLangSkill.Text = ddlLangSkill.SelectedItem.Text;
        lbNameResume.Text = txtResumeName.Text;
        lbExperienceLevel.Text = ddlExp.SelectedItem.Text;
        lbCareerGoal.Text = ta2.Value;
        lbAchievement.Text = ta1.Value;
        lbLiteracy.Text = ta6.Value;
        lbSkill.Text = ta5.Value;
        lbReference.Text = ta4.Value;
        lbWorkExp.Text = ta3.Value;

    }

    protected void GoStep3(object sender, EventArgs e)
    {
        LoadReviewResume();
        LoadImage(User1.UserId);
        hfFuck.Value = "3";
        
    }

    protected void GoStep2(object sender, EventArgs e)
    {

        LoadReviewResume();
        LoadImage(User1.UserId);
        hfFuck.Value = "2";
         
    }
}