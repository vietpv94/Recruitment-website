using System;
using System.Data;
using Controllers;
using Models.Objects;

namespace Admin
{
    public partial class AdminLogin : LoginControllers
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            var login = new Login(txtUserId.Text, txtPassWord.Text);
            if (login.CheckLogin() == 1)
            {
                DataTable dataTable = login.GetUserInfo(1);
                string userId = dataTable.Rows[0]["UserID"].ToString();
                string emailLogin = dataTable.Rows[0]["Email"].ToString();
                string firstName = dataTable.Rows[0]["FirstName"].ToString();

                JavaScriptAleart(login.CheckAdmin(Convert.ToInt32(userId)).ToString());
                if (login.CheckAdmin(Convert.ToInt32(userId)))
                {
                    Session["Login"] = login;
                    DateTime dateOfBirth = Convert.ToDateTime(dataTable.Rows[0]["DateOfBirth"].ToString());
                    var address = new Address();
                    var sex = new Sex();
                    var user = new User(userId, emailLogin, firstName, dateOfBirth, sex, address);
                    Session["Admin"] = user;
                    Response.Redirect("Index.aspx");

                }
                else
                {
                    ltrMessage.Visible = true;
                    ltrMessage.Text = "Tài khoản của bạn không có quyền truy cập vào admin hệ thống \n";
                    ltrMessage.Text += "Vui lòng liên hệ để biết thêm chị tiết";
                }
            }
            else
            {
                ltrMessage.Visible = true;
                ltrMessage.Text = "Tài Khoản không tồn tại hoặc đã bị khóa";

            }
        }
    }
}