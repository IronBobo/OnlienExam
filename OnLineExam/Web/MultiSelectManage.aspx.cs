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

public partial class Web_MultiSelectManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "多选题管理";
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

                if (!RoleManager.IsHasDuty(userName, "HasDuty_TypeManage"))
                {
                    Response.Redirect("noDuty.aspx");
                }
                else
                {
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

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GridView1.DataSourceID = null;
        string selectvalue = this.ddlCourse.SelectedValue;
        this.GridView1.DataSource = MultiProblemManager.GetMultiProblemList(selectvalue);
        this.GridView1.DataBind();
    }
}
