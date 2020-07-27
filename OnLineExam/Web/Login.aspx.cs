using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OnLineExamModel;
using OnLineExamBLL;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.txtUserID.Focus();
        if (!IsPostBack)
        {
            try
            {
                HttpCookie readcookie = Request.Cookies["UsersID"];
                this.txtUserID.Text = readcookie.Value;
            }
            catch (Exception)
            {
                this.txtUserID.Text = string.Empty;
            }
        }
    }
    protected void imgBtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        //string usersId = txtUserID.Text.Trim();
        //string pwdMd5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtPwd.Text.Trim(), "MD5").ToString();

        //Users u = new Users();
        //u.UserID = usersId;
        //u.UserPwd = pwdMd5;

        //bool success = UserManager.Login(ref u);
        //if (success)
        //{
        //    if (u.UserPwd == pwdMd5)//输入密码与用户密码相同
        //    {
        //        if (this.cbxRemeberUser.Checked)
        //        {
        //            if (object.Equals(Request.Cookies["UsersID"], null))
        //            {
        //                CreateCookie();
        //            }
        //            else
        //            {
        //                CreateCookie();
        //            }
        //        }
        //        Session["userID"] = txtUserID.Text.Trim();//存储用户编号
        //        Response.Redirect("Default.aspx");//转向管理员操作界面                      
        //    }
        //    else//密码错误，给出提示
        //    {
        //        lblMessage.Text = "您输入的密码错误！";
        //    }
        //}
        //else//用户不存在，给出提示
        //{
        //    lblMessage.Text = "该用户不存在或密码不正确！";
        //}
    }
    
    private void CreateCookie()
    {
        HttpCookie cookie = new HttpCookie("UsersID");
        if (this.cbxRemeberUser.Checked)
        {
            cookie.Value = txtUserID.Text;
        }
        cookie.Expires = DateTime.MaxValue;
        Response.AppendCookie(cookie);
    }
    protected void imgBtnLogin_Click1(object sender, EventArgs e)
    {
        string usersId = txtUserID.Text.Trim();
        string pwdMd5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtPwd.Text.Trim(), "MD5").ToString();

        Users u = new Users();
        u.UserID = usersId;
        u.UserPwd = pwdMd5;


        //新代码
        Logined lg = new Logined();
        lg = UserManager.Logined(ref u);
        if (lg.login_status)
        {
            if (this.cbxRemeberUser.Checked)
            {
                if (object.Equals(Request.Cookies["UsersID"], null))
                {
                    CreateCookie();
                }
                else
                {
                    CreateCookie();
                }
            }
            Session["userID"] = txtUserID.Text.Trim();//存储用户编号
            Response.Redirect("Default.aspx");//转向管理员操作界面   
        }
        else
        {
            lblMessage.Text = lg.login_errstr;
        }


        //bool success = UserManager.Login(ref u);
        //if (success)
        //{
        //    //如果成功

        //    if (u.UserPwd == pwdMd5)//输入密码与用户密码相同
        //    {
        //        if (this.cbxRemeberUser.Checked)
        //        {
        //            if (object.Equals(Request.Cookies["UsersID"], null))
        //            {
        //                CreateCookie();
        //            }
        //            else
        //            {
        //                CreateCookie();
        //            }
        //        }
        //        Session["userID"] = txtUserID.Text.Trim();//存储用户编号
        //        Response.Redirect("Default.aspx");//转向管理员操作界面                      
        //    }
        //    else//密码错误，给出提示
        //    {
        //        lblMessage.Text = "您输入的密码错误！";
        //    }
        //}
        //else//用户不存在，给出提示
        //{
        //    lblMessage.Text = "该用户不存在或密码不正确！";
        //}
    }
}
