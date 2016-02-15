using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.Objects;


public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // string s = BuidRecommendResume("2055");
        var u = new User("1");
        DateTime birtYear = Convert.ToDateTime(u.DateBirthDay);
        var age = DateTime.Now.Year - birtYear.Year;
        
       var job = new Jobs("2055");
       job.SetFullJobInfo();
       var list = job.ResumesRanking();
       Response.Write(birtYear);
     //   SendEmailMember(s,"solarface94@gmail.com");
    }
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
    private int Comparison(Resume rs1, Resume rs2)
    {
        if (rs2 != null && (rs1 != null && rs1.Rank > rs2.Rank))
            return -1;
        if (rs1 != null && (rs2 != null && rs2.Rank > rs1.Rank))
            return 1;//Nhở hơn
        return 0;//Bằng nhau
    }
    private string BuidRecommendResume(string jobid)
    {
        var buider = new StringBuilder();
        var job = new Jobs(jobid);
        job.SetFullJobInfo();
        //jobs.SetFullJobInfo();
        var list = job.ResumesRanking();
       // list.Sort(Comparison);
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
            DateTime birtYear = Convert.ToDateTime(resume.User.DateBirthDay);
            var age = DateTime.Now.Year - birtYear.Year;
            buider.AppendLine("<tr>");
            buider.AppendLine("<th style='text-align: center'>" + i + 1 + "</th>");
            buider.AppendLine("<th style='text-align: center'>" + resume.User.LastName + " &nbsp;" + resume.User.FirstName + "</th>");
            buider.AppendLine("<th style='text-align: center'>" + age + "</th>");
            buider.AppendLine("<th style='text-align: center'>" + resume.JobPosition.Position + "</th>");
            buider.AppendLine("<th style='text-align: center'><a href='ResumeDetail.aspx?resumeid=" + resume.ResumeId + "&userid=" + resume.User.UserId);
            buider.AppendLine("'>Xem Chi Tiết</a></th>");
            buider.AppendLine("</tr>");
        }
        buider.AppendLine("</tbody>");
        buider.AppendLine("<tfoot></tfoot></table>");
        return buider.ToString();
    }
}