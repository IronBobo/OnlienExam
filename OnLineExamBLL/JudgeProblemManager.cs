using System;
using System.Collections.Generic;
using System.Text;
using OnLineExamModel;
using OnLineExamDAL;

namespace OnLineExamBLL
{
    public class JudgeProblemManager
    {
        public static bool judgeProblemUpdate(JudgeProblem jp)
        {
            if (JudgeProblemService.judgeProblemUpdate(jp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool judgeProblemInsert(JudgeProblem ji)
        {
            if (JudgeProblemService.judgeProblemInsert(ji))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static JudgeProblemService service = new JudgeProblemService();
        public static List<JudgeProblem> GetJudgeProblemList(string selectvalue)
        {
            return service.GetJudgeProblemList(selectvalue);
        }

        static JudgeProblemService judge= new JudgeProblemService();
        public static List<JudgeProblem> GetJudgeQuestion(string UsersID, int PaperID)
        {

            return judge.selectJudgeQuestion(UsersID, PaperID);
        }
    }
}
