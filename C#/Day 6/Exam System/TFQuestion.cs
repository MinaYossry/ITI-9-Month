using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public class TFQuestion : Question
    {
        public TFQuestion(string body, bool isTrue, string header, int marks) : base(body, marks, header, isTrue)
        {
            ModelAnswer = isTrue;
        }

        public override int CorrectQuestion(object obj)
        {
            if (obj is not bool answer) return 0;

            return answer == (bool)ModelAnswer ? Marks : 0;
        }


    }
}


