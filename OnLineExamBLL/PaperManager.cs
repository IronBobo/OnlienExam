using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using OnLineExamDAL;

namespace OnLineExamBLL
{
    public class PaperManager
    {
        public DataSet QueryAllPaper()
        {
            DBHelp DB = new DBHelp();
            return DB.GetDataSets("Proc_PaperList");
        }

        //ÐÞ¸ÄÊÔ¾í×´Ì¬
        public static bool UpdatePate(int spp)
        {
            if (PaperService.UpdatePaperState(spp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //ÐÞ¸ÄÊÔ¾í×´Ì¬
        public static bool UpdatePate1(int spp)
        {
            if (PaperService.UpdatePaperState1(spp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// ¸ù¾ÝPaperIdÉ¾³ýÊÔ¾í
        /// </summary>
        /// <param name="PaperId"></param>
        /// <returns></returns>
        public static bool DeletePaper(int PaperId)
        {
            if (PaperService.DeletePaper(PaperId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// ¸ù¾ÝPaperIdÉ¾³ýÊÔ¾íµÄÌâ
        /// </summary>
        /// <param name="PaperId"></param>
        /// <returns></returns>
        public static bool DeletePaperDetail(int PaperId)
        {
            if (PaperService.DeletePaperDetail(PaperId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DataSet GetAllPaperSing(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from SingleProblem where ID in 
                    (select TitleID from dbo.PaperDetail where PaperID='{0}' and Type='{1}')";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }

        }

        public static DataSet GetAllPaperSingMark(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select * from dbo.PaperDetail where PaperID='{0}' and Type='{1}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }

        }


        public static DataSet GetAllPaperMult(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from MultiProblem where ID in 
                    (select TitleID from dbo.PaperDetail where PaperID='{0}' and Type='{1}')";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }
        }

        public static DataSet GetAllPaperMultMark(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select * from dbo.PaperDetail where PaperID='{0}' and Type='{1}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }
        }

        public static DataSet GetAllPaperJudg(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from JudgeProblem where ID in 
                    (select TitleID from dbo.PaperDetail where PaperID='{0}' and Type='{1}')";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }

        }


        public static DataSet GetAllPaperJudgMark(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select * from dbo.PaperDetail where PaperID='{0}' and Type='{1}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }

        }




        public static DataSet GetAllPaperFill(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from FillBlankProblem where ID in 
                    (select TitleID from dbo.PaperDetail where PaperID='{0}' and Type='{1}')";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }

        }
        public static DataSet GetAllPaperFillMark(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select * from dbo.PaperDetail where PaperID='{0}' and Type='{1}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }

        }


        public static DataSet GetAllPaperQues(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from QuestionProblem where ID in 
                    (select TitleID from dbo.PaperDetail where PaperID='{0}' and Type='{1}')";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }

        }

        public static DataSet GetAllPaperQuesMark(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select * from dbo.PaperDetail where PaperID='{0}' and Type='{1}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }

        }

        //²éÑ¯ËùÓÐ¿¼¹ýµÄÊÔ¾í
        public static DataSet QueryPaper()
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from Paper where PaperState='True'";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }
        }
        static PaperService service=new PaperService();
        public static string GetPaperType(int id)
        {
            return service.GetPaperType(id);
        }

    }
}
