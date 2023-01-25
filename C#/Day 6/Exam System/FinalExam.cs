using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public class FinalExam : Exam
    {
        public FinalExam(Subject subject, int time = 1, int numOfTFQuestions = 3, int numOfChooseOneQuestions = 3, int numOfChooseAllQuestions = 3) : base(subject, time, numOfTFQuestions, numOfChooseOneQuestions, numOfChooseAllQuestions)
        {
        }

        public override void ShowExamWithAnswers()
        {
            for (int i = 0; i < QuestionList.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"{i + 1}) {QuestionList[i]}");
                Console.WriteLine($"Student Answer {StudentAnswers[i]}");
                Console.WriteLine();
            }

        }
    }
}
