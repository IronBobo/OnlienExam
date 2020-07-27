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
public partial class Web_RoleManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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

                if (!RoleManager.IsHasDuty(userName, "HasDuty_RoleManage"))
                {
                    Response.Redirect("noDuty.aspx");
                }
                else
                {
                    GV.DataSource = RoleManager.DutyListRoles();
                    GV.DataBind();
                }
            }
        }
        this.Page.Title = "权限管理";
    }
    protected void GV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#cbe2fa'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");

            Role role = (Role)e.Row.DataItem;
            CheckBox CheckBox1 = e.Row.FindControl("chkRoleManage") as CheckBox;//角色信息管理
            CheckBox CheckBox2 = e.Row.FindControl("chkUserManage") as CheckBox;//用户管理
            //CheckBox CheckBox3 = e.Row.FindControl("chkCourseManage") as CheckBox;//科目管理
            CheckBox CheckBox4 = e.Row.FindControl("chkPaperSetup") as CheckBox;//试卷管理
            CheckBox CheckBox5 = e.Row.FindControl("chkUserPaperList") as CheckBox;//考生试卷管理
            CheckBox CheckBox6 = e.Row.FindControl("chkTypeManage") as CheckBox;//试题类别管理


            CheckBox cb = CheckBox1 as CheckBox;
            CheckBox cb1 = CheckBox2 as CheckBox;
           // CheckBox cb2 = CheckBox3 as CheckBox;
            CheckBox cb3 = CheckBox4 as CheckBox;
            CheckBox cb4 = CheckBox5 as CheckBox;
            CheckBox cb5 = CheckBox6 as CheckBox;

            bool userAns = Convert.ToBoolean(role.HasDuty_RoleManage);
            bool userAns1 = Convert.ToBoolean(role.HasDuty_UserManage);
            //bool userAns2 = Convert.ToBoolean(role.HasDuty_CourseManage);
            bool userAns3 = Convert.ToBoolean(role.HasDuty_PaperSetup);
            bool userAns4 = Convert.ToBoolean(role.HasDuty_UserPaperList);
            bool userAns5 = Convert.ToBoolean(role.HasDuty_TypeManage);

            if (userAns == true)
            {
                cb.Checked = true;
            }
            if (userAns1 == true)
            {
                cb1.Checked = true;
            }
            //if (userAns2 == true)
            //{
            //    cb2.Checked = true;
            //}
            if (userAns3 == true)
            {
                cb3.Checked = true;
            }
            if (userAns4 == true)
            {
                cb4.Checked = true;
            }
            if (userAns5 == true)
            {
                cb5.Checked = true;
            }
        }
    }

    /// <summary>
    /// 授权，对各个选项授权
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Giant_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < GV.Rows.Count; i++)
            {
                Role role = new Role();
                role.RoleId =int.Parse(GV.Rows[i].Cells[0].Text);
                role.RoleName = GV.Rows[i].Cells[1].Text;
                role.HasDuty_RoleManage = Convert.ToInt32(((CheckBox)GV.Rows[i].FindControl("chkRoleManage")).Checked);
                role.HasDuty_UserManage = Convert.ToInt32(((CheckBox)GV.Rows[i].FindControl("chkUserManage")).Checked);
                role.HasDuty_PaperSetup = Convert.ToInt32(((CheckBox)GV.Rows[i].FindControl("chkPaperSetup")).Checked);
                role.HasDuty_UserPaperList = Convert.ToInt32(((CheckBox)GV.Rows[i].FindControl("chkUserPaperList")).Checked);
                role.HasDuty_TypeManage = Convert.ToInt32(((CheckBox)GV.Rows[i].FindControl("chkTypeManage")).Checked);

                RoleManager.UpdateRolesDuty(role);
                
            }
            Response.Write("<script language=javascript>alert('保存成功');location='PaperLists.aspx'</script>");
        }
        catch (Exception ex)
        {
            Response.Write("出现错误" + ex.ToString());
           
        }
    }
}
