using System;
using System.Data;
using System.Web.UI.WebControls;
using Base;
using Controllers;
using Models.DAO;

public partial class Admin_Accounts : GenaralController
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
        var dao = new DaoUser();
        DataTable dataTable = dao.GetAccounts();
        if (dataTable == null || dataTable.Rows.Count <= 0) return;
        BindRepeater(rptAccounts, dataTable);
    }

    protected void btBlock_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            var isDelete = BlockAcount(Convert.ToInt32(e.CommandName));
            if (isDelete)
            {
                Response.Redirect("/Admin/Accounts.aspx");
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

    protected bool ActionButtons(string index,string userId)
    {
        if (userId.Equals("1"))
        {
            return false;   
        }
      return index.Equals("1");
    }
    protected bool ActionButtons2(string index,string userId)
    {
        if (userId.Equals("1"))
        {
            return false;
        }
        return !index.Equals("1");
    }
  

    protected void btUnLock_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            var isUnlock = UnlockAcount(Convert.ToInt32(e.CommandName));
            if (isUnlock)
            {
                Response.Redirect("/Admin/Accounts.aspx");
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