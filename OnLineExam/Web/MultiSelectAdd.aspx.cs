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
using System.Collections.Generic;
using OnLineExamModel;
using OnLineExamDAL;
using OnLineExamBLL;

public partial class Web_MultiSelectAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "增加试题";
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


                //展示绑定的数据并将它展示在下拉列表中
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
        MultiProblem pro = new MultiProblem();
        pro.CourseID = Convert.ToInt32(ddlCourse.SelectedValue);
        pro.Title = txtTitle.Text;
        pro.AnswerA = txtAnswerA.Text;
        pro.AnswerB = txtAnswerB.Text;
        pro.AnswerC = txtAnswerC.Text;
        pro.AnswerD = txtAnswerD.Text;
        pro.AnswerE = txtAnswerE.Text;
        pro.AnswerF = txtAnswerF.Text;

        for (int i = 0; i < cblAnswer.Items.Count; i++)
        {
            if (cblAnswer.Items[i].Selected)
            {
                pro.Answer += cblAnswer.Items[i].Text;

            }
        }

        if (MultiProblemManager.multiProblemInsert(pro))
        {
            lblMessage.Text = "添加成功！";
            txtTitle.Text = string.Empty;
            txtAnswerA.Text = string.Empty;
            txtAnswerB.Text = string.Empty;
            txtAnswerC.Text = string.Empty;
            txtAnswerD.Text = string.Empty;
            txtAnswerE.Text = string.Empty;
            txtAnswerF.Text = string.Empty;
            cblAnswer.ClearSelection();
        }
        else
        {
            lblMessage.Text = "添加失败！";
        }
    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MultiSelectManage.aspx");
    }
}
