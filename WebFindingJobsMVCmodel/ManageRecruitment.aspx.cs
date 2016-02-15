using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using Controllers;
using Models.Objects;

public partial class ManageRecruitment : JobsController
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDatas();
        }
    }

    private void LoadDatas()
    {
        var recruiter = (Recruitor) Session["Recruitor"];
        DataTable data = GetAllJobsByRecruiter(recruiter.RecruitorId);
        var dataRows = from dataRow in data.AsEnumerable()
            where dataRow.Field<DateTime>("ExpiredDate") >= DateTime.Now 
            select dataRow;
        if (dataRows.Any())
        {
            BindRepeater(rptRecrutting, dataRows.CopyToDataTable());
        }
            
            var dataRows2 = from dataRow2 in data.AsEnumerable()
                           where dataRow2.Field<DateTime>("ExpiredDate") < DateTime.Now
                           select dataRow2;
        if (dataRows2.Any())
        {
            BindRepeater(rptOutOfDate, dataRows2.CopyToDataTable());
            
        }
    }
    protected void btDelete_OnCommand(object sender, CommandEventArgs e)
    {
        var isDelete = DeleteAJobByRecuiter(Convert.ToInt32(e.CommandName));
        if (isDelete)
        {
            Response.Redirect("ManageRecruitment.aspx");
        }
        JavaScriptAleart("Xóa Thất Bại");
    }

    protected void btUpdateNews_OnCommand(object sender, CommandEventArgs e)
    {Response.Redirect("PostNews.aspx?jobid="+e.CommandName);
    }
}