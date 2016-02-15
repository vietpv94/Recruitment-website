using System;
using Models.Objects;

namespace UserControl
{
    public partial class UiUserControlHeader : System.Web.UI.UserControl
    {
        public string UserName;
        public string UserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            menu.Visible = false;
            btSignup.Visible = false;
            divAdmin.Visible = false;
            divrecruiter.Visible = false;
            menuManager.Visible = false;
            menuPostNews.Visible = false;
            menuRecruiter.Visible = false;
            string u = Request.QueryString["dangnhap"];
            if (u == "yes")
            {
                btLogin.Visible = false;
                btSignup.Visible = true;
                menu.Visible = false;
                divrecruiter.Visible = false;
            }

            var user = (User)Session["User"];
            if (user != null)
            {
                Session["User"] = user;
                UserId = user.UserId;
                UserName = user.FirstName;
                btLogin.Visible = false;
                btSignup.Visible = false;
                menu.Visible = true;
                divrecruiter.Visible = false;
            }
            var recruitor = (Recruitor)Session["Recruitor"];
            if (recruitor != null)
            {
                Session["Recruitor"] = recruitor;
                UserId = recruitor.RecruitorId;
                UserName = recruitor.CompanyFullname;
                btLogin.Visible = false;
                btSignup.Visible = false;
                menu.Visible = false;
                Home.Visible = false;
                menuManager.Visible = true;
                menuPostNews.Visible = true;
                menuRecruiter.Visible = true;
                menuSeekJob.Visible = false;
                divrecruiter.Visible = true;
            }
        }




        protected void btThoat_Click(object sender, EventArgs e)
        {

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Temp.aspx?Action=1");
        }
}
}