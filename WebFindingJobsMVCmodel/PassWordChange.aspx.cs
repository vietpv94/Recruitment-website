using System;
using System.Security.Cryptography;
using System.Text;
using Base;
using Models.Objects;

public partial class PassWordChange : CoreBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        try
        {
            var login = (Models.Objects.Login)Session["Login"];
            
            if (login != null)
            {
                login.GetFullInfo();
                var currentPass = Encrypt(txtCurentPass.Text);
                if (currentPass.Equals(login.Password))
                {
                    if (txtConfirmPass.Text.Equals(txtNewPass.Text))
                    {
                       var isChange= login.ChangePassWord(txtNewPass.Text);
                        if (isChange)
                        {
                            JavaScriptAleart("Thay đổi thành công");
                        }
                        else
                        {
                            JavaScriptAleart("Có lỗi xảy ra. Vui lòng đăng nhập lại và thử lại");
                            ClearForm();
                        }
                    }
                    else
                    {
                        JavaScriptAleart("Nhập lại mật khẩu không khớp");
                        ClearForm();
                    }
                }
                else
                {
                    JavaScriptAleart("Mật khẩu hiện tại không chính xác");
                    ClearForm();
                }
            }
            else
            {
                JavaScriptAleart("Có lỗi xảy ra. Vui lòng đăng nhập lại và thử lại");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
            JavaScriptAleart("Có lỗi xảy ra. Vui lòng đăng nhập lại và thử lại");
            ClearForm();
        }
    }
    private void ClearForm()
    {
        txtCurentPass.Text = "";
        txtNewPass.Text = "";
        txtConfirmPass.Text = "";
    }

    private string Encrypt(string str)
    {
        var algorithmType = default(HashAlgorithm);
        var enCoder = new ASCIIEncoding();
        byte[] valueByteArr = enCoder.GetBytes(str);
        byte[] hashArray = null;

        // Encrypt Input string 
        algorithmType = new MD5CryptoServiceProvider();
        hashArray = algorithmType.ComputeHash(valueByteArr);

        //  return hashArray.Aggregate("", (current, b) => current + string.Format("{0:x2}", b));
        //Convert byte hash to HEX
        var sb = new StringBuilder();
        foreach (byte b in hashArray)
        {
            sb.AppendFormat("{0:X2}", b);
        }
        return sb.ToString();
    }
}