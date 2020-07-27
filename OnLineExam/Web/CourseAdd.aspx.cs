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
using OnLineExamModel;
using OnLineExamBLL;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "添加考试科目";

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
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        Course course = new Course();
        course.DepartmentName = txtName.Text;
        course.Examtime = int.Parse(txtExamTime.Text)*60;//以分钟为单位，前台js是以秒为单位
        if (CourseManager.courseInsert(course))
        {
            lblMessage.Text = "添加成功！";
            txtName.Text = string.Empty;
            txtExamTime.Text = string.Empty;
        }
        else
        {
            lblMessage.Text = "添加失败！";
        }
    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CourseManage.aspx");
    }
}
