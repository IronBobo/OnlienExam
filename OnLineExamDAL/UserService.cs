using System;
using System.Collections.Generic;
using System.Text;
using OnLineExamModel;
using System.Data;
using System.Data.SqlClient;

namespace OnLineExamDAL
{
    public class UserService
    {

        public List<Scores> SelectAll(string PaperID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select ID,Score.UserID,PaperID,Score,ExamTime,JudgeTime,Users.UserName from Score,Users 
where Score.UserID=Users.UserID and PaperID='" + PaperID + "'";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                List<Scores> list = new List<Scores>();

                while (dr.Read())
                {
                    Users user = new Users();
                    Scores scores = new Scores();

                    scores.ID = Convert.ToInt32(dr["ID"]);
                    scores.UserID = dr["UserID"].ToString();
                    user.UserName = dr["UserName"].ToString();
                    scores.UserName = user.UserName;
                    scores.PaperID = Convert.ToInt32(dr["PaperID"]);
                    scores.Score = Convert.ToInt32(dr["Score"]);
                    scores.ExamTime = Convert.ToDateTime(dr["ExamTime"]);
                    scores.JudgeTime = Convert.ToDateTime(dr["JudgeTime"]);

                    list.Add(scores);
                }

                dr.Close();

                conn.Close();

                return list;
            }
        }

        public List<Scores> SelectAll()
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
//                string sql = @"select ID,Score.UserID,PaperID,Score,ExamTime,JudgeTime,Users.UserName from Score,Users 
//where Score.UserID=Users.UserID";
                string sql = @"SELECT ID,Score.UserID,Score.PaperID,PaperName,Score,ExamTime,JudgeTime,Users.UserName  FROM Score inner join Users on  Score.UserID=Users.UserID inner join Paper on Paper.PaperID=Score.PaperID";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                List<Scores> list = new List<Scores>();

                while (dr.Read())
                {
                    Users user = new Users();
                    Scores scores = new Scores();

                    scores.ID = Convert.ToInt32(dr["ID"]);
                    scores.UserID = dr["UserID"].ToString();
                    user.UserName = dr["UserName"].ToString();
                    scores.UserName = user.UserName;
                    scores.PaperID = Convert.ToInt32(dr["PaperID"]);
                    scores.PaperName = dr["PaperName"].ToString();
                    scores.Score = Convert.ToInt32(dr["Score"]);
                    scores.ExamTime = Convert.ToDateTime(dr["ExamTime"]);
                    scores.JudgeTime = Convert.ToDateTime(dr["JudgeTime"]);

                    list.Add(scores);
                }

                dr.Close();

                conn.Close();

                return list;
            }
        }

        public List<Users> SelectUserID(string userID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select UserId,UserName,RoleName from Users,[Role]where Users.roleId  = [Role].roleId and UserID='" + userID + "' ";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();

                List<Users> list = new List<Users>();

                while (sdr.Read())
                {
                    Users user = new Users();
                    user.UserID = sdr["userID"].ToString();
                    user.UserName = sdr["userName"].ToString();

                    Role role = new Role();
                    role.RoleName = sdr["RoleName"].ToString();
                    user.RoleName = role.RoleName;

                    list.Add(user);
                }

                sdr.Close();

                conn.Close();

                return list;
            }
        }

        public List<Users> SelectUserName(string userName)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select UserId,UserName,RoleName from Users,[Role]where Users.roleId  = [Role].roleId and UserName='" + userName + "' ";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();

                List<Users> list = new List<Users>();

                while (sdr.Read())
                {
                    Users user = new Users();
                    user.UserID = sdr["userID"].ToString();
                    user.UserName = sdr["userName"].ToString();

                    Role role = new Role();
                    role.RoleName = sdr["RoleName"].ToString();
                    user.RoleName = role.RoleName;

                    list.Add(user);
                }

                sdr.Close();

                conn.Close();

                return list;
            }
        }

        public List<Users> SelectUser()
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select UserId,UserName,RoleName from Users,[Role]where Users.roleId  = [Role].roleId";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();

                List<Users> list = new List<Users>();

                while (sdr.Read())
                {
                    Users user = new Users();
                    user.UserID = sdr["userID"].ToString();
                    user.UserName = sdr["userName"].ToString();

                    Role role = new Role();
                    role.RoleName = sdr["RoleName"].ToString();
                    user.RoleName = role.RoleName;

                    list.Add(user);
                }

                sdr.Close();

                conn.Close();

                return list;
            }
        }


        public static bool insertUsers(Users user)
        {
            string sql = @"insert into Users (UserId,UserName,UserPwd,RoleId) 
VALUES (@UserId,@UserName,@UserPwd,@RoleId)";

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@UserId",user.UserID),
                new SqlParameter("@UserName",user.UserName),
                new SqlParameter("@UserPwd",user.UserPwd),
                new SqlParameter("@RoleId",user.RoleId)
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

        public Users  LoginUser(string UserID, string pwd)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"SELECT 
UserID, UserName,UserPwd,Users.RoleId,RoleName
FROM Users, Role
WHERE UserID ='{0}' AND UserPwd ='{1}' AND Users.RoleId = Role.RoleId";



                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, UserID, pwd);
                cmd.CommandText = sql;
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (!dr.Read())
                {
                    return null;
                }

                Users u = PopUserFromDataReader(dr);

                dr.Close();

                return u;
            }
        }
        //用户登陆判断
        public Logined Logined(string UserID, string pwd)
        {
            Logined lg = new Logined();
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select UserPwd from Users where UserID='{0}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, UserID);
                cmd.CommandText = sql;
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    //if (dr["UserPwd"].ToString() != "")
                    //{
                    if (pwd == dr["UserPwd"].ToString())
                    {
                        lg.login_status = true;
                        lg.login_errstr = "用户名密码匹配，成功登陆";
                    }
                    else
                    {
                        lg.login_status = false;
                        lg.login_errstr = "用户密码不正确！";
                    }
                    //}
                }
                else
                {
                    lg.login_status = false;
                    lg.login_errstr = "用户不存在！";
                }

                dr.Close();
                return lg;

            }
        }



        private Users PopUserFromDataReader(IDataReader dr)
        {
            Users u = new Users();

            u.UserID = dr["UserID"].ToString();
            u.UserName = dr["UserName"].ToString();
            u.UserPwd = dr["UserPwd"].ToString();


            Role role = new Role();

            role.RoleId = Convert.ToInt32(dr["RoleId"]);
            role.RoleName = dr["RoleName"].ToString();

            u.Role = role;

            return u;
        }


        public void Update(string UserPwd, string UserId)//根椐用的帐号修改密码;
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = "update Users set UserPwd='{0}' where UserID='{1}'";

                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, UserPwd, UserId);
                cmd.CommandText = sql;
                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        public static bool Update1(string UserId, string UserPwd)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = "update Users set UserPwd='{0}' where UserID='{1}'";

                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, UserPwd, UserId);
                cmd.CommandText = sql;
                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }

            return true;
        }

        public static bool delUserId(string UserId)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"delete from Users where UserId = '" + UserId + "'";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }

            return true;
        }

        public List<UserAnswer> selectUserPaperList()
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = @"select 
u.UserName,p.PaperName,ua.ExamTime,ua.UserID,ua.PaperID
from
Users as u,Paper as p,UserAnswer as ua
where 
ua.UserID = u.UserID and ua.PaperID = p.PaperID and ua.ExamTime = ua.ExamTime and ua.UserID= ua.UserID and ua.PaperID=ua.PaperID
Group by 
u.UserName,p.PaperName,ua.ExamTime,ua.UserID,ua.PaperID";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<UserAnswer> list = new List<UserAnswer>();
                while (dr.Read())
                {
                    UserAnswer user = new UserAnswer();
                    user.UserID = dr["UserID"].ToString();
                    user.PaperID = Convert.ToInt32(dr["PaperID"]);
                    user.ExamTime = Convert.ToDateTime(dr["ExamTime"]);
                    user.UserName = dr["UserName"].ToString();
                    user.PaperName = dr["PaperName"].ToString();
                    list.Add(user);
                }
                return list;
            }
        }

        public static bool DeleteUserPaperList(string UsersID, int PapersID)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "delete from UserAnswer where UserID='" + UsersID + "' and PaperID='" + PapersID + "'";
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = sql;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public static bool delScores(string UserID)//根据Scores表的用户ID列删除对应行记录
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"delete from Score where UserID='" + UserID + "'";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }

            return true;
        }

        //查询用户考试信息，通过用户名，也就是考生登录账号
        public List<UserAnswer> selectExamInfo(string name)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {


                string sql = @"select 
Users.UserID,UserName,Score.PaperID,PaperName,Score,ExamTime,JudgeTime
from 
Score,Paper,Users
where
paper.PaperID = Score.PaperID and Users.UserID = Score.UserID and Score.UserID='" + name + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<UserAnswer> list = new List<UserAnswer>();
                while (dr.Read())
                {
                    UserAnswer user = new UserAnswer();
                    user.UserID = dr["UserID"].ToString();
                    user.UserName = dr["UserName"].ToString();
                    user.ExamTime = Convert.ToDateTime(dr["ExamTime"]);
                    //user.UserName = dr["UserName"].ToString();
                    user.PaperID = int.Parse(dr["PaperID"].ToString());
                    user.PaperName = dr["PaperName"].ToString();
                    user.Score = Convert.ToInt32(dr["Score"]);
                    user.JudgeTime = Convert.ToDateTime(dr["JudgeTime"]);
                    list.Add(user);

                }
                return list;
            }
        }

        public static bool SeclctCheck(string userId, int paperId)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = @"select count (*) from Score where UserID='" + userId + "' and PaperID='" + paperId + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                if (Convert.ToBoolean(cmd.ExecuteScalar()))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


        }

        //插入考试成绩
        public static bool InsertScore(Scores score, string PaperName, string userId, int paperId)
        {
            if (SeclctCheck(userId, paperId))
            {
                using (SqlConnection con = DBHelp.GetConnection())
                {
                    string sql = @"insert into Score 
    (UserID,PaperID,Score,ExamTime,JudgeTime)
    select 
    @UserID,
    PaperID,
    @Score,
    @ExamTime,
    @JudgeTime
    from 
    Paper
    where 
    PaperName = '" + PaperName + "'";


                    SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@UserId",score.UserID),
                    new SqlParameter("@PaperID",score.PaperID),
                    new SqlParameter("@Score",score.Score),
                    new SqlParameter("@ExamTime",score.ExamTime),
                    new SqlParameter("@JudgeTime",score.JudgeTime)
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

            }
            return false;

        }
        public string GetTime(int id)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string time = string.Empty;
                string sql = "select * from UserAnswer where UserID=" + id + "";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    time = dr["ExamTime"].ToString();
                }
                dr.Close();
                con.Close();
                return time;
            }
        }
        //通过考试用户账号获取考试时间
        public string GetTime(string Userid)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string time = string.Empty;
                string sql = "select * from UserAnswer where UserID='" + Userid + "'";//字符串情况下，要加单引号
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    time = dr["ExamTime"].ToString();
                }
                dr.Close();
                con.Close();
                return time;
            }
        }


        public static bool SelectPwd(string Pwd)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = "select UserID from Users where UserPwd='" + Pwd + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    conn.Close();
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
