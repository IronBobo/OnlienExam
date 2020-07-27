using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineExamModel
{
    //多选题类
    public class MultiProblem
    {
        #region 私有成员
        private int _ID;                                               //题目编号
        private int _CourseID;                                         //所属科目        
        private string _Title;                                         //题目      
        private string _AnswerA;                                       //答案A
        private string _AnswerB;                                       //答案B
        private string _AnswerC;                                       //答案C
        private string _AnswerD;                                       //答案D
        private string _AnswerE;                                       //答案E
        private string _AnswerF;                                        //答案F
        private string _Answer;                                        //答案

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
        public string Title
        {
            set
            {
                this._Title = value;
            }
            get
            {
                return this._Title;
            }
        }
        public string AnswerA
        {
            set
            {
                this._AnswerA = value;
            }
            get
            {
                return this._AnswerA;
            }
        }
        public string AnswerB
        {
            set
            {
                this._AnswerB = value;
            }
            get
            {
                return this._AnswerB;
            }
        }
        public string AnswerC
        {
            set
            {
                this._AnswerC = value;
            }
            get
            {
                return this._AnswerC;
            }
        }
        public string AnswerD
        {
            set
            {
                this._AnswerD = value;
            }
            get
            {
                return this._AnswerD;
            }
        }

        public string AnswerE
        {
            set
            {
                this._AnswerE = value;
            }
            get
            {
                return this._AnswerE;
            }
        }
        public string AnswerF
        {
            set
            {
                this._AnswerF = value;
            }
            get
            {
                return this._AnswerF;
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

        #endregion 属性
    }
}
