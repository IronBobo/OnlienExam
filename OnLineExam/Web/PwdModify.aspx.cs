using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OnLineExamBLL;

public partial class Web_PwdModify1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "修改密码";
        if (!Page.IsPostBack)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string userId = Session["userID"].ToString();
                string userName = UserManager.GetUserName(userId);
                Label i = (Label)Page.Master.FindControl("labUser");
                i.Text = userName;
            }
        }
    }
    protected void imgBtnModifyPwd_Click1(object sender, ImageClickEventArgs e)
    {
        string userId = Session["userID"].ToString();
        string newPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtNewPwd.Text.Trim(), "MD5").ToString();
        string pwdMd5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtOldPwd.Text.Trim(), "MD5").ToString();
        if (UserManager.GetSelectPwd(pwdMd5))
        {
           
            UserManager.ModifyPwd(newPwd, userId);
            lblMessage.Text = "修改成功！";
            this.txtOldPwd.Text = string.Empty;
        }
        else
        {
            lblMessage.Text = "原密码不正确！";
        }
    }
    protected void imgBtnReset_Click(object sender, ImageClickEventArgs e)
    {
        txtOldPwd.Text = txtNewPwd.Text = txtConfirmPwd.Text = "";
        lblMessage.Text = "";
    }
}
