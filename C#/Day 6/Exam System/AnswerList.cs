using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exam_System
{
    public class AnswerList
    {
        public Answer[] Answers { get; set; }
        public AnswerList(Answer[] _answers) { Answers = _answers; }

        public override bool Equals(object obj)
        {
            if (obj is not AnswerList answersList) return false;

            if (object.ReferenceEquals(this, answersList)) return true;

            if (this.GetType() != answersList.GetType()) return false;

            if (Answers.Length != answersList.Answers.Length) return false;

            for (int i = 0; i < Answers.Length; i++)
            {
                if (!Answers[i].Equals(answersList.Answers[i]))
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            string[] ans= new string[Answers.Length];
            for (int i = 0; i < Answers.Length; i++)
            {
                ans[i] = Answers[i].ToString();
            }
            return string.Join("  ||  ", ans);
        }

    }
}
