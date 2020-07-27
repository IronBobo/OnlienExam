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


public partial class Web_UserPaperList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "试卷评阅";
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
                Label i = (Label)Page.Master.FindControl("labUser");
                i.Text = userName;

                if (!RoleManager.IsHasDuty(userName, "HasDuty_UserPaperList"))
                {
                    Response.Redirect("noDuty.aspx");
                }
                //GridView1.DataSource = UserManager.GetselectUserPaperList();
                //GridView1.DataBind();
            }
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string UserID = GridView1.DataKeys[e.RowIndex].Values[0].ToString(); //取出要删除记录的主键值1
        int PaperID = int.Parse(GridView1.DataKeys[e.RowIndex].Values[1].ToString().Trim());//取出要删除记录的主键值2
        UserManager.DeleteUserPaperList(UserID, PaperID);
        //GridView1.DataSource = UserManager.GetselectUserPaperList();
        //GridView1.DataBind();
        Response.Redirect("./UserPaperList.aspx");
        LabelPageInfo.Text = "删除成功！";
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
}
