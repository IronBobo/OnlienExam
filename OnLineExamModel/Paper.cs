using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineExamModel
{
    //�û���
    public class Paper
    {
        #region ˽�г�Ա
        private int _paperID;                                               //�Ծ���
        private int _courseID;                                              //��Ŀ��� 
        private string _paperName;                                          //�Ծ�����  
        private byte _paperState;                                           //�Ծ�״̬
        private string _type;
        private string _userid;
        private string _state;

        #endregion ˽�г�Ա

        #region ����

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

        #endregion ����

    }
}
//5^1^a^s^p^x