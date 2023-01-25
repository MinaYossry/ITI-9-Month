using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public class TFQuestion : Question
    {
        public static Answer True { get; } = new Answer("True");
        public static Answer False { get; } = new Answer("False");
        public static AnswerList ModelTrue { get; } = new AnswerList(new Answer[] { True });
        public static AnswerList ModelFalse { get; } = new AnswerList(new Answer[] { False });
        public static AnswerList ChoicesList { get; } = new AnswerList(new Answer[] { True, False });
        public TFQuestion(string body, bool isTrue, string header, int marks) : base(body, marks, header)
        {
            ModelAnswer = isTrue ? ModelTrue : ModelFalse;
            Answers = ChoicesList;
        }
    }
}


