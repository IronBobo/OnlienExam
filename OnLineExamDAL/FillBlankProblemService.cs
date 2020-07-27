using System;
using System.Collections.Generic;
using System.Text;
using OnLineExamModel;
using System.Data.SqlClient;
using System.Data;

namespace OnLineExamDAL
{
    public class FillBlankProblemService
    {
        public static bool FillBlankProbleUpdate(FillBlankProblem fb)
        {
            string sql = @"UPDATE FillBlankProblem
SET CourseID =@CourseID, FrontTitle =@FrontTitle, BackTitle =@BackTitle,Answer =@Answer where ID=@ID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CourseID",fb.CourseID),
                new SqlParameter("@FrontTitle",fb.FrontTitle),
                new SqlParameter("@BackTitle",fb.BackTitle),
                new SqlParameter("@Answer",fb.Answer),
                new SqlParameter("@ID",fb.ID)
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

        public static bool FillBlankProbleInsert(FillBlankProblem fi)
        {
            string sql = @"insert into FillBlankProblem(CourseID,FrontTitle,BackTitle,Answer)
values(@CourseID,@FrontTitle,@BackTitle,@Answer)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CourseID",fi.CourseID),
                new SqlParameter("@FrontTitle",fi.FrontTitle),
                new SqlParameter("@BackTitle",fi.BackTitle),
                new SqlParameter("@Answer",fi.Answer)
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

        public static bool FillBlankProbleDelete(FillBlankProblem fd)
        {
            string sql = "DELETE FROM SingleProblem WHERE ID=@ID";
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("ID",fd.ID),
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
        public List<FillBlankProblem> GeFillBlankProblemList(string selectvalue)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "select * from FillBlankProblem where CourseID='" + selectvalue + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                List<FillBlankProblem> list = new List<FillBlankProblem>();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    FillBlankProblem fill = new FillBlankProblem();
                    fill.ID = Convert.ToInt32(dr["ID"]);
                    fill.CourseID = Convert.ToInt32(dr["CourseID"]);
                    fill.FrontTitle = dr["FrontTitle"].ToString();
                    fill.BackTitle = dr["BackTitle"].ToString();
                    fill.Answer = dr["Answer"].ToString();
                    list.Add(fill);
                }
                return list;
            }
        }

        public List<FillBlankProblem> FillQuestion(string UserId, int PaperId)
        {
            using (SqlConnection con=DBHelp.GetConnection())
            {
                string sql = @"SELECT     dbo.UserAnswer.Mark, dbo.UserAnswer.UserAnswer, dbo.UserAnswer.ExamTime, dbo.FillBlankProblem.FrontTitle, dbo.FillBlankProblem.BackTitle, 
                      dbo.FillBlankProblem.Answer, dbo.Paper.PaperName
FROM         dbo.UserAnswer INNER JOIN
                      dbo.FillBlankProblem ON dbo.UserAnswer.TitleID = dbo.FillBlankProblem.ID INNER JOIN
                      dbo.Paper ON dbo.UserAnswer.PaperID = dbo.Paper.PaperID AND dbo.UserAnswer.Type = 'ÃÓø’Ã‚' 
where 
dbo.UserAnswer.UserID='" + UserId + "' and dbo.UserAnswer.PaperID='" + PaperId + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<FillBlankProblem> list = new List<FillBlankProblem>();
                while (dr.Read())
                {
                    FillBlankProblem Fill = new FillBlankProblem();
                    Fill.Mark = Convert.ToInt32(dr["Mark"]);
                    Fill.UserAnswer = dr["UserAnswer"].ToString();
                    Fill.ExamTime = Convert.ToDateTime(dr["ExamTime"]);
                    Fill.FrontTitle = dr["FrontTitle"].ToString();
                    Fill.BackTitle = dr["BackTitle"].ToString();
                    Fill.Answer = dr["Answer"].ToString();
                    Fill.PaperName = dr["PaperName"].ToString();
                    list.Add(Fill);
                }
                return list;
            }
        }
    }
}
