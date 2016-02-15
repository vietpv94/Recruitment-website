using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.Objects;

public partial class Admin_controls_HeaderAdmin : System.Web.UI.UserControl
{
    protected string UserId;
    protected void Page_Load(object sender, EventArgs e)
    {
        var user = (User)Session["Admin"];
        if (user != null)
        {
            Session["Admin"] = user;
            UserId = user.UserId;
            if (user.UserId != "1")
            {
                godAccount.Visible = false;
                godAccount1.Visible = false;
            }
        }
    }
}