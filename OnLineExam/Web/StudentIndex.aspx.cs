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
using OnLineExamDAL;

public partial class Web_StudentIndex : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                InitData();
                string userId = Session["userID"].ToString();
                string userName = UserManager.GetUserName(userId);
                labUser.Text = userId;
                lblName.Text = userName;
                GridView1.DataSource = UserManager.GetselectExaminfo(userId);
                GridView1.DataBind();
            }
        }
    }

    private void InitData()
    {
        DataSet ds = PaperManager.QueryPaper();  //查询所有可用试卷
        if (ds.Tables[0].Rows.Count >= 1)
        {
            ddlPaper.DataSource = ds;           //指名考试科目列表框数据源
            ddlPaper.DataTextField = "PaperName";   //DataTextField显示Name字段值
            ddlPaper.DataValueField = "PaperID";    //DataValueField显示ID字段值
            ddlPaper.DataBind();                //绑定数据

        }
        else
        {
            ddlPaper.Enabled = false;
            Button1.Enabled = false;
            lblMessage.Text = "没有试卷！";
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#cbe2fa'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }
    protected void imgBtnModifyPwd_Click1(object sender, ImageClickEventArgs e)
    {
        string userId = Session["userID"].ToString();
        string newPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtNewPwd.Text.Trim(), "MD5").ToString();
        string pwdMd5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtOldPwd.Text.Trim(), "MD5").ToString();
        if (UserManager.GetSelectPwd(pwdMd5))
        {
            UserManager.ModifyPwd(newPwd, userId);
            this.lblPwd.Text = "修改成功！";
        }
        else
        {
            this.lblPwd.Text = "原密码不正确！";
        }
    }
    protected void imgBtnReset_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string UserID = Session["userID"].ToString();
        string PaperID = ddlPaper.SelectedValue;

        if (!(SingleSelectedService.Getitem(UserID, PaperID)))
        {
            lblMessage.Text = "您已经考过";
        }
        else
        {
            Session["PaperID"] = ddlPaper.SelectedValue;
            Session["PaperName"] = ddlPaper.SelectedItem.Text;
            Session["userID"] = Session["userID"].ToString();
            Session["userName"] = labUser.Text;
            // Response.Write("<script>window.open('UserTest.aspx?paperId=" + ddlPaper.SelectedValue + "',null,'fullscreen=1')</script>");
           // string tmp_loc="UserTest.aspx?paperId=" + ddlPaper.SelectedValue + "";
            Response.Redirect("ExampaperMaster.aspx?paperId=" + ddlPaper.SelectedValue + "");
            Response.Write("<script language=javascript>window.close('StudentIndex.aspx');</script>");
            //this.Button1.Attributes.Add("onclick","windows.parent.document.all('right').location="+tmp_loc+"");
        }
    }
    protected void exit_Click(object sender, EventArgs e)
    {

    }
}
