using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public class ChooseAllQuestion : Question
    {
        public AnswerList Answers { get; set; }
        public ChooseAllQuestion(string body, int marks, string header, AnswerList answers, AnswerList modelAnswer) : base(body, marks, header, modelAnswer)
        {
            Answers = answers;
        }

        public override int CorrectQuestion(object obj)
        {
            return ModelAnswer.Equals(obj) ? Marks : 0;
        }
    }
}
