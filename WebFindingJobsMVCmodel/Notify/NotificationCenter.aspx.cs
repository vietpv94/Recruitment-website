using System;

namespace Notify
{
    public partial class PagesNotificationCenter : System.Web.UI.Page
    {
        const string Protocol = "http://";
        public string Url = "";
        public string RefUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null) RefUrl = Request.UrlReferrer.ToString();
            }
            Url = Request.Url.Host;
            if (!Url.Contains(Protocol))
                Url = Protocol + Url;
            if (Session["STATUS"] == null)
            {
                Response.Redirect(Url);
            }
            Session.Remove("STATUS");
            if (Request.QueryString["Register"] == null & Request.QueryString["Forgot"] == null)
            {
                Response.Redirect(Url);
            }
            RegisterSuccess();
            ForgotSuccess();
        }

        protected void RegisterSuccess()
        {
            if (Request.QueryString["Register"] != null)
            {
                if (Request.QueryString["Register"] != "success")
                {
                    Response.Redirect(Url);
                }
                Register.Visible = true;
                Reg_success.Visible = true;
            }
        }

        protected void ForgotSuccess()
        {
            if (Request.QueryString["Forgot"] != null)
            {
                if (Request.QueryString["Forgot"] != "success")
                {
                    Response.Redirect(Url);
                }
                ForgotPass.Visible = true;
                Forgot_success.Visible = true;
            }
        }

    
    }
}