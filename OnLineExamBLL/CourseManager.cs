using System;
using System.Collections.Generic;
using System.Text;
using OnLineExamModel;
using OnLineExamDAL;
using System.Data;

namespace OnLineExamBLL
{
    public class CourseManager
    {
         public static void ModifyPwd(string Name, string ID)
        {
            service.Update(Name, ID);
        }


        static CourseService service;
        static CourseManager()
        {
            service = new CourseService();
        }

        public static bool courseInsert(Course ci)
        {
            if (CourseService.insertCourse(ci))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataSet QueryCourse()//¿ÆÄ¿
        {
            DBHelp DB = new DBHelp();
            return DB.GetDataSets("Proc_CourseList");
        }
        public static bool GetDeleteCourse(Course id)
        {
            if (CourseService.DeleteCourse(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static List<Course> GetSelect()
        {
            return CourseService.SelectCourse();
        }



        public static int GetExamtime(string papername)
        {
            CourseService CurService = new CourseService();
            return CurService.GetExamtime(papername);
        }
    }
}
