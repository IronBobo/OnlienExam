using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineExamModel
{
    //���Կ�Ŀ��
    public class Course
    {
        #region ˽�г�Ա

        private int _departmentId;		
        private string _departmentName;		//����ID
        private int _examtime;

        public int DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }
       	//������       

        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }

        public int Examtime
        {
            get { return _examtime; }
            set { _examtime = value; }
        }

        #endregion ˽�г�Ա
    }
}
