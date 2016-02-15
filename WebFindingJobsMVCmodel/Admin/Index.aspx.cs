using System;
using Controllers;

public partial class Admin_Index : LoginControllers
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckSessionAdminLogin())
        {
            Response.Redirect("Login.aspx");
        }
    }

}