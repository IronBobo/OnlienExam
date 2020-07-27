using System;
using System.Collections.Generic;
using System.Text;
using OnLineExamModel;
using System.Data.SqlClient;

namespace OnLineExamDAL
{
    public class QuestionProblemService
    {
        public static bool QuestionProblemInsert(QuestionProblem qi)
        {
            string sql = "Insert into QuestionProblem(CourseID,Title,Answer) values(@CourseID,@Title,@Answer)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CourseID",qi.CourseID),
                new SqlParameter("@Title",qi.Title),
                new SqlParameter("@Answer",qi.Answer)
            };
            int i = DBHelp.ExecuteCommand(sql, param);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool QuestionProblemUpdate(QuestionProblem qu)
        {
            string sql = "Update QuestionProblem Set CourseID=@CourseID,Title=@Title,Answer=@Answer where ID=@ID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CourseID",qu.CourseID),
                new SqlParameter("@Title",qu.Title),
                new SqlParameter("@Answer",qu.Answer),
                new SqlParameter("@ID",qu.ID)
            };
            int i = DBHelp.ExecuteCommand(sql, param);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<QuestionProblem> GetQuestionProblemList(string selectvalue)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "Select * from QuestionProblem where CourseID='" + selectvalue + "'";
                SqlCommand cmd = new SqlCommand(sql,con);
                con.Open();
                List<QuestionProblem> list = new List<QuestionProblem>();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    QuestionProblem ques = new QuestionProblem();
                    ques.ID = Convert.ToInt32(dr["ID"]);
                    ques.CourseID = Convert.ToInt32(dr["CourseID"]);
                    ques.Title = dr["Title"].ToString();
                    ques.Answer = dr["Answer"].ToString();
                    list.Add(ques);
                }
                return list;
            }
        }

        public List<QuestionProblem> selectQuesQuestion(string UserId,int PaperId)
        {
            using (SqlConnection con=DBHelp.GetConnection())
            {
                string sql = @"SELECT     dbo.UserAnswer.Mark, dbo.UserAnswer.UserAnswer, dbo.UserAnswer.ExamTime, dbo.QuestionProblem.Title, dbo.QuestionProblem.Answer, 
                      dbo.Paper.PaperName
FROM         dbo.UserAnswer INNER JOIN
                      dbo.QuestionProblem ON dbo.UserAnswer.TitleID = dbo.QuestionProblem.ID INNER JOIN
                      dbo.Paper ON dbo.UserAnswer.PaperID = dbo.Paper.PaperID AND dbo.UserAnswer.Type = 'Œ ¥Ã‚'
where 
dbo.UserAnswer.UserID='" + UserId + "' and dbo.UserAnswer.PaperID='" + PaperId + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<QuestionProblem> list = new List<QuestionProblem>();
                while (dr.Read())
                {
                    QuestionProblem Ques = new QuestionProblem();
                    Ques.Mark = Convert.ToInt32(dr["Mark"]);
                    Ques.UserAnswer = dr["UserAnswer"].ToString();
                    Ques.ExamTime = Convert.ToDateTime(dr["ExamTime"]);
                    Ques.Title = dr["Title"].ToString();
                    Ques.Answer = dr["Answer"].ToString();
                    Ques.PaperName = dr["PaperName"].ToString();
                    list.Add(Ques);
                }
                return list;
            }
        }
    }
}
