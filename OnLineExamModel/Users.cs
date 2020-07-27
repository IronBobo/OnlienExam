using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace OnLineExamModel
{
    public class Users
    {
        public Users()
        { 
            
        }
        public Users(string userId, string userName, string nickName, Role role)
        {
            this._userID = userId;
            this._userName = nickName;
            this._userPwd = userName;
            this.role = role;
        }
        #region 私有成员
        private string _userID;                                               //用户编号
        private string _userPwd;                                         //用户密码
        private string _userName;                                             //用户姓名        
        //private int _department;	                    //用户部门
        private int _roleid;		                     //用户角色
        private string _rolename;
        private ArrayList _duties = new ArrayList();	//用户所有的权限
        Role role;

        public Role Role
        {
            get { return role; }
            set { role = value; }
        }
        #endregion 私有成员

        #region 属性

        public string UserID
        {
            set
            {
                this._userID = value;
            }
            get
            {
                return this._userID;
            }
        }
        public string UserPwd
        {
            set
            {
                this._userPwd = value;
            }
            get
            {
                return this._userPwd;
            }
        }

        public string UserName
        {
            set
            {
                this._userName = value;
            }
            get
            {
                return this._userName;
            }
        }
        
        public int RoleId
        {
            set
            {
                this._roleid = value;
            }
            get
            {
                return this._roleid;
            }
        }
        public string RoleName
        {
            set
            {
                this._rolename = value;
            }
            get
            {
                return this._rolename;
            }
        }
        public ArrayList Duties
        {
            set
            {
                this._duties = value;
            }
            get
            {
                return this._duties;
            }
        }
        #endregion 属性
    }
    public class Logined
    {
        public bool login_status { get; set; }
        public string login_errstr { get; set; }
    }
}
