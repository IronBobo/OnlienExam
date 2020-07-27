using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineExamModel
{
    public class Role
    {
        #region ˽�г�Ա

        private int _roleId;			//��ɫ��ְ��ID
        private string _roleName;		//��ɫ��ְ����
        private int _HasDuty_TypeManage;
        private int _HasDuty_UserManage;
        private int _HasDuty_RoleManage;
        private int _HasDuty_Role;
        private int _HasDuty_CourseManage;
        private int _HasDuty_PaperSetup;
        private int _HasDuty_PaperLists;
        private int _HasDuty_UserPaperList;
        private int _HasDuty_UserScore;
        private int _HasDuty_SingleSelectManage;
        private int _HasDuty_MultiSelectManage;
        private int _HasDuty_FillBlankManage;
        private int _HasDuty_JudgeManage;
        private int _HasDuty_QuestionManage;
        //private bool _exist;				//�Ƿ���ڱ�־


        #endregion ˽�г�Ա

        #region ����

        public int RoleId
        {
            set
            {
                this._roleId = value;
            }
            get
            {
                return this._roleId;
            }
        }
        public string RoleName
        {
            set
            {
                this._roleName = value;
            }
            get
            {
                return this._roleName;
            }
        }
        /// <summary>
        /// �������͹�����ѡ�⡢��ѡ�⡢����⡢�ж��⡢�ʴ���
        /// </summary>
        public int HasDuty_TypeManage
        {
            set
            {
                this._HasDuty_TypeManage = value;
            }
            get
            {
                return this._HasDuty_TypeManage;
            }
        }
        public int HasDuty_UserManage
        {
            set
            {
                this._HasDuty_UserManage = value;
            }
            get
            {
                return this._HasDuty_UserManage;
            }
        }
        public int HasDuty_RoleManage
        {
            set
            {
                this._HasDuty_RoleManage = value;
            }
            get
            {
                return this._HasDuty_RoleManage;
            }
        }
        public int HasDuty_Role
        {
            set
            {
                this._HasDuty_Role = value;
            }
            get
            {
                return this._HasDuty_Role;
            }
        }
        public int HasDuty_UserScore
        {
            set
            {
                this._HasDuty_UserScore = value;
            }
            get
            {
                return this._HasDuty_UserScore;
            }
        }
        public int HasDuty_CourseManage
        {
            set
            {
                this._HasDuty_CourseManage = value;
            }
            get
            {
                return this._HasDuty_CourseManage;
            }
        }
        public int HasDuty_PaperSetup
        {
            set
            {
                this._HasDuty_PaperSetup = value;
            }
            get
            {
                return this._HasDuty_PaperSetup;
            }
        }
        public int HasDuty_PaperLists
        {
            set
            {
                this._HasDuty_PaperLists = value;
            }
            get
            {
                return this._HasDuty_PaperLists;
            }
        }
        public int HasDuty_UserPaperList
        {
            set
            {
                this._HasDuty_UserPaperList = value;
            }
            get
            {
                return this._HasDuty_UserPaperList;
            }
        }
        public int HasDuty_SingleSelectManage
        {
            set
            {
                this._HasDuty_SingleSelectManage = value;
            }
            get
            {
                return this._HasDuty_SingleSelectManage;
            }
        }
        public int HasDuty_MultiSelectManage
        {
            set
            {
                this._HasDuty_MultiSelectManage = value;
            }
            get
            {
                return this._HasDuty_MultiSelectManage;
            }
        }
        public int HasDuty_FillBlankManage
        {
            set
            {
                this._HasDuty_FillBlankManage = value;
            }
            get
            {
                return this._HasDuty_FillBlankManage;
            }
        }
        public int HasDuty_JudgeManage
        {
            set
            {
                this._HasDuty_JudgeManage = value;
            }
            get
            {
                return this._HasDuty_JudgeManage;
            }
        }
        public int HasDuty_QuestionManage
        {
            set
            {
                this._HasDuty_QuestionManage = value;
            }
            get
            {
                return this._HasDuty_QuestionManage;
            }
        }

        //public bool Exist
        //{
        //    get
        //    {
        //        return this._exist;
        //    }
        //}

        #endregion ����
    }
}
//5^1^a^s^p^x