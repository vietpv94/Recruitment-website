using System;
using System.Net.Mail;
using Controllers;
using Models.DAO;
using Models.Objects;

public partial class SignUp : LoginControllers
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Visible = true;
        if (!IsPostBack && CheckSessionLogin())
        {
            Response.Redirect("Home.aspx");
        }
        if (!IsPostBack)
        {
            LoadDatas();
        }
    }

    private void LoadDatas()
    {
        if (GetAllCompanySize() != null && GetAllCompanySize().Rows.Count > 0)
        {
            BindDropDownList(ddlQuyMoCongTy, GetAllCompanySize(), "CompanySize", "CompanySizeID");
        }
    }


    protected void btEmployeeSignUp_Click(object sender, EventArgs e)
    {
        var dataAccess = new DaoLogin();
        bool isExistUsers = dataAccess.CheckExistUser(tbInputEmail.Value);
        bool isExistRecruitor = dataAccess.CheckExistRecruitor(tbInputEmail.Value);
        if (isExistUsers || isExistRecruitor)
        {
            
            JavaScriptAleart("Email đăng nhập đã tồn tại");
            return;
        }

        if (tbInputPassword.Text != tbRe_InputPassword.Text)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Nhập lại mật khẩu không đúng. ";
            return;
        }
        if (!checkPolicy2.Checked)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Bạn cần phải đồng ý với điều khoản của chúng tôi";
            return;
        }

        try
        {

            string captcha = CreateToRandomCode();
            Session["rdnCode"] = captcha;// Create valid code
            int userId = 0;
            var dataAccess1 = new DaoLogin();
            userId = dataAccess1.AddAnUserQuickly(tbInputEmail.Value, tbInputFirstName.Text, tbInputLastName.Text,
                Convert.ToDateTime(tbInputDateOfBirth.Value), Convert.ToInt32(ddlSex.SelectedValue), 0);
            var dataAccess2 = new DaoLogin();

            if (dataAccess2.AddALogin(tbInputEmail.Value, tbInputPassword.Text, userId, captcha, DateTime.Now) > 0)
            {
                SendEmailMember(tbInputFirstName.Text,tbInputEmail.Value);
                Session["STATUS"] = "ok";
                Response.Redirect("/Notify/NotificationCenter.aspx?Register=success");
            }
            else
            {
                JavaScriptAleart("Đăng ký không thành không !. Xin kiểm tra lại dữ liệu nhập vào");
            }
        }
        catch (Exception exception)
        {
            JavaScriptAleart("Đăng ký không thành không !. Xin kiểm tra lại dữ liệu nhập vào");
            Response.Write(exception.ToString());
        }

    }

    protected void btRecruitorSignUp_Click(object sender, EventArgs e)
    {
        var dataAccess3 = new DaoLogin();
        bool isExistUsers2 = dataAccess3.CheckExistUser(tbEmailRecruiment.Value);
        bool isExistRecruitor2 = dataAccess3.CheckExistRecruitor(tbEmailRecruiment.Value);
        if (isExistUsers2 || isExistRecruitor2)
        {
            
            JavaScriptAleart("Email đăng nhập đã tồn tại");
            return;
        }

        if (tbPasswordRecruiment.Text != tbRe_PasswordRecruiment.Text)
        {
            lblMessage2.Visible = true;
            lblMessage2.Text = "Nhập lại mật khẩu không đúng. ";
            return;
        }
        if (tbFirstNameRecruiment.Text.Equals(string.Empty) && tbLastNameRecruiment.Text.Equals(string.Empty))
        {
            lblMessage2.Visible = true;
            lblMessage2.Text = "Bạn cần nhập đầy đủ họ tên của mình!";
            return;
        }
        if (tbCompanyAddress.Text.Equals(string.Empty) && tbCompanyPhone.Value.Equals(string.Empty) && tbCompanyName.Text.Equals(string.Empty))
        {
            lblMessage2.Visible = true;
            lblMessage2.Text = "Bạn cần phải nhập đủ các trường còn trống !";
            return;
        }
        if (!checkPolicy.Checked)
        {
            lblMessage2.Visible = true;
            lblMessage2.Text = "Bạn cần phải đồng ý với điều khoản của chúng tôi!";
            return;
        }
        try
        {
            string randomCode = CreateToRandomCode();
            Session["rdnCode"] = randomCode;// Create valid code
            int recruitorId = 0;
            var dataAccess4 = new DaoLogin();
            recruitorId = dataAccess4.AddARecruitorQuickly(tbEmailRecruiment.Value,
                tbLastNameRecruiment.Text + " " + tbFirstNameRecruiment.Text, tbCompanyName.Text, tbCompanyAddress.Text,
                tbCompanyPhone.Value, Convert.ToInt32(ddlQuyMoCongTy.SelectedValue));
            var dataAccess5 = new DaoLogin();
            if (dataAccess5.AddARecruitorLogin(tbEmailRecruiment.Value, tbPasswordRecruiment.Text, recruitorId, randomCode, DateTime.Now) > 0)
            {
                Session["NameCompany"] = tbCompanyName.Text;
                SendEmailMember("active",tbEmailRecruiment.Value);                
                Session["STATUS"] = "ok";
                Response.Redirect("/Notify/NotificationCenter.aspx?Register=success");
            }
            else
            {
                JavaScriptAleart("Đăng ký không thành không !. Xin kiểm tra lại dữ liệu nhập vào");
            }
        }
        catch (Exception)
        {
            JavaScriptAleart("Đăng ký không thành không !. Xin kiểm tra lại dữ liệu nhập vào");
        }
    }
    #region menthod

    private string CreateToRandomCode()
    {
        const string strString = "abcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        string captcha = "";
        for (int i = 0; i < 15; i++)
        {
            int randomCharIndex = random.Next(0, strString.Length);
            char randomChar = strString[randomCharIndex];
            captcha += Convert.ToString(randomChar);
        }
        return captcha;
    }
    private void SendEmailMember(string id,string email)
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
            mail.Subject = "Email xác nhận";

            mail.Body = !id.Equals("active") ? "Xin chào:" + id + "\n" : "Xin chào:" + Session["NameCompany"] + "\n";
            mail.Body += "Cám ơn bạn đã đăng ký tại website KenhTimViecLam của chúng tôi: \n";
            mail.Body += "Vui lòng nhấn vào đường dẫn dưới đây để xác nhận đăng ký này : \n";
            mail.Body += "http://"+Request.Url.Host + ":" + Request.Url.Port +"/Notify/VerifyAccount.aspx?UserName=" + id + "&code=" + Session["rdnCode"];
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            smtpClient.Send(mail);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

  
    #endregion
}