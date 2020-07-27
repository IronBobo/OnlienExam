using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineExamModel
{
    //用户类
    public class Scores
    {
        #region 私有成员
        private int _ID;
        private string _userID;
        private string _userName;


        private int _paperID;
        private string _paperName;
        private int _score;
        private DateTime _examtime;//考试时间
        private DateTime _judgetime;  //评阅时间   
        private string _pingyu;  //评阅时间    

        #endregion 私有成员

        #region 属性

        public int ID
        {
            set
            {
                this._ID = value;
            }
            get
            {
                return this._ID;
            }
        }
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

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public int PaperID
        {
            set
            {
                this._paperID = value;
            }
            get
            {
                return this._paperID;
            }
        }
        public string PaperName
        {
            set
            {
                this._paperName = value;
            }
            get
            {
                return this._paperName;
            }
        }
        public int Score
        {
            set
            {
                this._score = value;
            }
            get
            {
                return this._score;
            }
        }
        public DateTime ExamTime
        {
            set
            {
                this._examtime = value;
            }
            get
            {
                return this._examtime;
            }
        }
        public DateTime JudgeTime
        {
            set
            {
                this._judgetime = value;
            }
            get
            {
                return this._judgetime;
            }
        }
        public string PingYu
        {
            set
            {
                this._pingyu = value;
            }
            get
            {
                return this._pingyu;
            }
        }

        #endregion 属性
    }
}
