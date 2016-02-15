using System;
using Base;
using Models.DAO;

namespace Notify
{
    public partial class PagesRecoverPassword : CoreBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetHomePage();
        }

        private void SetHomePage()
        {
            if (Request["token"] == null)
                RedirectToHomepage();

            if (Request["email"] == null)
                RedirectToHomepage();

            const string protocol = "http://";
            var url = Request.Url.Host;
            if (!url.Contains(protocol))
                url = protocol + url;

            homepage.HRef = url;
        }

        private void RedirectToHomepage()
        {
            const string protocol = "http://";
            var url = Request.Url.Host+":"+Request.Url.Port+"/Home.aspx";
           
            if (!url.Contains(protocol))
                url = protocol + url;

            Response.Redirect(url);
        }

        protected void SubmitForms(object sender, EventArgs e)
        {
            try
            {
                if (Request["token"] == null)
                    RedirectToHomepage();

                if (Request["email"] == null)
                    RedirectToHomepage();

                if (txtPassword.Text == txtRePassword.Text)
                {

                    var token = Request["token"];
                    var password =txtPassword.Text.Trim();
                    var email = Request["email"];
                    var dao = new DaoLogin();
                    object oResult = dao.ResetPass(email, password, token);

                    if (oResult != null)
                    {
                        if (oResult.Equals("INVALID_TOKEN"))
                        {
                            JavaScriptAleart("Trang này đã hết hiệu lực.");
                        }
                        else
                        {
                           JavaScriptAleart("Đổi mật khẩu thành công, bạn có thể sử dụng mật khẩu mới để đăng nhập vào hệ thống!");
                        }
                    }
                }
                else
                {
                    JavaScriptAleart("Mật khẩu không khớp!");
                }
            }
            catch (Exception exception)
            {
                Console.Write(exception.ToString());
            }
        }
    }
}