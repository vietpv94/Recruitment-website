using System;
using Controllers;
using Models.Objects;

public partial class InfoModify : JobsController
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
    }

    public void SetExistInfo()
    {
        User1 = (User)Session["User"];
        if (User1 == null)
        {
            Session["Login"] = null;
            Session["User"] = null;
            Response.Redirect("Login.aspx");
        }
        else
        {
            User1.SetFullInfo();
            Session["User"] = User1;
            txtName.Text = User1.LastName + " " + User1.FirstName;
            txtDateOfBirth.Text = Convert.ToDateTime(User1.DateBirthDay).ToString("MM/dd/yyyy");
            txtPhoneNumber.Text = User1.PhoneNumber;
            txtMaxim.Text = User1.MaximOfLife;
            ThumbImg = User1.ThumImg;

            BindDropDownList(ddlProvine, GetAllProvine(), "ProvinceName", "ProvinceID");
            ddlProvine.SelectedValue = User1.Address.Province.Id;

            BindDropDownList(ddlDistrict, GetAllDistrictInProvince(User1.Address.Province.Id), "DistrictName", "DistrictID");
            ddlDistrict.SelectedValue = User1.Address.District.Id;

            BindDropDownList(ddRaces, GetAllRaces(), "RaceName", "RaceID");
            ddRaces.SelectedValue = User1.Races.RaceId;

            BindDropDownList(ddlJob, GetAllJobs(), "JobIndustryName", "JobIndustryID");
            ddlJob.SelectedValue = User1.JobIndustries.JobIndutriesId;

            BindDropDownList(ddlSex, GetAllSexs(), "SexName", "SexID");
            ddlSex.SelectedValue = User1.Sex.SexId;
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
            var job = new JobIndustries(ddlJob.SelectedValue,ddlJob.SelectedItem.Text);
            var province = new Province(ddlProvine.SelectedValue,ddlProvine.SelectedItem.Text);
            var district = new District(ddlDistrict.SelectedValue,ddlDistrict.SelectedItem.Text, province);
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
            var returnValue = User1.SetFullInfo(firstname, lastname, birthDay, sex, phoneNumber, job, address, race, maximOfLife,photoPath);
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