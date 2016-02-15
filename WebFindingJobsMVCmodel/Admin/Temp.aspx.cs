using System;
using Base;

public partial class Temp : CoreBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Action"] == "1")
        {
            
            Session["Admin"] = null;
            Session["Login"] = null;
            Application["UsersOnline"] = (int)Application["UsersOnline"] - 1;
            Response.Redirect("Admin.aspx");
        }
    }
}