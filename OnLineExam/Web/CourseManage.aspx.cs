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
using System.Data.SqlClient;

public partial class Web_CourseManage1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "考试科目管理";
       
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


                if (!RoleManager.IsHasDuty(userName, "HasDuty_PaperSetup"))
                {
                    Response.Redirect("noDuty.aspx");
                }
                else
                {
                    GridView1.DataSource = CourseManager.GetSelect();
                    GridView1.DataKeyNames = new string[] { "DepartmentId" };
                    GridView1.DataBind();
                }
            }
        }
    }

    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Separator)
        {
            Label label1 = e.Row.FindControl("Label1") as Label;
            label1.Text = (e.Row.RowIndex + 1).ToString();
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#cbe2fa'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }
    protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        Course c = new Course();
        c.DepartmentId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        try
        {
            CourseManager.GetDeleteCourse(c);
            lblMessger.Text = "删除成功！";
        }
        catch (Exception)
        {
            Response.Redirect("CourseManage.aspx");
        }

    }
}
