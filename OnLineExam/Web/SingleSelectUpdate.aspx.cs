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
using System.Data.SqlClient;
using OnLineExamBLL;

public partial class Web_SingleSelectUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "修改试题";
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

                //根据ID展示相应的值
                int SingleID = int.Parse(Request["ID"].ToString());
                string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Select * from SingleProblem where ID=" + SingleID;
                    conn.Open();
                    SqlDataReader DR = cmd.ExecuteReader();

                    if (DR.Read())
                    {
                        ddlCourse.SelectedValue = DR["CourseID"].ToString();
                        txtTitle.Text = DR["Title"].ToString();
                        txtAnswerA.Text = DR["AnswerA"].ToString();
                        txtAnswerB.Text = DR["AnswerB"].ToString();
                        txtAnswerC.Text = DR["AnswerC"].ToString();
                        txtAnswerD.Text = DR["AnswerD"].ToString();
                        ddlAnswer.SelectedValue = DR["Answer"].ToString();
                    }
                    DR.Close();
                    conn.Close();

                }
            }
        }
    }
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        SingleProblem singleProble = new SingleProblem();
        singleProble.ID = int.Parse(Request["ID"].ToString());
        singleProble.CourseID = Convert.ToInt32(ddlCourse.SelectedValue);
        singleProble.Title = txtTitle.Text;
        singleProble.AnswerA = txtAnswerA.Text;
        singleProble.AnswerB = txtAnswerB.Text;
        singleProble.AnswerC = txtAnswerC.Text;
        singleProble.AnswerD = txtAnswerD.Text;
        singleProble.Answer = ddlAnswer.SelectedValue;
        if (SingleSelectedManager.UpdateSingleSelected(singleProble))
        {
            lblMessage.Text = "修改成功!";
            txtTitle.Text = string.Empty;
            txtAnswerA.Text = string.Empty;
            txtAnswerB.Text = string.Empty;
            txtAnswerC.Text = string.Empty;
            txtAnswerD.Text = string.Empty;
        }
        else
        {
            lblMessage.Text = "修改失败!";
        }

    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SingleSelectManage.aspx");
    }
}
