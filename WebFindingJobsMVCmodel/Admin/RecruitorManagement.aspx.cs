using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controllers;
using Models.DAO;

public partial class Admin_RecruitorManagement : GenaralController
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
        var dao = new DaoRecruiter();
        DataTable dataTable = dao.GetRecruiterAccounts();
        if (dataTable == null || dataTable.Rows.Count <= 0) return;
        BindRepeater(rptAccounts, dataTable);
    }

    protected void btBlock_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            var isDelete = BlockRecruiterAcount(Convert.ToInt32(e.CommandName));
            if (isDelete)
            {
                Response.Redirect("/Admin/RecruitorManagement.aspx");
            }
            JavaScriptAleart("Khóa Thất Bại");
        }
        catch (Exception exception)
        {
            JavaScriptAleart(exception.Message);
            throw;
        }

    }

    protected string Status(string status)
    {
        return status.Equals("1") ? "Hoạt động" : "Bị khóa";
    }

    protected bool ActionButtons(string index)
    {
       
        return index.Equals("1");
    }
    protected bool ActionButtons2(string index)
    {
        return !index.Equals("1");
    }


    protected void btUnLock_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            var isUnlock = UnlockRecrutorAcount(Convert.ToInt32(e.CommandName));
            if (isUnlock)
            {
                Response.Redirect("/Admin/RecruitorManagement.aspx");
            }
            JavaScriptAleart("Mở Khóa Thất Bại");
        }
        catch (Exception exception)
        {
            JavaScriptAleart(exception.Message);
            throw;
        }
    }
}