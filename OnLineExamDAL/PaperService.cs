using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace OnLineExamDAL
{
    public class PaperService
    {
        public string GetPaperType(int id)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string type = "";
                string sql = "select * from Paper where PaperID=" + id + "";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    type = dr["PaperName"].ToString();
                }
                dr.Close();
                conn.Close();
                return type;
            }
        }
        /// <summary>
        /// 5^1^a^s^p^x
        /// </summary>
        /// <param name="PaperID"></param>
        /// <returns></returns>
        public static bool UpdatePaperState(int PaperID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"Update Paper set PaperState='false' where PaperID='{0}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PaperID);
                cmd.CommandText = sql;
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public static bool UpdatePaperState1(int PaperID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"Update Paper set PaperState='true' where PaperID='{0}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PaperID);
                cmd.CommandText = sql;
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        //É¾³ýÊÔ¾í
        public static bool DeletePaper(int PaperID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"Delete from Paper where PaperID='{0}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PaperID);
                cmd.CommandText = sql;
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        //É¾³ýÊÔ¾íµÄÌâ
        public static bool DeletePaperDetail(int PaperID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"Delete from PaperDetail where PaperID='{0}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PaperID);
                cmd.CommandText = sql;
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
    }
}
