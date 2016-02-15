using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Base;
using Controllers;
using Models.DAO;

public partial class Admin_AddAccount : LoginControllers
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckSessionAdminLogin())
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void btSubmit_OnClick(object sender, EventArgs e)
    {
        var dataAccess = new DaoLogin();
       
        bool isExistUsers = dataAccess.CheckExistUser(txtEmail.Value);
        bool isExistRecruitor = dataAccess.CheckExistRecruitor(txtEmail.Value);
        if (isExistUsers || isExistRecruitor)
        {
            JavaScriptAleart("Email đăng nhập đã tồn tại");
            return;
        }

        try
        {

            int userId = 0;
            var dataAccess1 = new DaoLogin();
            userId = dataAccess1.AddAnAdminQuickly(txtEmail.Value, txtfirstname.Value, txtLastname.Value,
                Convert.ToDateTime("10/04/1994"), txtPhone.Value, 1);
            var dataAccess2 = new DaoLogin();

            if (dataAccess2.AddALogin(txtEmail.Value, txtPass.Value, userId, "AdminVIPNoNeedCaptcha", DateTime.Now) > 0)
            {
                JavaScriptAleart("Tài khoản quản trị được tạo thành công!");
            }
            else
            {
                JavaScriptAleart("Tạo tài khoản không thành không !. Xin kiểm tra lại dữ liệu nhập vào");
            }
        }
        catch (Exception exception)
        {
            JavaScriptAleart("Tạo tài khoản không thành không !. Xin kiểm tra lại dữ liệu nhập vào");
            Response.Write(exception.ToString());
        }
    }
}