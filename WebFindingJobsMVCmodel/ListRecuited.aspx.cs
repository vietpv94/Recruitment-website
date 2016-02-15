using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controllers;
using Models.Objects;

public partial class ListRecuited : ResumeController
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDatas();
        }
        Session["rewriteurl"] = HttpContext.Current.Request.Url;
    }

    private void LoadDatas()
    {
        var jobid = Request.QueryString["jobid"];
        lbNumberFinded.Text = GetResumeRecruitedJob(jobid).Rows.Count.ToString();
        BindRepeater(rptSearchResumeResult, GetResumeRecruitedJob(jobid));
    
    }
}