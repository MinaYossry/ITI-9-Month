﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public class ChooseOneQuestion : Question
    {

        public ChooseOneQuestion(string body, int marks, string header, AnswerList answers, AnswerList modelAnswer) : base(body, marks, header)
        {
            Answers = answers;
            ModelAnswer = modelAnswer;
        }

    }
}
