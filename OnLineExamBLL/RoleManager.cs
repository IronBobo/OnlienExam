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
        /// ���½�ɫȨ��
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
        /// ��ӽ�ɫ��
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
        /// ��ȡ�û��ڸ�ģ���Ȩ���б�
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
        /// �ж��û���Ӧ��ɫ�Ƿ����ĳȨ��
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
