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
using OnLineExamDAL;
using OnLineExamBLL;
using System.Data.SqlClient;

public partial class Web_PaperSetup2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "试卷制定";
        if (!Page.IsPostBack)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string userId = Session["userID"].ToString();
                string userName = UserManager.GetUserName(userId);
                
                if (!RoleManager.IsHasDuty(userName, "HasDuty_PaperSetup"))
                {
                    Response.Redirect("noDuty.aspx");
                }
                else
                {
                    InitData();
                    GVbind();
                }
            }
        }
    }

    private void GVbind()
    {
        DBHelp db = new DBHelp();//创建DBHelp类对象
        string GridView1Str = "select * from SingleProblem";//根据参数设置查询单选题Sql语句
        DataSet ds1 = db.GetDataSetSql(GridView1Str);//调用DBHelp类方法GetDataSetSql方法查询数据
        GridView1.DataSource = ds1.Tables[0].DefaultView;//为单选题GridView控件指名数据源
        GridView1.DataBind();//绑定数据

        string GridView2Str = "select * from MultiProblem";//根据参数设置查询多选题Sql语句
        DataSet ds2 = db.GetDataSetSql(GridView2Str);//调用DBHelp类方法GetDataSetSql方法查询数据
        GridView2.DataSource = ds2.Tables[0].DefaultView;//为多选题GridView控件指名数据源
        GridView2.DataBind();//绑定数据

        string GridView3Str = "select * from JudgeProblem";//根据参数设置查询判断题Sql语句
        DataSet ds3 = db.GetDataSetSql(GridView3Str);//调用DBHelp类方法GetDataSetSql方法查询数据
        GridView3.DataSource = ds3.Tables[0].DefaultView;//为判断题GridView控件指名数据源
        GridView3.DataBind();//绑定数据

        string GridView4Str = "select * from FillBlankProblem";//根据参数设置查询填空题Sql语句
        DataSet ds4 = db.GetDataSetSql(GridView4Str);//调用DBHelp类方法GetDataSetSql方法查询数据
        GridView4.DataSource = ds4.Tables[0].DefaultView;//为填空题GridView控件指名数据源
        GridView4.DataBind();//绑定数据

        string GridView5Str = "select * from QuestionProblem";//根据参数设置查询问答题Sql语句
        DataSet ds5 = db.GetDataSetSql(GridView5Str);//调用DBHelp类方法GetDataSetSql方法查询数据
        GridView5.DataSource = ds5.Tables[0].DefaultView;//为问答题GridView控件指名数据源
        GridView5.DataBind();//绑定数据
    }
    //初始化考试科目
    private void InitData()
    {
        CourseManager course = new CourseManager();       //创建考试科目对象
        DataSet ds = course.QueryCourse();  //查询考试科目信息
        ddlCourse.DataSource = ds;          //指名考试科目列表框数据源
        ddlCourse.DataTextField = "Name";   //DataTextField显示Name字段值
        ddlCourse.DataValueField = "ID";    //DataValueField显示ID字段值
        ddlCourse.DataBind();               //绑定数据
    }
    /// <summary>
    /// 选择所有
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            ((CheckBox)GridView1.Rows[i].FindControl("chkSelect1")).Checked = this.chkSelectAll.Checked;
        }
        for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
        {
            ((CheckBox)GridView2.Rows[i].FindControl("chkSelect2")).Checked = this.chkSelectAll.Checked;
        }
        for (int i = 0; i <= GridView3.Rows.Count - 1; i++)
        {
            ((CheckBox)GridView3.Rows[i].FindControl("chkSelect3")).Checked = this.chkSelectAll.Checked;
        }
        for (int i = 0; i <= GridView4.Rows.Count - 1; i++)
        {
            ((CheckBox)GridView4.Rows[i].FindControl("chkSelect4")).Checked = this.chkSelectAll.Checked;
        }
        for (int i = 0; i <= GridView5.Rows.Count - 1; i++)
        {
            ((CheckBox)GridView5.Rows[i].FindControl("chkSelect5")).Checked = this.chkSelectAll.Checked;
        }
    }

    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        DBHelp db = new DBHelp();
        string insertpaper = "insert into Paper(CourseID,PaperName,PaperState) values(" + int.Parse(ddlCourse.SelectedValue) + ",'" + txtPaperName.Text + "',1) SELECT @@IDENTITY as id";
        int afterID = GetIDInsert(insertpaper);//保存试卷，并返回自动生成的试卷编号
        if (afterID > 0)
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                bool isChecked = ((CheckBox)GridView1.Rows[i].FindControl("chkSelect1")).Checked;
                if (isChecked)
                {
                    string str1 = ((Label)GridView1.Rows[i].FindControl("Label3")).Text;
                    string single = "insert into PaperDetail(PaperID,Type,TitleID,Mark) values(" + afterID + ",'单选题'," + str1 + "," + int.Parse(txtSingleFen.Text) + ")";
                    db.Insert(single);
                }

            }
            for (int i = 0; i < this.GridView2.Rows.Count; i++)
            {
                bool isChecked = ((CheckBox)GridView2.Rows[i].FindControl("chkSelect2")).Checked;
                if (isChecked)
                {
                    string str2 = ((Label)GridView2.Rows[i].FindControl("Label6")).Text;
                    string multi = "insert into PaperDetail(PaperID,Type,TitleID,Mark) values(" + afterID + ",'多选题'," + str2 + "," + int.Parse(txtMultiFen.Text) + ")";
                    db.Insert(multi);
                }

            }
            for (int i = 0; i < this.GridView3.Rows.Count; i++)
            {
                bool isChecked = ((CheckBox)GridView3.Rows[i].FindControl("chkSelect3")).Checked;
                if (isChecked)
                {
                    string str3 = ((Label)GridView3.Rows[i].FindControl("Label7")).Text;
                    string judge = "insert into PaperDetail(PaperID,Type,TitleID,Mark) values(" + afterID + ",'判断题'," + str3 + "," + int.Parse(txtJudgeFen.Text) + ")";
                    db.Insert(judge);
                }

            }
            for (int i = 0; i < this.GridView4.Rows.Count; i++)
            {
                bool isChecked = ((CheckBox)GridView4.Rows[i].FindControl("chkSelect4")).Checked;
                if (isChecked)
                {
                    string str4 = ((Label)GridView4.Rows[i].FindControl("Label8")).Text;
                    string fill = "insert into PaperDetail(PaperID,Type,TitleID,Mark) values(" + afterID + ",'填空题'," + str4 + "," + int.Parse(txtFillFen.Text) + ")";
                    db.Insert(fill);
                }

            }
            for (int i = 0; i < this.GridView5.Rows.Count; i++)
            {
                bool isChecked = ((CheckBox)GridView5.Rows[i].FindControl("chkSelect5")).Checked;
                if (isChecked)
                {
                    string str5 = ((Label)GridView5.Rows[i].FindControl("Label23")).Text;
                    string que = "insert into PaperDetail(PaperID,Type,TitleID,Mark) values(" + afterID + ",'问答题'," + str5 + "," + int.Parse(txtQuestionFen.Text) + ")";
                    db.Insert(que);
                }

            }
        }
        Response.Write("<script language=javascript>alert('保存成功');location='PaperLists.aspx'</script>");

    }

    public int GetIDInsert(string XSqlString)
    {
        SqlConnection Connection = DBHelp.GetConnection();
        Connection.Open();
        SqlCommand cmd = new SqlCommand(XSqlString, Connection);
        int Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
}
