using System;
using System.Data;
using System.Linq;
using System.Web;
using Controllers;
using Models.Objects;

public partial class ListProfiles : ResumeController
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
        var key = Request.QueryString["keyword"];
        var dataTable = (DataTable) Session["SearchResult"];
        var ages = (Ages) Session["Ages"];
        
        if (key != null)
        {
            var isFindByAge = ages.FromYear - ages.ToYear;
            if (isFindByAge!=0)
            {
                var dataRows = from dataRow in dataTable.AsEnumerable()
                               where RemoveSign4VietnameseString(dataRow.Field<string>("ResumeName").ToLower())
                                   .Contains(RemoveSign4VietnameseString(key.Trim().ToLower())) && (dataRow.Field<int>("OrderYear")) >= ages.ToYear && (dataRow.Field<int>("OrderYear")) <= ages.FromYear
                               select dataRow;
                if (dataRows.Any())
                {
                    lbNumberFinded.Text = dataRows.Count().ToString();
                    BindRepeater(rptSearchResumeResult, dataRows.CopyToDataTable());
                }
                else
                {
                    BindRepeater(rptSearchResumeResult, new DataTable());
                    lbNumberFinded.Text = "0";
                }
            }
            else
            {
                var dataRows = from dataRow in dataTable.AsEnumerable()
                               where RemoveSign4VietnameseString(dataRow.Field<string>("ResumeName").ToLower())
                                   .Contains(RemoveSign4VietnameseString(key.Trim().ToLower()))
                               select dataRow;
                if (dataRows.Any())
                {
                    lbNumberFinded.Text = dataRows.Count().ToString();
                    BindRepeater(rptSearchResumeResult, dataRows.CopyToDataTable());
                }
                else
                {
                    BindRepeater(rptSearchResumeResult, new DataTable());
                    lbNumberFinded.Text = "0";
                }
            }
          
        }
        else
        {
            var jobid=Request.QueryString["jobid"];
            lbNumberFinded.Text = GetResumeAppliedJob(jobid).Rows.Count.ToString();
            BindRepeater(rptSearchResumeResult,GetResumeAppliedJob(jobid));
            Session["JobID"] = jobid;
        }
      
    }
    
}