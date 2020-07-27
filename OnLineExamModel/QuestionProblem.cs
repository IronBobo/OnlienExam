using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineExamModel
{
    //�ʴ�����
    public class QuestionProblem
    {
        #region ˽�г�Ա
        private int _ID;                                               //��Ŀ���
        private int _CourseID;                                         //������Ŀ        
        private string _Title;                                         //��Ŀ       
        private string _Answer;                                       //��


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
        #endregion ����
    }
}
