using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public class Answer
    {
        public string Name { get; set; }

        public Answer(string _name) { Name = _name; }

        public override bool Equals(object obj)
        {
            if (obj is not Answer answer) return false;

            if (object.ReferenceEquals(this, answer)) return true;

            if (this.GetType() != answer.GetType()) return false;

            return Name == answer.Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
