using System;
using System.Collections.Generic;
using System.Text;
using OnLineExamModel;
using OnLineExamDAL;

namespace OnLineExamBLL
{
    public class QuestionProblemManager
    {
        public static bool QuestionProblemInsert(QuestionProblem qi)
        {
            if (QuestionProblemService.QuestionProblemInsert(qi))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool QuestionProblemUpdate(QuestionProblem qu)
        {
            if (QuestionProblemService.QuestionProblemUpdate(qu))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static QuestionProblemService service = new QuestionProblemService();
        public static List<QuestionProblem> GetQuestionProblem(string selectvalue)
        {
            return service.GetQuestionProblemList(selectvalue);
        }

        static QuestionProblemService ques = new QuestionProblemService();
        public static List<QuestionProblem> GetQuesQuestion(string UsersID, int PaperID)
        {

            return ques.selectQuesQuestion(UsersID, PaperID);
        }
    }
}
