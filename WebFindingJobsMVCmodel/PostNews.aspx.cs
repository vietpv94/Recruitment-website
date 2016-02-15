using System;
using System.Linq;
using System.Net.Mail;
using System.Text;
using Controllers;
using Models.Objects;

public partial class PostNews : GenaralController
{
    public Jobs Jobs1;
    public Recruitor Recruitor1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDatas();
        }
       
    }
    private void LoadDatas()
    {
        var jobid = Request.QueryString["jobid"];
        if (jobid != null)
        {
            LoadJobHaveBeenCreated(jobid);
        }
        LoadRecruimentInfo();
        SetExistRecruiterInfo();
    }

    private void LoadJobHaveBeenCreated(string jobid)
    {
        var job = new Jobs(jobid);
        job.SetFullJobInfo();
        BindDropDownList(ddlRegions, GetAllProvine(), "ProvinceName", "ProvinceID");
        ddlRegions.SelectedValue = job.Province.Id;

        BindDropDownList(ddlSalary, GetAllSalaryLevel(), "SalaryLevel", "SalaryLevelID");
        ddlSalary.SelectedValue = job.JobSalaryLevel.JobSalaryLevelId;

        BindDropDownList(ddlCategories, GetAllJobs(), "JobIndustryName", "JobIndustryID");
        ddlCategories.SelectedValue = job.JobIndustries.JobIndutriesId;

        BindDropDownList(ddlDegrees, GetAllCertificates(), "CertificateName", "CertificateID");
        ddlDegrees.SelectedValue = job.Certificate.CertificateId;

        BindDropDownList(ddlWorkType, GetAllWorkTypes(), "WorkTypeName", "WorkTypeID");
        ddlWorkType.SelectedValue = job.WorkType.WorkTypeId;

        BindDropDownList(ddlJobPosition, GetAllJobPosition(), "JobPositionName", "JobPositionID");
        ddlJobPosition.SelectedValue = job.JobPosition.JobPositionId;

        BindDropDownList(ddlJobExperienceLevel, GetAllExperienceLevel(), "ExperienceLevelName", "ExperienceLevelID");
        ddlJobExperienceLevel.SelectedValue = job.ExperienceLevel.ExperianceLevelId;

        txtJobTitle.Text = job.JobTitle;
        txtNumsApplicant.Text = job.NumsApplicant;
        txtDescription.Value = job.Description;
        txtJobDetail.Value = job.ContentDetail;
        tbDeadline.Value = Convert.ToDateTime(job.ExpiredDate).ToString("dd/MM/yyyy");
    }
    private void LoadRecruimentInfo()
    {
        BindDropDownList(ddlRegions, GetAllProvine(), "ProvinceName", "ProvinceID");
        BindDropDownList(ddlSalary, GetAllSalaryLevel(), "SalaryLevel", "SalaryLevelID");
        BindDropDownList(ddlCategories, GetAllJobs(), "JobIndustryName", "JobIndustryID");
        BindDropDownList(ddlDegrees, GetAllCertificates(), "CertificateName", "CertificateID");
        BindDropDownList(ddlWorkType, GetAllWorkTypes(), "WorkTypeName", "WorkTypeID");
        BindDropDownList(ddlJobPosition, GetAllJobPosition(), "JobPositionName", "JobPositionID");
        BindDropDownList(ddlJobExperienceLevel, GetAllExperienceLevel(), "ExperienceLevelName", "ExperienceLevelID");
    }
    private void SetExistRecruiterInfo()
    {
        Recruitor1 = (Recruitor)Session["Recruitor"];
        
        if (Recruitor1 == null)
        {
            Session["Jobs"] = null;
            Session["Login"] = null;
            Session["Recruitor"] = null;
            Response.Redirect("Login.aspx");
        }
        else
        {
            Recruitor1.SetFullRecruiterInfo();
            Session["Recruitor"] = Recruitor1;
            txtFullNameCompany.Text = Recruitor1.CompanyFullname;
            txtAddress.Text = Recruitor1.Address;
            txtShortNameCompany.Text = Recruitor1.CompanyShortname;
            txtPeopleContact.Text = Recruitor1.RecruitorName;
            txtPhoneContact.Text = Recruitor1.PhoneToCallForJob;
            txtEmailContact.Text = Recruitor1.EmailToSendResume;

            BindDropDownList(ddlQuyMoCongTy, GetAllCompanySize(), "CompanySize", "CompanySizeID");
            ddlQuyMoCongTy.SelectedValue = Recruitor1.CompanySize.CompanySizeId;
        }
    }
    protected void btnSubmitInfoCompany_OnClick(object sender, EventArgs e)
    {
        try
        {
            var companyName = txtFullNameCompany.Text;
            var companyShortName = txtShortNameCompany.Text;
            var companySize = new CompanySize(ddlQuyMoCongTy.SelectedValue, ddlQuyMoCongTy.SelectedItem.Text);
            var address = txtAddress.Text;
            Recruitor1 = (Recruitor)Session["Recruitor"];
            var returnValue = Recruitor1.SetFullCompanyInfo(companyName, companyShortName, companySize, address);
            SetExistRecruiterInfo();
            if (returnValue)
            {
                Session["Recruitor"] = Recruitor1;
                SetExistRecruiterInfo();
                JavaScriptAleart("Thực hiện thành công");
            }
            else
            {
                JavaScriptAleart("Chỉnh sửa không thành công. Vui lòng load lại trang và thử lại");
            }
        }

        catch (Exception)
        {
            JavaScriptAleart("Chỉnh sửa không thành công. Vui lòng load lại trang và thử lại");

        }
    }
    protected void btnCancle_OnClick(object sender, EventArgs e)
    {
        Recruitor1 = (Recruitor)Session["Recruitor"];
        SetExistRecruiterInfo();
    }
    protected void btnSubmitRecuitmentInfo_OnClick(object sender, EventArgs e)
    {
        try
        {
            Recruitor1 = (Recruitor)Session["Recruitor"];
            var jobTitle = txtJobTitle.Text;
            var numsApplicant = txtNumsApplicant.Text;
            var recruitor = new Recruitor(Recruitor1.Email, Recruitor1.RecruitorId);
            var certificate = new Certificate(ddlDegrees.SelectedValue, ddlDegrees.SelectedItem.Text);
            var salary = new JobSalaryLevel(ddlSalary.SelectedValue, ddlSalary.SelectedItem.Text);
            var location = new Province(ddlRegions.SelectedValue, ddlRegions.SelectedItem.Text);
            var category = new JobIndustries(ddlCategories.SelectedValue, ddlCategories.SelectedItem.Text);
            var jobPostion = new JobPosition(ddlJobPosition.SelectedValue, ddlJobPosition.SelectedItem.Text);
            var jobExperienceLevel = new ExperienceLevel(ddlJobExperienceLevel.SelectedValue,
                ddlJobExperienceLevel.SelectedItem.Text);
            var worktype = new WorkType(ddlWorkType.SelectedValue, ddlWorkType.SelectedItem.Text);
            var jobDatail = txtJobDetail.Value;
            var jobDescription = txtDescription.Value;
            var deadLine = Convert.ToDateTime(tbDeadline.Value);
            Jobs1 = new Jobs();
            var jobid = Request.QueryString["jobid"];
            if (jobid != null)
            {
                  var  returnValue = Jobs1.SetFullJobInfo(jobTitle, certificate, salary, location, category, jobDatail,
                    jobDescription, deadLine, jobPostion, jobExperienceLevel, worktype, recruitor, numsApplicant, jobid);

                if (returnValue)
                {
                    Session["Job"] = Jobs1;
                    var emailContent = BuidRecommendResume(jobid);
                    SendEmailMember(emailContent, Recruitor1.EmailToSendResume);
                    JavaScriptAleart("Thực hiện thành công");
                }
                else
                {
                    JavaScriptAleart("Thực hiện không thành công. Vui lòng load lại trang và thử lại");
                }
            }
            else
            {
               var returnValue1 = Jobs1.SetFullJobInfo(jobTitle, certificate, salary, location, category, jobDatail,
                    jobDescription, deadLine, jobPostion, jobExperienceLevel, worktype, recruitor, numsApplicant);
                
               if (returnValue1>0)
               {

                   Session["Job"] = Jobs1;
                   var emailContent = BuidRecommendResume(returnValue1.ToString());
                   JavaScriptAleart(emailContent);
                   SendEmailMember(emailContent, Recruitor1.EmailToSendResume);
                   JavaScriptAleart("Thực hiện thành công");
               }
               else
               {
                   JavaScriptAleart("Thực hiện không thành công. Vui lòng load lại trang và thử lại");
               }
            }
        }
        catch (Exception exception)
        {
            JavaScriptAleart(exception.Message);
        }
    }
    #region Mail
    private void SendEmailMember(string emailContent, string email)
    {
        var smtpClient = new SmtpClient
        {
            Credentials = new System.Net.NetworkCredential("webfindingjobsmvcmodel.net@gmail.com", "abcABC123!@#$"),
            Port = 587,
            Host = "smtp.gmail.com",
            EnableSsl = true,
            
        };
        var mail = new MailMessage();
        try
        {
            mail.From = new MailAddress("webfindingjobsmvcmodel.net@gmail.com", "Demo Group-33 Noreply", System.Text.Encoding.UTF8);
            mail.To.Add(email);
            mail.CC.Add("webfindingjobsmvcmodel.net@gmail.com");
            mail.Subject = "KenhTimViec Recommendation Resume";
            mail.Body = emailContent;
            mail.IsBodyHtml = true;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            smtpClient.Send(mail);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    #endregion
    private int Comparison(Resume rs1, Resume rs2)
    {
        if (rs2 != null && (rs1 != null && rs1.Rank > rs2.Rank))
            return -1;
        if (rs1 != null && (rs2 != null && rs2.Rank > rs1.Rank))
            return 1;//Nhở hơn
        return 0;//Bằng nhau
    }
    protected void btnCancle1_OnClick(object sender, EventArgs e)
    {
        Recruitor1 = (Recruitor)Session["Recruitor"];
        SetExistRecruiterInfo();
    }

    private string BuidRecommendResume(string jobid)
    {
        var buider = new StringBuilder();
        var job = new Jobs(jobid);
        job.SetFullJobInfo();
        //jobs.SetFullJobInfo();
        var list = job.ResumesRanking();
        list.Sort(Comparison);
        buider.AppendLine("<h4>Cám ơn bạn đã đăng tin tuyển dụng của chúng tôi<h4>");
        buider.AppendLine("<p>Dưới đây là danh sách các ứng viên có thể phù hợp với công việc của ban</p>");
        buider.AppendLine("<table id='example1' class='table table-bordered table-striped dataTable' aria-describedby='example1_info'>");
        buider.AppendLine("<thead><tr role='row>");
        buider.AppendLine("<th style='text-align: center'>STT</th>");
        buider.AppendLine("<th style='text-align: center'>Họ Tên</th>");
        buider.AppendLine("<th style='text-align: center'>Tuổi</th>");
        buider.AppendLine("<th style='text-align: center'>Vị Trí Ứng Tuyển</th>");
        buider.AppendLine("<th style='text-align: center'></th>");
        buider.AppendLine(" </tr></thead>");
        buider.AppendLine(" <tbody role='alert' aria-live='polite' aria-relevant='all'>");
        int i = 0;
        foreach (Resume resume in list.Take(10))
        {
            i += 1;
            var u = new User(resume.User.UserId);
            u.SetFullInfo();
            DateTime birtYear = Convert.ToDateTime(u.DateBirthDay);
            var age = DateTime.Now.Year - birtYear.Year;
            buider.AppendLine("<tr>");
            buider.AppendLine("<th style='text-align: center'>"+i+"</th>");
            buider.AppendLine("<th style='text-align: center'>" + u.LastName + " &nbsp;" +u.FirstName+ "</th>");
            buider.AppendLine("<th style='text-align: center'>"+age+"</th>");
            buider.AppendLine("<th style='text-align: center'>"+resume.JobPosition.Position+"</th>");
            buider.AppendLine("<th style='text-align: center'><a href='"+"http://"+Request.Url.Host + ":" + Request.Url.Port +"/ResumeDetail.aspx?resumeid=" + resume.ResumeId+"&userid="+resume.User.UserId);
            buider.AppendLine("'>Xem Chi Tiết</a></th>");
            buider.AppendLine("</tr>");
        }
        buider.AppendLine("</tbody>");
        buider.AppendLine("<tfoot></tfoot></table>");
        return buider.ToString();
    }
    protected void btnSubmitContactInfo_OnClick(object sender, EventArgs e)
    {

        try
        {
            var recruitorName = txtPeopleContact.Text;
            var phoneContact = txtPhoneContact.Text;
            var emailContact = txtEmailContact.Text;
            Recruitor1 = (Recruitor)Session["Recruitor"];
            var returnValue = Recruitor1.SetFullContactInfo(recruitorName, phoneContact, emailContact);
            SetExistRecruiterInfo();
            if (returnValue)
            {
                Session["Recruitor"] = Recruitor1;
                SetExistRecruiterInfo();
                JavaScriptAleart("Thực hiện thành công");
            }
            else
            {
                JavaScriptAleart("Chỉnh sửa không thành công. Vui lòng load lại trang và thử lại");
            }
        }

        catch (Exception)
        {
            JavaScriptAleart("Chỉnh sửa không thành công. Vui lòng load lại trang và thử lại");

        }
    }
    protected void btnCancle2_OnClick(object sender, EventArgs e)
    {
        Recruitor1 = (Recruitor)Session["Recruitor"];
        SetExistRecruiterInfo();
    }

}