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

public partial class Web_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RedirectPage();
        //
    }
    private void RedirectPage()
    {
        if (Session["userID"] == null)
            Response.Redirect("Login.aspx");

        Role user = new Role();
        string userId = Session["userID"].ToString();
        user.RoleName = RoleManager.GetRoleName(userId);
        switch (user.RoleName)
        {
            case "管理员":
                Response.Redirect("UserManage.aspx");
                break;
            case "考官":
                Response.Redirect("UserManage.aspx");
                break;
            case "考生":
                Response.Redirect("StudentIndex2.aspx");
                break;
            default:
                break;
        }
    }
}
