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
using OnLineExamDAL;

public partial class Web_Role : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "角色管理";
        if (!IsPostBack)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string userId = Session["userID"].ToString();
                string userName = UserManager.GetUserName(userId);
                Label i1 = (Label)Page.Master.FindControl("labUser");
                i1.Text = userName;

                GridView1.DataSource = RoleManager.SelectRoles();
                GridView1.DataBind();
            }
        }

    }

    //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    string RoleID = "";

    //    for (int i = 0; i < this.GridView1.Rows.Count; i++)
    //    {
    //        bool isChecked = ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked;
    //        if (isChecked)
    //        {
    //            RoleID = ((Label)GridView1.Rows[0].FindControl("Label1")).Text;
    //        }
    //    }
    //    if (RoleService.Delect(RoleID))
    //    {
    //        Response.Write("<script language=javascript>alert('删除成功!')</script>");
    //    }
    //    else
    //    {
    //        Response.Write("<script language=javascript>alert('" + RoleID + "删除失败!')</script>");
    //    }
    //    GridView1.DataSource = RoleManager.SelectRoles();
    //    GridView1.DataBind();
    //}

    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        GridView1.DataSource = RoleManager.SelectRoles();
        GridView1.DataBind();
    }
    //protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    //{
    //    for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
    //    {
    //        ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked = RadioButton1.Checked;
    //    }
    //}
    //protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    //{
    //    for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
    //    {
    //        if (((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked == true)
    //        {
    //            ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked = false;
    //        }
    //        else
    //        {
    //            ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked = true;
    //        }
    //    }
    //}
    //protected void ImageButtonDelete_Click(object sender, ImageClickEventArgs e)
    //{
    //    string RoleID = "";
    //    for (int i = 0; i < this.GridView1.Rows.Count; i++)
    //    {
    //        bool isChecked = ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked;
    //        if (isChecked)
    //        {
    //            RoleID = ((Label)GridView1.Rows[i].FindControl("Label1")).Text;
    //        }
    //    }
    //    if ((RoleService.Delect(RoleID))&&(RoleID!=""))//根据主键使用delScores方法删除用户
    //    {
    //        Response.Write("<script language=javascript>alert('删除成功!')</script>");
    //    }
    //    else
    //    {
    //        Response.Write("<script language=javascript>alert('删除失败!')</script>");
    //    }        

    //    GridView1.DataSource = RoleManager.SelectRoles();
    //    GridView1.DataBind();
    //}
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#cbe2fa'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }
}
