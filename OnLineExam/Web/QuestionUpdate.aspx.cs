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
using System.Data.SqlClient;
using OnLineExamBLL;
using OnLineExamDAL;
using System.Collections.Generic;

public partial class Web_QuestionUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "修改试题";



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
                int SingID = int.Parse(Request["ID"].ToString());
                string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "select * from QuestionProblem where ID=" + SingID;
                    conn.Open();
                    SqlDataReader DR = cmd.ExecuteReader();
                    if (DR.Read())
                    {
                        ddlCourse.SelectedValue = DR["CourseID"].ToString();
                        txtTitle.Text = DR["Title"].ToString();
                        txtAnswer.Text = DR["Answer"].ToString();
                    }
                    DR.Close();
                    conn.Close();

                }
            }
        }
    }
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        QuestionProblem pro = new QuestionProblem();
        pro.ID = int.Parse(Request["ID"].ToString());
        pro.CourseID = Convert.ToInt32(ddlCourse.SelectedValue);
        pro.Title = txtTitle.Text;
        pro.Answer = txtAnswer.Text;
        if (QuestionProblemManager.QuestionProblemUpdate(pro))
        {
            lblMessage.Text = "修改成功！";
            txtTitle.Text = string.Empty;
            txtAnswer.Text = string.Empty;
        }
        else
        {
            lblMessage.Text = "修改失败！";
        }
    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("QuestionManage.aspx");
    }
}
