using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineExamModel
{
    public class UserAnswer
    {

        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string userID;

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        private int paperID;

        public int PaperID
        {
            get { return paperID; }
            set { paperID = value; }
        }
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private int titleID;

        public int TitleID
        {
            get { return titleID; }
            set { titleID = value; }
        }
        private int mark;

        public int Mark
        {
            get { return mark; }
            set { mark = value; }
        }
        private string _userAnswer;

        public string UserAnswers
        {
            get { return _userAnswer; }
            set { _userAnswer = value; }
        }

        private DateTime examTime;

        public DateTime ExamTime
        {
            get { return examTime; }
            set { examTime = value; }
        }


        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string paperName;

        public string PaperName
        {
            get { return paperName; }
            set { paperName = value; }
        }

        private int _courseID;

        public int CourseID
        {
            get { return _courseID; }
            set { _courseID = value; }
        }

        private byte _paperState;

        public byte PaperState
        {
            get { return _paperState; }
            set { _paperState = value; }
        }

        private string _userPwd;

        public string UserPwd
        {
            get { return _userPwd; }
            set { _userPwd = value; }
        }

        private int _roleId;

        public int RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

        private int score;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        private DateTime judgeTime;

        public DateTime JudgeTime
        {
            get { return judgeTime; }
            set { judgeTime = value; }
        }
    }
}
