using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public abstract class Question
    {
        public string Body { get; set; }
        public int Marks { get; set; }
        public string Header { get; set; }

        public object ModelAnswer { get; set; }

        public Question(string body, int marks, string header, object modelAnswer)
        {
            Body = body;
            Marks = marks;
            Header = header;
            ModelAnswer = modelAnswer;
        }

        public abstract int CorrectQuestion(object obj);

        public override string ToString()
        {
            return Body;
        }
    }
}
