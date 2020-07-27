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

public partial class Web_ExampaperMaster : System.Web.UI.Page
{
    protected int singeCount = 1;
    protected int multiCount = 1;
    protected int judgeCount = 1;
    protected int fillbkCount = 1;
    protected int questiCount = 1;
    public int examtime = 90;//默认值
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
                string action = Request.QueryString["action"];
                Response.Clear();
                if (!string.IsNullOrEmpty(action))
                {
                    NewMethod();
                }
                else
                {

                    string userId = Session["userID"].ToString();
                    string userName = UserManager.GetUserName(userId);

                    //Label i1 = (Label)Page.FindControl("labUser2");

                    // i1.Text = userName;

                    lblPaperName.Text = Session["PaperName"].ToString();
                    examtime = CourseManager.GetExamtime(lblPaperName.Text);
                    GetParperAll();
                }
            }
        }
    }

    private void GetParperAll()
    {
        int int_tihao = 0;

        //单选题
        IEnumerable list = sqlSingleMark.Select(DataSourceSelectArguments.Empty);
        DataView dv_list = (DataView)list;
        if (dv_list.Count == 0)
        {
            dxt1.Attributes.Add("style", "display:none;");
            
        }
        else
        {
            foreach (DataRowView o in list)
            {
                labSingle.Text = o[0].ToString();
                break;
            }
            int_tihao += 1;
            tihao1.InnerHtml = AtoChs(int_tihao.ToString());
        }

        
        //多选题
        IEnumerable list1 = SqlMultiMark.Select(DataSourceSelectArguments.Empty);
        DataView dv_list1 = (DataView)list1;
        if (dv_list1.Count == 0)
        {
            dxt2.Attributes.Add("style", "display:none;");
        }
        else
        {

            foreach (DataRowView o in list1)
            {
                Label3.Text = o[0].ToString();
                break;
            }
            int_tihao += 1;
            tihao2.InnerHtml = AtoChs(int_tihao.ToString());
        }

        //判断题
        IEnumerable list3 = SqlJudgeMark.Select(DataSourceSelectArguments.Empty);
        DataView dv_list3 = (DataView)list3;
        if (dv_list3.Count == 0)
        {
            pdt.Attributes.Add("style", "display:none;");
        }
        else
        {
            foreach (DataRowView o in list3)
            {
                Label4.Text = o[0].ToString();
                break;
            }
            int_tihao += 1;
            tihao3.InnerHtml = AtoChs(int_tihao.ToString());
        }

        //填空题

            IEnumerable list2 = SqlFillMark.Select(DataSourceSelectArguments.Empty);           
            DataView dt = (DataView)list2;
            if (dt.Count == 0)
            {
                tkt.Attributes.Add("style", "display:none;");
            }
            else
            {
                foreach (DataRowView o in list2)
                {

                    Label5.Text = o[0].ToString();
                    break;
                }
                int_tihao += 1;
                tihao4.InnerHtml = AtoChs(int_tihao.ToString());
            }
            
        
        


        //问答题
        IEnumerable WDT = sqlQuestion.Select(DataSourceSelectArguments.Empty);
        DataView dv_wdt = (DataView)WDT;
        if (dv_wdt.Count> 0)
        {
            IEnumerable list4 = SqlQuestionMark.Select(DataSourceSelectArguments.Empty);
            foreach (DataRowView o in list4)
            {
                Label6.Text = o[0].ToString();
                break;
            }
            int_tihao += 1;
            tihao5.InnerHtml = AtoChs(int_tihao.ToString());
        }
        else
        {
            wdt.Attributes.Add("style", "display:none;");
        }
    }


    //protected void imgBtnSubmit_Click(object sender, ImageClickEventArgs e)
    //{
        
    //    NewMethod();
    //}

    //提交答案
    public void NewMethod()
    {
        string Label = labSingle.Text;//单选分数
        string paperid = Session["PaperID"].ToString();
        string UserId = Session["userID"].ToString();
        DBHelp db = new DBHelp();
        foreach (RepeaterItem item in singleRep.Items)
        {
            HiddenField titleId = item.FindControl("titleId") as HiddenField;
            string id = (string)titleId.Value;
            string str = "";
            if (((RadioButton)item.FindControl("rbA")).Checked)
            {
                str = "A";
            }
            else if (((RadioButton)item.FindControl("rbB")).Checked)
            {
                str = "B";
            }
            else if (((RadioButton)item.FindControl("rbC")).Checked)
            {
                str = "C";
            }
            else if (((RadioButton)item.FindControl("rbD")).Checked)
            {
                str = "D";
            }
            string single = "insert into UserAnswer(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + UserId + "','" + paperid + "','单选题','" + id + "','" + Label + "','" + str + "','" + DateTime.Now.ToString() + "')";
            db.Insert(single);

        }


        string labeM = Label3.Text;//多选分数
        foreach (RepeaterItem item in Repeater2.Items)
        {
            HiddenField titleId = item.FindControl("titleId") as HiddenField;
            string id = (string)titleId.Value;
            string str = "";
            if (((CheckBox)item.FindControl("CheckBox1")).Checked)
            {
                str += "A";
            }
            if (((CheckBox)item.FindControl("CheckBox2")).Checked)
            {
                str += "B";
            }
            if (((CheckBox)item.FindControl("CheckBox3")).Checked)
            {
                str += "C";
            }
            if (((CheckBox)item.FindControl("CheckBox4")).Checked)
            {
                str += "D";
            }
            if (((CheckBox)item.FindControl("CheckBox5")).Checked)
            {
                str += "E";
            }
            if (((CheckBox)item.FindControl("CheckBox6")).Checked)
            {
                str += "F";
            }
            string Multi = "insert into UserAnswer(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + UserId + "','" + paperid + "','多选题','" + id + "','" + labeM + "','" + str + "','" + DateTime.Now.ToString() + "')";
            db.Insert(Multi);


        }

        string labeJ = Label4.Text;//判断分数
        foreach (RepeaterItem item in Repeater3.Items)
        {
            HiddenField titleId = item.FindControl("titleId") as HiddenField;
            string id = (string)titleId.Value;

            string str = Convert.ToString(false);
            if (((RadioButton)item.FindControl("rbA")).Checked)
            {
                str = Convert.ToString(true);
            }
            else if (((RadioButton)item.FindControl("rbB")).Checked)
            {
                str = Convert.ToString(false);
            }
            string Judge = "insert into UserAnswer(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + UserId + "','" + paperid + "','判断题','" + id + "','" + labeJ + "','" + str + "','" + DateTime.Now.ToString() + "')";
            db.Insert(Judge);
        }

        string labeF = Label5.Text;//填空分数
        foreach (RepeaterItem item in Repeater1.Items)
        {
            HiddenField titleId = item.FindControl("titleId") as HiddenField;
            string id = (string)titleId.Value;
            string str = "";
            str = ((TextBox)item.FindControl("TextBox1")).Text.Trim();
            string Fill = "insert into UserAnswer(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + UserId + "','" + paperid + "','填空题','" + id + "','" + labeF + "','" + str + "','" + DateTime.Now.ToString() + "')";
            db.Insert(Fill);

        } 
        
        
        string labeQ = Label6.Text;//问答分数
        foreach (RepeaterItem item in Repeater4.Items)
        {
            HiddenField titleId = item.FindControl("titleId") as HiddenField;
            string id = (string)titleId.Value;
            string str = "";
            str = ((TextBox)item.FindControl("TextBox2")).Text.Trim();
            string Que = "insert into UserAnswer(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + UserId + "','" + paperid + "','问答题','" + id + "','" + labeQ + "','" + str + "','" + DateTime.Now.ToString() + "')";
            db.Insert(Que);
        }
       
                 
        Response.Write("<script language=javascript>alert('试卷提交成功!');window.close();</script>");
        Response.Redirect("ExamFinish.aspx");

    }

    //public void showmsg()
    //{
    //    Response.Write("<script language=javascript>alert('试卷 响应!');window.close();</script>");
    //}


    protected void Button2_Click(object sender, EventArgs e)
    {
        NewMethod();
    }


    protected string AtoChs(string alabo_num)
    {
        string chs = "";
        switch (alabo_num)
        {
            case "1":
                chs = "一";
                break;
            case "2":
                chs="二";
                break;
            case "3":
                chs = "三";
                break;
            case "4":
                chs = "四";
                break;
            case "5":
                chs = "五";
                break;

        }
        return chs;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        NewMethod();
    }
}
