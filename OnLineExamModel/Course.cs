using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineExamModel
{
    //考试科目类
    public class Course
    {
        #region 私有成员

        private int _departmentId;		
        private string _departmentName;		//部门ID
        private int _examtime;

        public int DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }
       	//部门名       

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

        #endregion 私有成员
    }
}
