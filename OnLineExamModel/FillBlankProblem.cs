using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineExamModel
{
    //�������
    public class FillBlankProblem
    {
        #region ˽�г�Ա
        private int _ID;                                               //��Ŀ���
        private int _CourseID;                                         //������Ŀ        
        private string _FrontTitle;                                    //��Ŀǰ����    
        private string _BackTitle;                                     //��Ŀ�󲿷�
        private string _Answer;                                        //��

        #endregion ˽�г�Ա
        #region ����

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

        #endregion ����
    }
}
