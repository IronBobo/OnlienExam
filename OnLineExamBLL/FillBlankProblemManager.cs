using System;
using System.Collections.Generic;
using System.Text;
using OnLineExamModel;
using OnLineExamDAL;

namespace OnLineExamBLL
{
    public class FillBlankProblemManager
    {
        public static bool FillBlankProblemUpdate(FillBlankProblem fu)
        {
            if (FillBlankProblemService.FillBlankProbleUpdate(fu))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool FillBlankProblemInsert(FillBlankProblem fi)
        {
            if (FillBlankProblemService.FillBlankProbleInsert(fi))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool FillBlankProblemDelete(FillBlankProblem fd)
        {
            if (FillBlankProblemService.FillBlankProbleDelete(fd))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static FillBlankProblemService service = new FillBlankProblemService();
        public static List<FillBlankProblem> GeFillBlankProblemList(string selectvalue)
        {
            return service.GeFillBlankProblemList(selectvalue);
        }

        static FillBlankProblemService Fill = new FillBlankProblemService();
        public static List<FillBlankProblem> GetFillQuestion(string UsersID, int PaperID)
        {

            return Fill.FillQuestion(UsersID, PaperID);
        }
    }
}
