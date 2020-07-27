using System;
using System.Collections.Generic;
using System.Text;
using OnLineExamModel;
using OnLineExamDAL;

namespace OnLineExamBLL
{
    public class MultiProblemManager
    {
        public static bool multiProblemInsert(MultiProblem mi)
        {
            if (MultiProblemService.MultiProblemInsert(mi))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool multiProblemUpdate(MultiProblem mu)
        {
            if (MultiProblemService.MultiProblemUpdate(mu))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static MultiProblemService service = new MultiProblemService();
        public static List<MultiProblem> GetMultiProblemList(string selectvalue)
        {
            return service.GetMultiProblemList(selectvalue);
        }

         static MultiProblemService mul = new MultiProblemService();
        public static List<MultiProblem> GetMutiQuestion(string UsersID, int PaperID)
        {
            
            return mul.selectMutiQuestion(UsersID,PaperID);
        }
    }
}
