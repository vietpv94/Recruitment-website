using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Base
{
    /// <summary>
    /// Summary description for CoreBase
    /// </summary>
    /// class này chứa những nghiệp vụ cơ bản, thường xuyên được sử dụng tại code behind của các trang aspx
    /// abstract class ngăn không cho tạo thể hiện của lớp
public abstract class CoreBase:Page
{

	public CoreBase()
	{
		//
		// TODO: Add constructor logic here
		//
	}
 
    protected bool ValidateDate(string stringDateValue)
    {
        try
        {
            var cultureInfoDateCulture = new CultureInfo("vi-VN");
            DateTime d = DateTime.ParseExact(stringDateValue, "dd/MM/yyyy", cultureInfoDateCulture);
            return true;
        }
        catch
        {
            return false;
        }
    }
    protected void JavaScriptAleart(string aleartStr)
    {
        Response.Write("<script>alert('" + aleartStr + "');</script>");
    }
    protected void BindRepeater(Repeater repeater, DataTable dtData)
    {
        try
        {
            if (dtData != null && dtData.Rows.Count > 0)
            {
                repeater.Visible = true;
                repeater.DataSource = dtData;
                repeater.DataBind();
            }
            else
            {
                repeater.Visible = true;
                repeater.DataSource = new DataTable();
                repeater.DataBind();
            }
        }
        catch (Exception ex)
        {
            JavaScriptAleart(ex.Message);
        }
    }
    protected void BindDropDownList(DropDownList dropDownList, DataTable dataTable, string textField, string valueField)
    {
        try
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                dropDownList.Items.Clear();
                dropDownList.DataSource = dataTable;
                dropDownList.DataTextField = textField;
                dropDownList.DataValueField = valueField;
                dropDownList.DataBind();
            }
        }
        catch (Exception ex)
        {
            JavaScriptAleart(ex.Message);
        }
    }
    protected void BindDropDownList(DropDownList dropDownList, DataTable dataTable, string textField,
       string valueField, string defaultValue)
    {
        try
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                dropDownList.Items.Clear();
                dropDownList.Items.Add(new ListItem(defaultValue, "0"));
                dropDownList.DataSource = dataTable;
                dropDownList.DataTextField = textField;
                dropDownList.DataValueField = valueField;
                dropDownList.DataBind();
            }
        }
        catch (Exception ex)
        {
            JavaScriptAleart(ex.Message);
        }
    }

    #region Binding data to CheckBoxList control

    protected void BindCheckBoxList(CheckBoxList cCheckBoxList, DataTable dtData, string text, string value)
    {
        if (dtData != null && dtData.Rows.Count > 0)
        {
            cCheckBoxList.DataSource = dtData;
            cCheckBoxList.DataTextField = text;
            cCheckBoxList.DataValueField = value;
            cCheckBoxList.DataBind();
        }
        else
            cCheckBoxList.Visible = true;
        //cCheckBoxList.Visible = false;
    }

    protected void BindCheckBoxList(CheckBoxList cbl, DataTable dtData, string text, string value, string contentType)
    {
        if (String.IsNullOrEmpty(contentType))
            BindCheckBoxList(cbl, dtData, text, value);
        else
        {
            if (dtData != null && dtData.Rows.Count > 0)
            {
                foreach (DataRow row in dtData.Rows)
                {
                    var viewItemUrl = "/AdminCP/SortingModuleItems.aspx?moduleId=" + row[value] + "&type=" + contentType;
                    var viewItemTag = "<a href=\"javascript:OpenPopup('" + viewItemUrl + "')\">&nbsp;<img src='/AdminCP/resources/images/icons/16x16/icon-edit-16x16.png' atl='sửa' /></a>";
                    var item = new ListItem();
                    item.Text = row[text] + viewItemTag;
                    item.Value = row[value].ToString();

                    cbl.Items.Add(item);
                }
            }
            else
                cbl.Visible = true;
        }
    }

    protected void BindCheckBoxList(CheckBoxList cCheckBoxList, DataTable dtData, string text, string value, int spaceCount)
    {
        try
        {
            if (dtData != null && dtData.Rows.Count > 0)
            {
                if (spaceCount != 0)
                    dtData = DecodeSpaceDataTable(dtData, text, value, spaceCount);
                BindCheckBoxList(cCheckBoxList, dtData, text, value);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    #endregion
    protected DataTable DecodeSpaceDataTable(DataTable dataTable, string text, string value, int spaceCount)
    {
        foreach (DataRow row in dataTable.Rows)
        {
            const string space = " ";
            var spaceHtml = Server.HtmlDecode("&nbsp;");

            var spaceBuilder = new StringBuilder(spaceCount);
            var spaceHtmlBuilder = new StringBuilder(spaceCount);
            var splitChar = "└----";

            for (var index = 1; index < spaceCount; index++)
            {
                spaceBuilder.Append(space);
                spaceHtmlBuilder.Append(spaceHtml);
            }

            var allSpaces = spaceBuilder.ToString();
            var allHtmlSpaces = spaceHtmlBuilder.ToString();

            var outputText = row[text].ToString();

            if (!outputText.StartsWith(allSpaces)) continue;

            dataTable.Columns[text].ReadOnly = false;

            row[text] = allHtmlSpaces + splitChar + outputText;

            if (outputText.StartsWith(allSpaces + allSpaces))
            {
                row[text] = allHtmlSpaces + allHtmlSpaces + splitChar + outputText;
            }

            if (outputText.StartsWith(allSpaces + allSpaces + allSpaces))
            {
                row[text] = allHtmlSpaces + allHtmlSpaces + allHtmlSpaces + splitChar + outputText;
            }

            if (outputText.StartsWith(allSpaces + allSpaces + allSpaces + allSpaces))
            {
                row[text] = allHtmlSpaces + allHtmlSpaces + allHtmlSpaces + allHtmlSpaces + splitChar + outputText;
            }
        }

        return dataTable;
    }
    #region Set active link

    protected void SetActive(WebControl activeLink, string activeClass, IEnumerable<LinkButton> unactiveLinks)
    {
        foreach (var link in unactiveLinks)
            link.CssClass = "";

        activeLink.CssClass = activeClass;
    }

    #endregion
    
    #region stringUltils
    private static readonly string[] VietnameseSigns = new string[]

    {

        "aAeEoOuUiIdDyY",

        "áàạảãâấầậẩẫăắằặẳẵ",

        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

        "éèẹẻẽêếềệểễ",

        "ÉÈẸẺẼÊẾỀỆỂỄ",

        "óòọỏõôốồộổỗơớờợởỡ",

        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

        "úùụủũưứừựửữ",

        "ÚÙỤỦŨƯỨỪỰỬỮ",

        "íìịỉĩ",

        "ÍÌỊỈĨ",

        "đ",

        "Đ",

        "ýỳỵỷỹ",

        "ÝỲỴỶỸ"

    };



    public string RemoveSign4VietnameseString(string str)
    {

        //Tiến hành thay thế , lọc bỏ dấu cho chuỗi

        for (int i = 1; i < VietnameseSigns.Length; i++)
        {

            for (int j = 0; j < VietnameseSigns[i].Length; j++)

                str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);

        }

        return str;

    }

    #endregion
}
}