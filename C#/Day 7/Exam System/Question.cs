using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public abstract class Question
    {
        public string Body { get; init; }
        public int Marks { get; init; }
        public string Header { get; init; }
        public AnswerList ModelAnswer { get; init; }
        public AnswerList Answers { get; init; }
        public Question(string body, int marks, string header)
        {
            Body = body;
            Marks = marks;
            Header = header;
           
        }

        public int CorrectQuestion(AnswerList studentAnswers)
        {
            return ModelAnswer.Equals(studentAnswers) ? Marks : 0;
        }

        public override string ToString()
        {
            return Body;
        }
    }
}
