using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controllers;

public partial class Admin_Admin : LoginControllers
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckSessionAdminLogin())
        {
            Response.Redirect("Login.aspx");
        }
        Response.Redirect("Index.aspx");
    }
}