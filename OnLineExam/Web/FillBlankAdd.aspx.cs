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
using System.Collections.Generic;
using OnLineExamDAL;
using OnLineExamBLL;

public partial class Web_FillBlankAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "增加试题";
        //展示绑定的数据并将它展示在下拉列表中
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


                ddlCourse.Items.Clear();
                Course course = new Course();
                List<Course> list = SingleSelectedService.ListCourse();

                for (int i = 0; i < list.Count; i++)
                {
                    ListItem item = new ListItem(list[i].DepartmentName.ToString(), list[i].DepartmentId.ToString());
                    ddlCourse.Items.Add(item);
                }
            }
        }
    }
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        FillBlankProblem param = new FillBlankProblem();
        param.CourseID = Convert.ToInt32(ddlCourse.SelectedValue);
        param.FrontTitle = txtFrontTitle.Text;
        param.BackTitle = txtBackTitle.Text;
        param.Answer = txtAnswer.Text;
        if (FillBlankProblemManager.FillBlankProblemInsert(param))
        {
            lblMessage.Text = "添加成功！";
            txtFrontTitle.Text = string.Empty;
            txtBackTitle.Text = string.Empty;
            txtAnswer.Text = string.Empty;
        }
        else
        {
            lblMessage.Text = "添加失败！";
        }
    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("FillBlankManage.aspx");
    }
}
