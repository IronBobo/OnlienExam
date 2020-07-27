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

public partial class Web_MultiSelectUpdate : System.Web.UI.Page
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


                //展示绑定的数据并将它展示在下拉列表中
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
                    cmd.CommandText = "Select * from MultiProblem where ID=" + SingleID;
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
                        txtAnswerE.Text = DR["AnswerE"].ToString();
                        txtAnswerF.Text = DR["AnswerF"].ToString();
                        //把从数据库中查到的值在界面上相应的钩选上
                        string answer = DR["Answer"].ToString();
                        foreach (ListItem item in cblAnswer.Items)
                        {
                            foreach (char c in answer)
                            {
                                if (item.Value == c.ToString())
                                {
                                    item.Selected = true;
                                }
                            }
                        }

                    }

                    DR.Close();
                    conn.Close();
                }
            }
        }
    }
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        MultiProblem pro = new MultiProblem();
        pro.ID = int.Parse(Request["ID"].ToString());
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
        if (MultiProblemManager.multiProblemUpdate(pro))
        {
            lblMessage.Text = "修改成功！";
        }
        else
        {
            lblMessage.Text = "修改失败！";
        }

    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MultiSelectManage.aspx");
    }
}
