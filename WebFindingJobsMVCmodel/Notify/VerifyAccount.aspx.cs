using System;
using System.Data;

using System.Web.UI.HtmlControls;
using Controllers;
using Models.DAO;
using Models.Objects;

namespace Notify
{
    public partial class PagesVerifyAccount : LoginControllers
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
           LoadDatas();
        }
        private void LoadDatas()
        {
            try
            {
                const string protocol = "http://";
                if (Request["code"] == null)
                    Response.Redirect(protocol + Request.Url.Host);
                var username = Request["UserName"];
                var verifyCode = Request["code"];
                var dao = new DaoLogin();
                DataSet dataSet = !username.Equals("active") ? dao.VerifyInfo(verifyCode) : dao.VerifyRecruitorInfo(verifyCode);
               
                var oResult = dataSet.Tables[0].Rows[0][0].ToString();
                if (oResult.Equals("INVALID_VERIFY_CODE"))
                {
                    alertText.InnerHtml = "Mã kích hoạt không chính xác.";
                }
                else if (oResult.Equals("ACTIVATED"))
                {
                    alertText.InnerHtml = "Tài khoản này đã được kích hoạt trước đó, bạn không thể kích hoạt 2 lần.";
                }
                else
                {
                    
                    var dataMember = dataSet.Tables[1];
                    int type = Convert.ToInt32(dataMember.Rows[0]["TypeUser"]);
                    var s = "";
                    if (type==1)
                    {
                        Session["User"] = new User(dataMember.Rows[0]["EmailLogin"].ToString(), dataMember.Rows[0]["UserID"].ToString(), username);
                        Session["Login"] = new Login(dataMember.Rows[0]["EmailLogin"].ToString(), dataMember.Rows[0]["PassWordLogin"].ToString());
                        s = "3;url=" + protocol + Request.Url.Host + ":" + Request.Url.Port + "/Home.aspx";
                    }
                    else
                    {
                        Session["Recruitor"] = new Recruitor(dataMember.Rows[0]["RecruitorID"].ToString());
                        Session["Login"] = new Login(dataMember.Rows[0]["EmailLoginAsRecruitor"].ToString(), dataMember.Rows[0]["Password"].ToString());
                        s = "3;url=" + protocol + Request.Url.Host + ":" + Request.Url.Port + "/Recruiters.aspx";
                    }
                    
                    alertText.InnerHtml = "Chúc mừng bạn đã kích hoạt tài khoản thành công! Website sẽ chuyển hướng về trang chủ sau 3 giây!";
                    
                    HtmlMeta meta = new HtmlMeta();
                    meta.HttpEquiv = "Refresh";
                    meta.Content =s ;
                    Page.Controls.Add(meta);   
                }
            }
            catch (Exception exception)
            {
                Console.Write(exception);
            }
        }
        }
}