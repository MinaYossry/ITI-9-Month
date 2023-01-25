using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public class PracticeExam : Exam
    {
        public PracticeExam(Subject subject, int time = 1, int numOfTFQuestions = 3, int numOfChooseOneQuestions = 3, int numOfChooseAllQuestions = 3) : base(subject, time, numOfTFQuestions, numOfChooseOneQuestions, numOfChooseAllQuestions)
        {
        }

        
        public override void ShowExamWithAnswers()
        {
            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"{i+1}) {Questions[i]}");
                Console.WriteLine($"Model Answer::: {Questions[i].ModelAnswer}");
                Console.WriteLine($"Student Answer: {QuestionsAnswers[Questions[i]]}");
                Console.WriteLine();
            }

            Console.WriteLine($"You scored {StudentGrade}/{TotalMark}");
        }
    }
}
