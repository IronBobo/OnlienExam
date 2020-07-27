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
using OnLineExamModel;
using OnLineExamDAL;

public partial class Web_UserManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "用户管理";
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

                if (!RoleManager.IsHasDuty(userName, "HasDuty_UserManage"))
                {
                    Response.Redirect("noDuty.aspx");
                }
                else
                {
                    //GridView1.DataSource = UserManager.listuser();
                    //GridView1.DataBind();
                }
            }
        }
    }

    protected void ImageButtonQuery_Click(object sender, ImageClickEventArgs e)
    {
       
    }
    protected void ImageButtonBack_Click(object sender, ImageClickEventArgs e)
    {
       
    }

    protected void ImageButtonResetPassword_Click(object sender, ImageClickEventArgs e)
    {
       
    }
    protected void ImageButtonDelete_Click(object sender, ImageClickEventArgs e)
    {
        
    }

    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked = RadioButton1.Checked;
        }
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            if (((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked == true)
            {
                ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked = false;
            }
            else
            {
                ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked = true;
            }
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#cbe2fa'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }
    protected void ButtonQuery_Click(object sender, EventArgs e)
    {
        string userID = tbxUserID.Text;
        string userName = tbxUserName.Text;
        if (userID == "" && userName == "")
        {
            Response.Write("<script language=javascript>alert('查询条件不能都为空！!')</script>");
        }
        else
        {
            if (userID != "")
            {
                GridView1.DataSource = UserManager.seluser(userID);
                GridView1.DataBind();
                tbxUserID.Text = "";
                tbxUserName.Text = "";
            }
            else
            {
                GridView1.DataSource = UserManager.seluserName(userName);
                GridView1.DataBind();
                tbxUserID.Text = "";
                tbxUserName.Text = "";
            }
        }
    }
    protected void ButtonBack_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = UserManager.listuser();
        GridView1.DataBind();
    }
    protected void ButtonResetPassword_Click(object sender, EventArgs e)
    {
        int numOfChecked = 0;
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            bool isChecked = ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked;
            if (isChecked)
            {
                numOfChecked++;
            }
        }
        if (numOfChecked == 1)
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                bool isChecked = ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked;
                if (isChecked)
                {
                    string UserID = ((Label)GridView1.Rows[i].FindControl("Label1")).Text;

                    Random ran = new Random();
                    string newPassword = (ran.Next(999999).ToString().PadLeft(6, '8'));	//随机生成一个密码

                    Users user = new Users();//创建Users对象user
                    string pwdMd5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newPassword, "MD5").ToString();
                    user.UserPwd = pwdMd5.ToString().Trim();
                    if (UserService.Update1(pwdMd5, UserID))//更改用户密码
                    {
                        Response.Write("<Script language=JavaScript>alert('" + UserID + "的密码已经重置，新密码为【" + newPassword + "】。');</Script>");
                    }
                    else//修改密码失败
                    {
                        Response.Write("<Script language=JavaScript>alert('" + UserID + "重置密码失败!');</Script>");
                    }
                }
            }

        }
        else
        {
            Response.Write("<Script language=JavaScript>alert('您只能选择一个用户!');</Script>");
            return;
        }
    }
    protected void ButtonDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            bool isChecked = ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked;
            if (isChecked)
            {
                string userID = ((Label)GridView1.Rows[i].FindControl("Label1")).Text;
                Users user = new Users();//创建Users类对象user
                if (UserService.delUserId(userID))//根据主键使用DeleteByProc方法删除用户
                {
                    Response.Write("<script language=javascript>alert('删除成功!')</script>");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('" + userID + "删除失败!')</script>");
                }

            }
        }


       // GridView1.DataSource = UserManager.listuser();
        //GridView1.DataSource = SqlDataSource1;
        GridView1.DataSourceID = SqlDataSource1.ID;
        
    }
}
