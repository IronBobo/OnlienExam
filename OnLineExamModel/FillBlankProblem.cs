using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineExamModel
{
    //填空题类
    public class FillBlankProblem
    {
        #region 私有成员
        private int _ID;                                               //题目编号
        private int _CourseID;                                         //所属科目        
        private string _FrontTitle;                                    //题目前部分    
        private string _BackTitle;                                     //题目后部分
        private string _Answer;                                        //答案

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
        public int CourseID
        {
            set
            {
                this._CourseID = value;
            }
            get
            {
                return this._CourseID;
            }
        }
        public string FrontTitle
        {
            set
            {
                this._FrontTitle = value;
            }
            get
            {
                return this._FrontTitle;
            }
        }
        public string BackTitle
        {
            set
            {
                this._BackTitle = value;
            }
            get
            {
                return this._BackTitle;
            }
        }
        public string Answer
        {
            set
            {
                this._Answer = value;
            }
            get
            {
                return this._Answer;
            }
        }

        private string userAnswer;

        public string UserAnswer
        {
            get { return userAnswer; }
            set { userAnswer = value; }
        }

        private DateTime examTime;

        public DateTime ExamTime
        {
            get { return examTime; }
            set { examTime = value; }
        }

        private int mark;

        public int Mark
        {
            get { return mark; }
            set { mark = value; }
        }

        private string paperName;

        public string PaperName
        {
            get { return paperName; }
            set { paperName = value; }
        }

        #endregion 属性
    }
}
