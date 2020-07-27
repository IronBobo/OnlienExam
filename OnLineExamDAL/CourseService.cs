using System;
using System.Collections.Generic;
using System.Text;
using OnLineExamModel;
using System.Data.SqlClient;

namespace OnLineExamDAL
{
    public class CourseService
    {
        public void Update(string Name, string ID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = "update Users set Name='{0}' where ID='{1}'";

                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, Name, ID);
                cmd.CommandText = sql;
                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        public static bool insertCourse(Course ic)
        {
            string sql = "insert into Course ([Name],[examtime]) values(@Name,@examtime)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Name",ic.DepartmentName),
                new SqlParameter("@examtime",ic.Examtime)
            };
            int i = DBHelp.ExecuteCommand(sql, para);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteCourse(Course id)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "delete from Course where ID=@id";
                SqlParameter[] sp = new SqlParameter[] 
                {
                    new SqlParameter("@id",id.DepartmentId),
                };
                int i = DBHelp.ExecuteCommand(sql, sp);
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

        public static List<Course> SelectCourse()
        {
            using (SqlConnection con=DBHelp.GetConnection())
            {
                string sql = "select * from Course";
                SqlCommand cmd = new SqlCommand(sql,con);
                con.Open();
                List<Course> list = new List<Course>();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Course c = new Course();
                    c.DepartmentId = Convert.ToInt32(dr["ID"].ToString());
                    c.DepartmentName = dr["Name"].ToString();
                    c.Examtime = int.Parse(dr["examtime"].ToString());
                    list.Add(c);
                }
                dr.Close();
                con.Close();
                return list;
            }
        }




        public  int GetExamtime(string name)
        {
            int time=0;
            using (SqlConnection con = DBHelp.GetConnection())
            {
               // string sql = "select * from Course where Name='"+name+"'";
                string sql = "select examtime from course inner join Paper on Course.ID=Paper.CourseID where PaperName= '"+name+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                //List<Course> list = new List<Course>();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                   // Course c = new Course();
                   // c.DepartmentId = Convert.ToInt32(dr["ID"].ToString());
                   // c.DepartmentName = dr["Name"].ToString();
                    time = int.Parse(dr["examtime"].ToString());
                   
                }
                dr.Close();
                con.Close();
                return time;
            }
           
        }
    }
}
