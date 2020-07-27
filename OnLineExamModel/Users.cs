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
        #region ˽�г�Ա
        private string _userID;                                               //�û����
        private string _userPwd;                                         //�û�����
        private string _userName;                                             //�û�����        
        //private int _department;	                    //�û�����
        private int _roleid;		                     //�û���ɫ
        private string _rolename;
        private ArrayList _duties = new ArrayList();	//�û����е�Ȩ��
        Role role;

        public Role Role
        {
            get { return role; }
            set { role = value; }
        }
        #endregion ˽�г�Ա

        #region ����

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
        #endregion ����
    }
    public class Logined
    {
        public bool login_status { get; set; }
        public string login_errstr { get; set; }
    }
}
