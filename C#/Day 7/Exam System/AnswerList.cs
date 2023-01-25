using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exam_System
{
    public class AnswerList : List<Answer>
    {
        public AnswerList() { }
        public AnswerList(Answer[] _answers) { AddRange(_answers); }

        public override bool Equals(object obj)
        {
            if (obj is not AnswerList answersList) return false;

            if (object.ReferenceEquals(this, answersList)) return true;

            if (this.GetType() != answersList.GetType()) return false;

            if (Count != answersList.Count) return false;

            for (int i = 0; i < Count; i++)
            {
                if (!this[i].Equals(answersList[i]))
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            string[] ans= new string[Count];
            for (int i = 0; i < Count; i++)
            {
                ans[i] = $"{i}) {this[i]}";
            }
            return string.Join("  ||  ", ans);
        }

    }
}
