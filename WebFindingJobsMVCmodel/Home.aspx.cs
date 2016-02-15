using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["url"] = String.Empty;
    }

    protected void btQuickSearch_Click(object sender, EventArgs e)
    {
        var keyWord = "";
        keyWord = tbQuickSearch.Text;
        Response.Redirect("FindJobs.aspx?KeyWord="+keyWord);
    }
}