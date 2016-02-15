using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controllers;
using Models.DAO;

public partial class Admin_RecruitementManage : GenaralController
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDatas();
        }
    }
    public void LoadDatas()
    {
        var dao = new DaoJobs();
        DataTable dataTable = dao.GetJobsByAdmin();
        if (dataTable == null || dataTable.Rows.Count <= 0) return;
        BindRepeater(rptAccounts, dataTable);
    }
    
    protected string Status(string status)
    {
        return status.Equals("1") ? "Hoạt động" : "Bị khóa";
    }

    protected bool ActionButtons(string index)
    {

        return index.Equals("True");
    }
    protected bool ActionButtons2(string index)
    {
        return !index.Equals("True");
    }


   

    protected void btUnHot_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            var isUnHot = UpdateJobsUnHotByAdmin(Convert.ToInt32(e.CommandName));
            if (isUnHot)
            {
                Response.Redirect("/Admin/RecruitementManage.aspx");
            }
            JavaScriptAleart("Cập Nhật Thất Bại");
        }
        catch (Exception exception)
        {
            JavaScriptAleart(exception.Message);
            throw;
        }
    }

    protected void btHot_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            var isHot = UpdateJobsHotByAdmin(Convert.ToInt32(e.CommandName));
            if (isHot)
            {
                Response.Redirect("/Admin/RecruitementManage.aspx");
            }
            JavaScriptAleart("Cập Nhật Thất Bại");
        }
        catch (Exception exception)
        {
            JavaScriptAleart(exception.Message);
            throw;
        }
    }

    protected void btDelete_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            var isDelete = DeleteJobsByAdmin(Convert.ToInt32(e.CommandName));
            if (isDelete)
            {
                Response.Redirect("/Admin/RecruitementManage.aspx");
            }
            JavaScriptAleart("Xóa Thất Bại");
        }
        catch (Exception exception)
        {
            JavaScriptAleart(exception.Message);
            throw;
        }
    }
}