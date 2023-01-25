using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public class QuestionList : List<Question>
    {
        public string Name { get; set; }
        public QuestionList(string name, Question[] questions)
        {
            Name = name;
            for (int i = 0; i < questions?.Length; i++)
            {
                Add(questions[i]);
            }
        }
        public QuestionList(string name)
        {
            Name = name;
        }
        public QuestionList() { }
        public new void Add(Question Q)
        {
            // Keep the default behavior
            base.Add(Q);

            using (StreamWriter sw = new($"{Name}.txt", true))
            {
                sw.WriteLine(Q);
            }
        }
    }
}
