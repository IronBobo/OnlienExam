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
using System.Collections.Generic;

public partial class Web_QuestionAnalyse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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

            Panel1.Visible = true;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
    }
}
