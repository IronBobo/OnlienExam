using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using OnLineExamDAL;
using OnLineExamModel;

namespace OnLineExamBLL
{
    public class UserManager
    {
        public static List<Scores> selectAllScore(string PaperID)
        {
            UserService UserService = new UserService();
            List<Scores> list = UserService.SelectAll(PaperID);

            return list;
        }

        public static List<Scores> selectAlls()
        {
            UserService UserService = new UserService();
            List<Scores> list = UserService.SelectAll();

            return list;
        }
        public static string GetTime(int id)
        {
            UserService UserService = new UserService();
            return UserService.GetTime(id);
        }
        public static string GetTime(string Userid)
        {
            UserService UserService = new UserService();
            return UserService.GetTime(Userid);
        }

        public static IList<Users> seluserName(string userName)
        {
            UserService userService = new UserService();
            IList<Users> list = userService.SelectUserName(userName);

            return list;
        }

        public static IList<Users> seluser(string userID)
        {
            UserService userService = new UserService();
            IList<Users> list = userService.SelectUserID(userID);

            return list;
        }

        public static IList<Users> listuser()
        {
            UserService userService = new UserService();
            IList<Users> list = userService.SelectUser();

            return list;
        }

        public static bool AddUsers(Users user)
        {
            if (UserService.insertUsers(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool InsertScores(Scores scores, string PaperName,string userId, int paperId)
        {
            if (UserService.InsertScore(scores, PaperName, userId, paperId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Login(ref Users user)
        {
            UserService service = new UserService();
            user = service.LoginUser(user.UserID, user.UserPwd);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        public static Logined Logined(ref Users user)
        {
            UserService service = new UserService();
            Logined lg = new Logined();
            lg = service.Logined(user.UserID, user.UserPwd);

           

            return lg;
        }



        public static string GetUserName(String UserID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select UserName from Users where UserID='{0}'";



                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, UserID);
                cmd.CommandText = sql;
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return dr["UserName"].ToString();
                }
                else
                {
                    return "";

                }

                //Users u = PopUserFromDataReader(dr);

                dr.Close();
                conn.Close();

                
            }
        }


        public static void ModifyPwd(string UserPwd, string UserId)
        {
            service.Update(UserPwd, UserId);
        }


        static UserService service;
        static UserManager()
        {
            service = new UserService();
        }

        public static List<UserAnswer> GetselectUserPaperList()
        {
            UserService userService = new UserService();
            List<UserAnswer> list = userService.selectUserPaperList();
            return list;
        }
        

        public static bool DeleteUserPaperList(string UsersID, int PapersID)
        {
            if (UserService.DeleteUserPaperList(UsersID, PapersID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static UserService user = new UserService();

        public static List<UserAnswer> GetselectExaminfo(string name)
        {
            return user.selectExamInfo(name);

        }

        public static bool GetSelectPwd(string Pwd)
        {
            if (UserService.SelectPwd(Pwd))
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
