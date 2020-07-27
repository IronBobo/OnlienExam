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
using OnLineExamDAL;

public partial class Web_UserPaper : System.Web.UI.Page
{
    int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        this.Page.Title = "试卷评阅";
        Panel1.Visible = true;
        Panel2.Visible = false;
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
                Label i1 = (Label)Page.Master.FindControl("labUser");
                i1.Text = userName;


                string userid = Request["UserID"].ToString();
                int paperid = int.Parse(Request["PaperID"]);

                GridView1.DataSource = SingleSelectedManager.GetSingQuestion(userid, paperid);
                GridView1.DataBind();
                List<SingleProblem> list1 = SingleSelectedManager.GetSingQuestion(userid, paperid);
                if (list1.Count != 0)
                {
                    Label lbl1 = GridView1.HeaderRow.FindControl("Label27") as Label;
                    lbl1.Text = list1[0].Mark.ToString();
                }

                GridView2.DataSource = MultiProblemManager.GetMutiQuestion(userid, paperid);
                GridView2.DataBind();
                List<MultiProblem> list2 = MultiProblemManager.GetMutiQuestion(userid, paperid);
                if (list2.Count != 0)
                {
                    Label lbl2 = GridView2.HeaderRow.FindControl("Label28") as Label;
                    lbl2.Text = list2[0].Mark.ToString();
                }

                GridView3.DataSource = JudgeProblemManager.GetJudgeQuestion(userid, paperid);
                GridView3.DataBind();
                List<JudgeProblem> list3 = JudgeProblemManager.GetJudgeQuestion(userid, paperid);
                if (list3.Count != 0)
                {
                    Label lbl3 = GridView3.HeaderRow.FindControl("Label29") as Label;
                    lbl3.Text = list3[0].Mark.ToString();
                }

                GridView4.DataSource = FillBlankProblemManager.GetFillQuestion(userid, paperid);
                GridView4.DataBind();
                List<FillBlankProblem> list4 = FillBlankProblemManager.GetFillQuestion(userid, paperid);
                if (list4.Count != 0)
                {
                    Label lbl4 = GridView4.HeaderRow.FindControl("Label30") as Label;
                    lbl4.Text = list4[0].Mark.ToString();
                }

                GridView5.DataSource = QuestionProblemManager.GetQuesQuestion(userid, paperid);
                GridView5.DataBind();
                List<QuestionProblem> list5 = QuestionProblemManager.GetQuesQuestion(userid, paperid);
                if (list5.Count != 0)
                {
                    Label lbl = GridView5.HeaderRow.FindControl("Label31") as Label;
                    lbl.Text = list5[0].Mark.ToString();
                }

               // i = Convert.ToInt32(Session["SingMark"]) + Convert.ToInt32(Session["MulMark"]) + Convert.ToInt32(Session["JudgeMark"]) + Convert.ToInt32(Session["FillMark"]);
                i = Convert.ToInt32(Session["SingMark"]) + Convert.ToInt32(Session["MulMark"]) + Convert.ToInt32(Session["JudgeMark"]) ;
                sumScore.Text = i.ToString();
                Xpaperid.Text = PaperManager.GetPaperType(paperid);               
                lblExamtime.Text = UserManager.GetTime(userid);//通过用户ID获取用户考试时间

                //lblExamtime.Text = UserManager.GetTime(Convert.ToInt32(userid));
                //List<UserAnswer> ans = new List<UserAnswer>();
                //UserService user = new UserService();


                //ans = user.selectUserPaperList();
                //foreach (UserAnswer var in ans)
                //{
                //    Xpaperid.Text = var.PaperName.ToString();
                //    lblExamtime.Text = var.ExamTime.ToString();
                //}
            }
        }

    }

    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("UserPaperList.aspx");

    }
    /// <summary>
    /// 人工判题计分
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        //填空题人工判题得分
        TextBox text_fill = new TextBox();
        int grade_fill = 0;
        for (int i = 0; i < GridView4.Rows.Count; i++)
        {
            text_fill = GridView4.Rows[i].FindControl("tbxfilScore") as TextBox;
            grade_fill += Convert.ToInt32(text_fill.Text);
        }

        filScore.Text = grade_fill.ToString();

        //问答题人工判题得分
        TextBox text = new TextBox();
        int grade = 0;
        for (int k = 0; k < GridView5.Rows.Count; k++)
        {
            text = GridView5.Rows[k].FindControl("tbxqueScore") as TextBox;
            grade += Convert.ToInt32(text.Text);
        }

        lblQuestion.Text = grade.ToString();

        sumScore.Text = (Convert.ToInt32(sumScore.Text) + grade+grade_fill).ToString();
    }

    int Mulcount = 0;
    int MulNum = 0;
    int Mulright = 0;
    int Mulerror = 0;
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            MultiProblem obj = (MultiProblem)e.Row.DataItem;
            CheckBox CheckBoxA = e.Row.FindControl("A") as CheckBox;
            CheckBox CheckBoxB = e.Row.FindControl("B") as CheckBox;
            CheckBox CheckBoxC = e.Row.FindControl("C") as CheckBox;
            CheckBox CheckBoxD = e.Row.FindControl("D") as CheckBox;
            List<Control> list = new List<Control>();
            list.Add(CheckBoxA);
            list.Add(CheckBoxB);
            list.Add(CheckBoxC);
            list.Add(CheckBoxD);

            int Marks = obj.Mark;

            string userAns = obj.UserAnswer;

            foreach (Char var in userAns)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    CheckBox cb = list[i] as CheckBox;
                    if (var.ToString() == cb.ID)
                    {
                        cb.Checked = true;
                    }
                }
            }
            MulNum++;
            if (userAns == obj.Answer)
            {
                Mulcount = Mulcount + Marks;
                Mulright++;
            }
            Mulerror = MulNum - Mulright;
            Session["MulMark"] = Mulcount;
            Session["Mulrights"] = Mulright;
            Session["Mulerrors"] = Mulerror;

            float proportion = (float)Mulerror / MulNum;
            Session["proportion1"] = proportion;


            mulScore.Text = Convert.ToString(Session["MulMark"]);


        }
    }//自动我批卷
    int Judcount = 0;
    int JudNum = 0;
    int Judright = 0;
    int Juderror = 0;
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            JudgeProblem judge = (JudgeProblem)e.Row.DataItem;
            CheckBox CheckBox1 = e.Row.FindControl("CheckBox5") as CheckBox;
            CheckBox cb = CheckBox1 as CheckBox;
            bool userAns = Convert.ToBoolean(judge.UserAnswer);
            bool Ans = judge.Answer;
            int Marks = judge.Mark;
            if (userAns == true)
            {
                cb.Checked = true;
            }
            if (userAns == Ans)//评分
            {
                Judcount = Judcount + Marks;
                Judright++;
            }
            JudNum++;
            Juderror = JudNum - Judright;
            Session["Judrights"] = Judright;
            Session["Juderrors"] = Juderror;
            Session["JudgeMark"] = Judcount;

            float proportion = (float)Juderror / JudNum;
            Session["proportion2"] = proportion;
            judScore.Text = Convert.ToString(Session["JudgeMark"]);
        }
    }

    int Fillcount = 0;
    int FillNum = 0;
    int Fillright = 0;
    int Fillerror = 0;
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    FillBlankProblem Fill = (FillBlankProblem)e.Row.DataItem;
        //    int Marks = Fill.Mark;
        //    if (Fill.UserAnswer == Fill.Answer)
        //    {
        //        Fillcount = Fillcount + Marks;
        //        Fillright++;
        //    }
        //    FillNum++;

        //    Fillerror = FillNum - Fillright;
        //    Session["Fillright"] = Fillright;
        //    Session["Fillerrors"] = Fillerror;
        //    Session["FillMark"] = Fillcount;

        //    float proportion = (float)Fillerror / FillNum;
        //    Session["proportion3"] = proportion;
        //    filScore.Text = Convert.ToString(Session["FillMark"]);
        //}
    }
    //对试题的分析
    protected void imgBtnLook_Click(object sender, ImageClickEventArgs e)
    {
        string userid = Request["UserID"].ToString();
        int paperid = int.Parse(Request["PaperID"]);
        Panel1.Visible = false;
        Panel2.Visible = true;
        //单选题状况
        List<SingleProblem> list1 = SingleSelectedManager.GetSingQuestion(userid, paperid);
        if (list1.Count != 0)
        {


            Label34.Text = Session["Singrights"].ToString();
            Label38.Text = Session["Singerrors"].ToString();
            Label42.Text = string.Format("{0:F2}", Session["proportion"]);
            Label53.Text = Session["SingMark"].ToString();
        }


        //多选题状况
        List<MultiProblem> list2 = MultiProblemManager.GetMutiQuestion(userid, paperid);
        if (list2.Count != 0)
        {
            Label39.Text = Session["Mulrights"].ToString();
            Label40.Text = Session["Mulerrors"].ToString();
            Label43.Text = string.Format("{0:F2}", Session["proportion1"]);
            Label54.Text = Session["MulMark"].ToString();
        }
        //判断题状况
        List<JudgeProblem> list3 = JudgeProblemManager.GetJudgeQuestion(userid, paperid);
        if (list3.Count != 0)
        {
            Label52.Text = Session["Judrights"].ToString();
            Label51.Text = Session["Juderrors"].ToString();
            Label44.Text = string.Format("{0:F2}", Session["proportion2"]);
            Label55.Text = Session["JudgeMark"].ToString();
        }
        //填空题状况
        List<FillBlankProblem> list4 = FillBlankProblemManager.GetFillQuestion(userid, paperid);
        if (list4.Count != 0)
        {
            Label49.Text = Session["Fillright"].ToString();
            Label50.Text = Session["Fillerrors"].ToString();
            Label45.Text = string.Format("{0:F2}", Session["proportion3"]);
            Label56.Text = Session["FillMark"].ToString();
        }
        i = Convert.ToInt32(Session["SingMark"]) + Convert.ToInt32(Session["MulMark"]) + Convert.ToInt32(Session["JudgeMark"]) + Convert.ToInt32(Session["FillMark"]);
        Label57.Text = i.ToString();
    }

    int Singcount = 0;
    int SingNum = 0;
    int Singright = 0;
    int Singerror = 0;
    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            SingleProblem spm = (SingleProblem)e.Row.DataItem;
            RadioButton CheckBoxA = e.Row.FindControl("A") as RadioButton;
            RadioButton CheckBoxB = e.Row.FindControl("B") as RadioButton;
            RadioButton CheckBoxC = e.Row.FindControl("C") as RadioButton;
            RadioButton CheckBoxD = e.Row.FindControl("D") as RadioButton;
            List<Control> list = new List<Control>();
            list.Add(CheckBoxA);
            list.Add(CheckBoxB);
            list.Add(CheckBoxC);
            list.Add(CheckBoxD);

            int Marks = spm.Mark;

            string userAns = spm.UserAnswer;

            foreach (Char var in userAns)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    RadioButton cb = list[i] as RadioButton;
                    if (var.ToString() == cb.ID)
                    {
                        cb.Checked = true;
                    }
                }

            }
            SingNum++;
            if (userAns == spm.Answer)
            {
                Singcount = Singcount + Marks;
                Singright++;
            }
            Singerror = SingNum - Singright;
            Session["SingMark"] = Singcount;
            Session["Singrights"] = Singright;
            Session["Singerrors"] = Singerror;

            float proportion = (float)Singerror / SingNum;
            Session["proportion"] = proportion;

            sinScore.Text = Convert.ToString(Session["SingMark"]);
        }

    }
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {

        Scores scores = new Scores();
        scores.UserID = Request["UserID"].ToString();
        string PaperName = Xpaperid.Text;
        scores.Score = Convert.ToInt32(sumScore.Text);
        scores.ExamTime = Convert.ToDateTime(lblExamtime.Text);
        scores.JudgeTime = DateTime.Now;

        string userId = Request["UserID"].ToString();
        int paperId = int.Parse(Request["PaperID"]);
        if (UserManager.InsertScores(scores, PaperName, userId, paperId))
        {
            lblMessage.Text = "插入成功！";
        }
        else
        {
            lblMessage.Text = "插入失败！";
        }
    }
}
