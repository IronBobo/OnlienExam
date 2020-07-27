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
using System.Data.SqlClient;
using OnLineExamDAL;
using OnLineExamBLL;

public partial class Web_PaperSetup : System.Web.UI.Page
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
                Label i = (Label)Page.Master.FindControl("labUser");
                i.Text = userName;

                if (!RoleManager.IsHasDuty(userName, "HasDuty_PaperSetup"))
                {
                    Response.Redirect("noDuty.aspx");
                }
                else
                {
                    InitData();
                }
            }
        }
    }
    protected void imgBtnConfirm_Click(object sender, ImageClickEventArgs e)
    {
        Panel1.Visible = true;
        DBHelp db = new DBHelp();//创建DBHelp类对象

        if (int.Parse(txtSingleNum.Text.Trim()) != 0)
        {
            string GridView1Str = "select top " + int.Parse(txtSingleNum.Text.Trim()) + " * from SingleProblem order by newid()";//Sql语句根据参数设置查询单选题
            DataSet ds1 = db.GetDataSetSql(GridView1Str);//调用DBHelp类方法GetDataSetSql方法查询数据
            GridView1.DataSource = ds1.Tables[0].DefaultView;//为单选题GridView控件指名数据源
            GridView1.DataBind();//绑定数据
        }
        else
        {
            sxt.Attributes.Add("style", "display:none;");//如果单选题数量=0，表示无单选题，单选题就在预览试卷中不显示。
        }

        if (int.Parse(txtMultiNum.Text.Trim()) != 0)
        {

            string GridView2Str = "select top " + int.Parse(txtMultiNum.Text.Trim()) + " * from MultiProblem order by newid()";//根据参数设置查询多选题Sql语句
            DataSet ds2 = db.GetDataSetSql(GridView2Str);//调用DBHelp类方法GetDataSetSql方法查询数据
            GridView2.DataSource = ds2.Tables[0].DefaultView;//为多选题GridView控件指名数据源
            GridView2.DataBind();//绑定数据
        }
        else
        {
            dxt.Attributes.Add("style", "display:none;");
        }


        if (int.Parse(txtJudgeNum.Text.Trim()) != 0)
        {
            string GridView3Str = "select top " + int.Parse(txtJudgeNum.Text.Trim()) + " * from JudgeProblem order by newid()";//根据参数设置查询判断题Sql语句
            DataSet ds3 = db.GetDataSetSql(GridView3Str);//调用DBHelp类方法GetDataSetSql方法查询数据
            GridView3.DataSource = ds3.Tables[0].DefaultView;//为判断题GridView控件指名数据源
            GridView3.DataBind();//绑定数据
        }
        else
        {
            pdt.Attributes.Add("style", "display:none;");
        }

        if (int.Parse(txtFillNum.Text.Trim()) != 0)
        {
            string GridView4Str = "select top " + int.Parse(txtFillNum.Text.Trim()) + " * from FillBlankProblem order by newid()";//根据参数设置查询填空题Sql语句
            DataSet ds4 = db.GetDataSetSql(GridView4Str);//调用DBHelp类方法GetDataSetSql方法查询数据
            GridView4.DataSource = ds4.Tables[0].DefaultView;//为填空题GridView控件指名数据源
            GridView4.DataBind();//绑定数据
        }
        else
        {
            tkt.Attributes.Add("style", "display:none;");
        }


        if (int.Parse(txtQuestionNum.Text.Trim()) != 0)
        {
            string GridView5Str = "select top " + int.Parse(txtQuestionNum.Text.Trim()) + " * from QuestionProblem order by newid()";//根据参数设置查询填空题Sql语句
            DataSet ds5 = db.GetDataSetSql(GridView5Str);//调用DBHelp类方法GetDataSetSql方法查询数据
            GridView5.DataSource = ds5.Tables[0].DefaultView;//为填空题GridView控件指名数据源
            GridView5.DataBind();//绑定数据
        }
        else
        {
            wdt.Attributes.Add("style", "display:none;");
        }
    }
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        DBHelp db = new DBHelp();
        string insertpaper = "insert into Paper(CourseID,PaperName,PaperState) values(" + int.Parse(ddlCourse.SelectedValue) + ",'" + txtPaperName.Text + "',1) SELECT @@IDENTITY as id";
        int afterID = GetIDInsert(insertpaper);//保存试卷，并返回自动生成的试卷编号
        if (afterID > 0)
        {
            foreach (GridViewRow dr in GridView1.Rows)//保存试卷单选题信息
            {
                string single = "insert into PaperDetail(PaperID,Type,TitleID,Mark) values(" + afterID + ",'单选题'," + int.Parse(((Label)dr.FindControl("Label3")).Text) + "," + int.Parse(txtSingleFen.Text) + ")";
                db.Insert(single);
            }
            foreach (GridViewRow dr in GridView2.Rows)//保存试卷多选题信息
            {
                string multi = "insert into PaperDetail(PaperID,Type,TitleID,Mark) values(" + afterID + ",'多选题'," + int.Parse(((Label)dr.FindControl("Label6")).Text) + "," + int.Parse(txtMultiFen.Text) + ")";
                db.Insert(multi);
            }
            foreach (GridViewRow dr in GridView3.Rows)//保存试卷判断题信息
            {
                string judge = "insert into PaperDetail(PaperID,Type,TitleID,Mark) values(" + afterID + ",'判断题'," + int.Parse(((Label)dr.FindControl("Label7")).Text) + "," + int.Parse(txtJudgeFen.Text) + ")";
                db.Insert(judge);
            }
            foreach (GridViewRow dr in GridView4.Rows)//保存试卷填空题信息
            {
                string fill = "insert into PaperDetail(PaperID,Type,TitleID,Mark) values(" + afterID + ",'填空题'," + int.Parse(((Label)dr.FindControl("Label8")).Text) + "," + int.Parse(txtFillFen.Text) + ")";
                db.Insert(fill);
            }
            foreach (GridViewRow dr in GridView5.Rows)//保存试卷填空题信息
            {
                string que = "insert into PaperDetail(PaperID,Type,TitleID,Mark) values(" + afterID + ",'问答题'," + int.Parse(((Label)dr.FindControl("Label23")).Text) + "," + int.Parse(txtQuestionFen.Text) + ")";
                db.Insert(que);
            }
            Response.Write("<script language=javascript>alert('保存成功');location='PaperLists.aspx'</script>");
        }

    }

    public int GetIDInsert(string XSqlString)
    {
        SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        Connection.Open();
        SqlCommand cmd = new SqlCommand(XSqlString, Connection);
        int Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
    protected void InitData()
    {
        CourseManager course = new CourseManager();       //创建考试科目对象
        DataSet ds = course.QueryCourse();  //查询考试科目信息
        ddlCourse.DataSource = ds;          //指名考试科目列表框数据源
        ddlCourse.DataTextField = "Name";   //DataTextField显示Name字段值
        ddlCourse.DataValueField = "ID";    //DataValueField显示ID字段值
        ddlCourse.DataBind();               //绑定数据
    }
}
