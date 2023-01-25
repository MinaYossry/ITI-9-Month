﻿using System;
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
            for (int i = 0; i < QuestionList.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"{i+1}) {QuestionList[i]}");
                Console.WriteLine($"Model Answer::: {QuestionList[i].ModelAnswer}");
                Console.WriteLine($"Student Answer: {StudentAnswers[i]}");
                Console.WriteLine();
            }

            Console.WriteLine($"You scored {StudentGrade}/{TotalMark}");
        }
    }
}