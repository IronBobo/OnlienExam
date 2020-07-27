using System;
using System.Collections.Generic;
using System.Text;
using OnLineExamModel;
using System.Data.SqlClient;

namespace OnLineExamDAL
{
    public class RoleService
    {
        /// <summary>
        /// 添加新角色名称
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static bool InsertRole(Role role)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"insert into Role (RoleName) values (@RoleName)";

                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RoleName",role.RoleName)
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

        /// <summary>
        /// 更新用户角色权限
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static bool UpdateRolesDuty(Role role)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                //string sql = @"Update Role (HasDuty_TypeManage,HasDuty_UserManage,HasDuty_RoleManage,HasDuty_PaperSetup,HasDuty_UserPaperList) values (@TypeManage,@UserManage,@RoleManage,@PaperSetup,@UserPaperList) where RoleName='" + role.RoleName + "'";
                string sql = @"Update Role Set HasDuty_TypeManage=@TypeManage,HasDuty_UserManage=@UserManage,HasDuty_RoleManage=@RoleManage,HasDuty_PaperSetup=@PaperSetup,HasDuty_UserPaperList=@UserPaperList where RoleName='" + role.RoleName + "'";

                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TypeManage",role.HasDuty_TypeManage),
                new SqlParameter("@UserManage",role.HasDuty_UserManage),
                new SqlParameter("@PaperSetup",role.HasDuty_PaperSetup),
                new SqlParameter("@UserPaperList",role.HasDuty_UserPaperList),
                new SqlParameter("@RoleManage",role.HasDuty_RoleManage)
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

        /// <summary>
        /// 获取角色对各模块的读写权限
        /// </summary>
        /// <returns></returns>
        public List<Role> DutyListRole()
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select * from  Role";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();

                List<Role> list = new List<Role>();

                while (sdr.Read())
                {
                    Role role = new Role();
                    role.RoleId = int.Parse(sdr["RoleId"].ToString());
                    role.RoleName = sdr["RoleName"].ToString();
                    role.HasDuty_TypeManage = int.Parse(sdr["HasDuty_TypeManage"].ToString());
                    role.HasDuty_UserManage = int.Parse(sdr["HasDuty_UserManage"].ToString());
                    role.HasDuty_RoleManage = int.Parse(sdr["HasDuty_RoleManage"].ToString());
                    role.HasDuty_Role = int.Parse(sdr["HasDuty_Role"].ToString());
                    role.HasDuty_CourseManage = int.Parse(sdr["HasDuty_CourseManage"].ToString());
                    role.HasDuty_PaperSetup = int.Parse(sdr["HasDuty_PaperSetup"].ToString());
                    role.HasDuty_PaperLists = int.Parse(sdr["HasDuty_PaperLists"].ToString());
                    role.HasDuty_UserPaperList = int.Parse(sdr["HasDuty_UserPaperList"].ToString());
                    role.HasDuty_UserScore = int.Parse(sdr["HasDuty_UserScore"].ToString());
                    role.HasDuty_SingleSelectManage = int.Parse(sdr["HasDuty_SingleSelectManage"].ToString());
                    role.HasDuty_MultiSelectManage = int.Parse(sdr["HasDuty_MultiSelectManage"].ToString());
                    role.HasDuty_FillBlankManage = int.Parse(sdr["HasDuty_FillBlankManage"].ToString());
                    role.HasDuty_JudgeManage = int.Parse(sdr["HasDuty_JudgeManage"].ToString());
                    role.HasDuty_QuestionManage = int.Parse(sdr["HasDuty_QuestionManage"].ToString());



                    list.Add(role);
                }

                sdr.Close();

                conn.Close();

                return list;
            }
        }

        public static bool Delect(string RoleID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"delete from Role where RoleID = '" + RoleID + "'";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }

            return true;
        }

        public List<Role> SelectRole()
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select RoleID,RoleName from Role";

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = sql;
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();

                List<Role> list = new List<Role>();

                while (sdr.Read())
                {
                    Role role = new Role();
                    role.RoleId = Convert.ToInt32(sdr["RoleID"]);
                    role.RoleName = sdr["RoleName"].ToString();                  
                    
                    list.Add(role);
                }

                sdr.Close();

                conn.Close();

                return list;

            }   
        }

        /// <summary>
        /// 判断用户对应角色是否具有某权限
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool IsHasDuty(string username, string modename)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                // SELECT TOP 1000    [HasDuty_CourseManage]      FROM [OnLineExam].[dbo].[Role] where RoleId IN(select RoleId from [OnLineExam].[dbo].[Users] where [OnLineExam].[dbo].[Users].UserName='1111222')
                int IsHas;
                string sql = @"select " + modename + " from Role where RoleId In (select RoleId from Users where Users.UserName='" + username + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    IsHas = int.Parse(dr[modename].ToString());
                    if (IsHas == 0)
                    {
                        return false;
                    }
                    if (IsHas == 1)
                    {
                        return true;
                    }
                }
                dr.Close();
                conn.Close();
                return false;
            }
        }

    }
}
