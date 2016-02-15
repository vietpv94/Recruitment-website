using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Base;
using Controllers;
using Models.Objects;

public partial class Admin_ModifyAcount : JobsController
{
    public User User1;
    protected string ThumbImg;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDatas();
        }

    }

    public void LoadDatas()
    {
        SetExistInfo();
        var userId = Request.QueryString["UserId"];
        SetEnabled(User1.UserId.Equals(userId));
    }

    private void SetEnabled(bool status)
    {
        txtName.Enabled = status;
        txtPhoneNumber.Enabled = status;
        txtDateOfBirth.Enabled = status;
        txtMaxim.Enabled = status;
        ddRaces.Enabled = status;
        ddlDistrict.Enabled = status;
        ddlJob.Enabled = status;
        ddlProvine.Enabled = status;
        ddlSex.Enabled = status;
        btnInfoCancel.Enabled = status;
        btnUserInfoSubmit.Enabled = status;
        fuResume.Enabled = status;

    }
    public void SetExistInfo()
    {
        User1 = (User)Session["Admin"];
        if (User1 == null)
        {
            Session["Login"] = null;
            Session["Admin"] = null;
            Response.Redirect("/Admin/Login.aspx");
        }
        else
        {
            var userId = Request.QueryString["UserId"];
            var user2 = new User(userId);
            user2.SetFullInfo();
            Session["User"] = user2;
            txtName.Text = user2.LastName + " " + user2.FirstName;
            txtDateOfBirth.Text = Convert.ToDateTime(user2.DateBirthDay).ToString("dd/MM/yyyy");
            txtPhoneNumber.Text = user2.PhoneNumber;
            txtMaxim.Text = user2.MaximOfLife;
            ThumbImg = user2.ThumImg;

            BindDropDownList(ddlProvine, GetAllProvine(), "ProvinceName", "ProvinceID");
            ddlProvine.SelectedValue = user2.Address.Province.Id;

            BindDropDownList(ddlDistrict, GetAllDistrictInProvince(User1.Address.Province.Id), "DistrictName", "DistrictID");
            ddlDistrict.SelectedValue = user2.Address.District.Id;

            BindDropDownList(ddRaces, GetAllRaces(), "RaceName", "RaceID");
            ddRaces.SelectedValue = user2.Races.RaceId;

            BindDropDownList(ddlJob, GetAllJobs(), "JobIndustryName", "JobIndustryID");
            ddlJob.SelectedValue = user2.JobIndustries.JobIndutriesId;

            BindDropDownList(ddlSex, GetAllSexs(), "SexName", "SexID");
            ddlSex.SelectedValue = user2.Sex.SexId;
        }
    }
    protected void ddlProvine_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropDownList(ddlDistrict, GetAllDistrictInProvince(ddlProvine.SelectedValue), "DistrictName", "DistrictID");
    }
    protected void btnUserInfoSubmit_OnClick(object sender, EventArgs e)
    {

        try
        {
            var name = txtName.Text.Split(' ');
            var lastname = name[0];
            var firstname = name[1];
            var birthDay = Convert.ToDateTime(txtDateOfBirth.Text);
            var sex = new Sex(ddlSex.SelectedValue, ddlSex.SelectedItem.Text);
            var phoneNumber = txtPhoneNumber.Text;
            var job = new JobIndustries(ddlJob.SelectedValue, ddlJob.SelectedItem.Text);
            var province = new Province(ddlProvine.SelectedValue, ddlProvine.SelectedItem.Text);
            var district = new District(ddlDistrict.SelectedValue, ddlDistrict.SelectedItem.Text, province);
            var address = new Address(province, district);
            var race = new Races(ddRaces.SelectedValue, ddRaces.SelectedItem.Text);
            var maximOfLife = txtMaxim.Text;
            var photoPath = "";
            if (this.fuResume.HasFile)
            {
                string imgThumb = "E:\\DOCUMENTS\\School\\ASP.NETWorkSpaces\\WebFindingJobsMVCmodel\\Images\\" + this.fuResume.FileName;
                this.fuResume.SaveAs(imgThumb);
                photoPath = "/Images/" + this.fuResume.FileName;
            }
            User1 = (User)Session["User"];
            var returnValue = User1.SetFullInfo(firstname, lastname, birthDay, sex, phoneNumber, job, address, race, maximOfLife, photoPath);
            SetExistInfo();

            if (returnValue)
            {
                Session["User"] = User1;
                SetExistInfo();
                JavaScriptAleart("Thực hiện thành công");
            }
            else
            {
                JavaScriptAleart("Chỉnh sửa không thành công. Vui lòng load lại trang và thử lại");
            }
        }
        catch (Exception exception)
        {
            Response.Write(exception.ToString());
            JavaScriptAleart("Chỉnh sửa không thành công. Vui lòng load lại trang và thử lại");
        }

    }


    protected void btnInfoCancel_OnClick(object sender, EventArgs e)
    {
        User1 = (User)Session["User"];
        SetExistInfo();
    }
}