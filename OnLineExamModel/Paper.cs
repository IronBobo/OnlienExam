using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineExamModel
{
    //用户类
    public class Paper
    {
        #region 私有成员
        private int _paperID;                                               //试卷编号
        private int _courseID;                                              //科目编号 
        private string _paperName;                                          //试卷名称  
        private byte _paperState;                                           //试卷状态
        private string _type;
        private string _userid;
        private string _state;

        #endregion 私有成员

        #region 属性

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
        public int CourseID
        {
            set
            {
                this._courseID = value;
            }
            get
            {
                return this._courseID;
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
        public byte PaperState
        {
            set
            {
                this._paperState = value;
            }
            get
            {
                return this._paperState;
            }
        }
        public string Type
        {
            set
            {
                this._type = value;
            }
            get
            {
                return this._type;
            }
        }
        public string UserID
        {
            set
            {
                this._userid = value;
            }
            get
            {
                return this._userid;
            }
        }
        public string state
        {
            set
            {
                this._state = value;
            }
            get
            {
                return this._state;
            }
        }

        #endregion 属性

    }
}
//5^1^a^s^p^x