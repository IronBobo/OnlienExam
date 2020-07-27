using System;
using System.Collections.Generic;
using System.Text;
using OnLineExamModel;
using OnLineExamDAL;

namespace OnLineExamBLL
{
    public class SingleSelectedManager
    {
        public static bool AddSingleSelected(SingleProblem sp)
        {
            if (SingleSelectedService.InsertQuestion(sp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool UpdateSingleSelected(SingleProblem spp)
        {
            if (SingleSelectedService.UpdateQuestion(spp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static SingleSelectedService service = new SingleSelectedService();
        public static List<SingleProblem> GetSingleProblemList(string selectvalue)
        {
            return service.GetSingleProblemList(selectvalue);
        }

        static SingleSelectedService Sing = new SingleSelectedService();
        public static List<SingleProblem> GetSingQuestion(string UsersID, int PaperID)
        {

            return Sing.selectSingQuestion(UsersID, PaperID);
        }
    }
}
