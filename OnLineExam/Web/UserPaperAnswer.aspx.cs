using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using OnLineExamBLL;
using OnLineExamModel;
using System.Web.UI.HtmlControls;
using OnLineExamDAL;
public partial class Web_UserPaperAnswer : System.Web.UI.Page
{
    int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "试卷评阅";
        
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

                //多选题绑定
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
                    Label lbl = GridView5.HeaderRow.FindControl("Label34") as Label;
                    lbl.Text = list5[0].Mark.ToString();
                }

               // i = Convert.ToInt32(Session["SingMark"]) + Convert.ToInt32(Session["MulMark"]) + Convert.ToInt32(Session["JudgeMark"]) + Convert.ToInt32(Session["FillMark"]);
               // sumScore.Text = i.ToString();
               // Xpaperid.Text = PaperManager.GetPaperType(paperid);
                //lblExamtime.Text = UserManager.GetTime(Convert.ToInt32(userid));
               // lblExamtime.Text = UserManager.GetTime(userid);//通过用户ID获取用户考试时间
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

    //单选提
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
         
        }
    }
    //多选题
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            MultiProblem obj = (MultiProblem)e.Row.DataItem;
            CheckBox CheckBoxA = e.Row.FindControl("A") as CheckBox;
            CheckBox CheckBoxB = e.Row.FindControl("B") as CheckBox;
            CheckBox CheckBoxC = e.Row.FindControl("C") as CheckBox;
            CheckBox CheckBoxD = e.Row.FindControl("D") as CheckBox;
            CheckBox CheckBoxE = e.Row.FindControl("E") as CheckBox;
            CheckBox CheckBoxF = e.Row.FindControl("F") as CheckBox;
            List<Control> list = new List<Control>();
            list.Add(CheckBoxA);
            list.Add(CheckBoxB);
            list.Add(CheckBoxC);
            list.Add(CheckBoxD);
            list.Add(CheckBoxE);
            list.Add(CheckBoxF);
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
                        cb.CssClass = "";
                    }
                }
            }
        }
    }
    //判断题
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
            //if (userAns == Ans)
            //{
            //    Judcount = Judcount + Marks;
            //    Judright++;
            //}
        }
    }
    //填空题
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            FillBlankProblem Fill = (FillBlankProblem)e.Row.DataItem;
            int Marks = Fill.Mark;
            if (Fill.UserAnswer == Fill.Answer)
            {
                //Fillcount = Fillcount + Marks;
                //Fillright++;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentIndex2.aspx");
    }
}