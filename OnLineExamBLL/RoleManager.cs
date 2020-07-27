using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using OnLineExamDAL;
using OnLineExamModel;

namespace OnLineExamBLL
{
    public class RoleManager
    {
        /// <summary>
        /// 更新角色权限
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static bool UpdateRolesDuty(Role role)
        {
            if (RoleService.UpdateRolesDuty(role))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加角色名
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static bool InsertRole(Role role)
        {
            if (RoleService.InsertRole(role))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Role> SelectRoles()
        {
            RoleService roleservice = new RoleService();

            List<Role> list = roleservice.SelectRole();

            return list;
        }


        /// <summary>
        /// 获取用户在各模块的权限列表
        /// </summary>
        /// <returns></returns>
        public static List<Role> DutyListRoles()
        {
            RoleService rs = new RoleService();
            List<Role> list = rs.DutyListRole();
            return list;
        }

        public static string GetRoleName(String UserID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select RoleName from dbo.Role where RoleId =(select RoleId from dbo.Users where UserID='{0}')";



                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, UserID);
                cmd.CommandText = sql;
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return dr["RoleName"].ToString();
                }

              

                dr.Close();
                conn.Close();

                return "";
            }
        }

        /// <summary>
        /// 判断用户对应角色是否具有某权限
        /// </summary>
        /// <param name="username"></param>
        /// <param name="modename"></param>
        /// <returns></returns>
        public static bool IsHasDuty(string username, string modename)
        {
            if (RoleService.IsHasDuty(username, modename))
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
