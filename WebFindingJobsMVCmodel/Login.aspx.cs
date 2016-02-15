using System;
using System.Data;
using System.Net.Mail;
using Controllers;
using Models.DAO;
using Models.Objects;


public partial class Login : LoginControllers
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (CheckSessionLogin())
        {
            Response.Redirect("Home.aspx");
        }
        string s=Request.QueryString["forgotpass"];
        if (s == "yes")
        {
            loginform.Visible = false;
            logintitle.Visible = false;
            forgotpass.Visible = true;
        }
        else
        {
            loginform.Visible = true;
            forgotpass.Visible = false;
            logintitle.Visible = true;
        }        
    }
    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        var login = new Models.Objects.Login(txtEmailId.Text, txtPassWord.Text);
        if (login.CheckLogin()==1)
        {
            DataTable dataTable = login.GetUserInfo(1);
            Session["Login"] = login;
            string userId = dataTable.Rows[0]["UserID"].ToString();
            string emailLogin = dataTable.Rows[0]["Email"].ToString();
            string firstName = dataTable.Rows[0]["FirstName"].ToString();
            DateTime dateOfBirth = Convert.ToDateTime(dataTable.Rows[0]["DateOfBirth"].ToString());
            var address = new Address();
            var sex = new Sex();
            var user = new User(userId, emailLogin, firstName,dateOfBirth, sex, address);
            Session["User"] = user;
            var url = (string)Session["url"];
            JavaScriptAleart(url);
            if (!string.IsNullOrEmpty(url))
            {
                Session["url"] = String.Empty;
                Response.Redirect(url);
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }
        else if (login.CheckLogin() == 2)
        {

            DataTable dataTable = login.GetUserInfo(2);
            Session["Login"] = login;
            string recruitorId = dataTable.Rows[0]["RecruitorID"].ToString();
            string emailLogin = dataTable.Rows[0]["EmailLogin"].ToString();
            string companyName = dataTable.Rows[0]["CompanyFullName"].ToString();
            var address = dataTable.Rows[0]["Address"].ToString();
            var phone = dataTable.Rows[0]["PhoneToCallForJob"].ToString();
            var recruitorName = dataTable.Rows[0]["RecruitorName"].ToString();
            var recruitor = new Recruitor(recruitorId, emailLogin, companyName, recruitorName, phone, address);
            Session["Recruitor"] = recruitor;
            Response.Redirect("Recruiters.aspx");
            
        }
        else
        {
            JavaScriptAleart("Tài khoản,mật khẩu không chính xác! Hoặc có thể chưa được kích hoạt hay đã bị khóa, vui lòng liên hệ vơi quản trị viên để biết thêm thông tin ");
        }
    }

    protected void btnForgot_Click(object sender, EventArgs e)
    {
        try
        {
            var email = inputEmail.Value.Trim();
            var token = email + DateTime.Now;
            var dao = new DaoLogin();
            object oResult = dao.RecoverPassInfo(email, token);
           

            if (oResult == null || oResult.ToString().Equals("0"))
            {
                JavaScriptAleart("Khôi phục mật khẩu thất bại");
                return;
            }
            if (oResult.Equals("INVALID_EMAIL"))
            {
                JavaScriptAleart("Email bạn nhập chưa được đăng ký với chúng tôi");
                return;
            }
            if (oResult.Equals("NOT_ACTIVE"))
            {
                JavaScriptAleart("Tài khoản của bạn chưa được kích hoạt nên không thể sử dụng chức năng này");
                return;
            }
            if (oResult.Equals("2"))
            {
                var dao2 = new DaoRecruiter();
                var dataTable2 = dao2.GetRecruitorInfoByEmail(email);
                var code2 = dataTable2.Rows[0]["User_Valid_Email_Code"].ToString();
                SendEmailMember(code2, email);
                Session["STATUS"] = "ok";
                Response.Redirect("/Notify/NotificationCenter.aspx?Forgot=success");
            }
            else
            {
                var dao1 = new DaoLogin();
                var dataTable = dao1.GetLoginInfo(email);
                var code = dataTable.Rows[0]["User_Valid_Email_Code"].ToString();
                SendEmailMember(code, email);
                Session["STATUS"] = "ok";
                Response.Redirect("/Notify/NotificationCenter.aspx?Forgot=success");
            }
        }
        catch (NullReferenceException ex)
        {
            JavaScriptAleart("" + ex.Message);
        }
    }
   
    private void SendEmailMember(string id, string email)
    {
        var smtpClient = new SmtpClient
        {
            Credentials = new System.Net.NetworkCredential("webfindingjobsmvcmodel.net@gmail.com", "abcABC123!@#$"),
            Port = 587,
            Host = "smtp.gmail.com",
            EnableSsl = true
        };
        var mail = new MailMessage();
        try
        {
            mail.From = new MailAddress("webfindingjobsmvcmodel.net@gmail.com", "Demo Group-33 Noreply", System.Text.Encoding.UTF8);
            mail.To.Add(email);
            mail.CC.Add("webfindingjobsmvcmodel.net@gmail.com");
            mail.Subject = "Email Khôi Phục Mật Khẩu";
            mail.Body = "Xin chào bạn!";
            mail.Body += "Bạn vừa yêu cầu cấp lại mật khẩu tại website KenhTimViecLam. Vui lòng bấm vào link dưới đây để lấy mật khẩu mới:\n";
            mail.Body += "http://"+Request.Url.Host + ":" + Request.Url.Port +"/Notify/RecoverPassword.aspx?email=" + email + "&token="+id ;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            smtpClient.Send(mail);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}