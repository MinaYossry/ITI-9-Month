using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public abstract class Exam
    {
        public Subject Subject { get; init; }
        public int Time { get; init; }
        public int NumOfTFQuestions { get; init; }
        public int NumOfChooseOneQuestions { get; init; }
        public int NumOfChooseAllQuestions { get; init; }

        public object[] StudentAnswers { get; set; }
        public Question[] QuestionList { get; set; }
        public int TotalMark { get; set; }
        public int StudentGrade { get; set; }

        public Exam(Subject subject, int time, int numOfTFQuestions, int numOfChooseOneQuestions, int numOfChooseAllQuestions)
        {
            Time = time;
            NumOfTFQuestions = numOfTFQuestions;
            NumOfChooseOneQuestions = numOfChooseOneQuestions;
            NumOfChooseAllQuestions = numOfChooseAllQuestions;
            Subject = subject;
            StudentAnswers = new object[NumOfTFQuestions + NumOfChooseOneQuestions + NumOfChooseAllQuestions];
        }
        public abstract void ShowExamWithAnswers();
        public void ShowExam()
        {
            for (int i = 0; i < QuestionList.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"{i + 1}) {QuestionList[i]}");
                if (QuestionList[i] is TFQuestion)
                {
                    Console.WriteLine("True     False");
                }
                else if (QuestionList[i] is ChooseOneQuestion COQ)
                {
                    Console.WriteLine($"{COQ.Answers}");
                }
                else if (QuestionList[i] is ChooseAllQuestion CAQ)
                {
                    Console.WriteLine($"{CAQ.Answers}");
                }
                Console.WriteLine();
            }
        }

        public void TakeInput()
        {
            for (int i = 0; i < StudentAnswers.Length; i++)
            {
                Console.Write($"Answer of Question {i+1}: ");
                if (QuestionList[i] is TFQuestion)
                {
                    string answer = Console.ReadLine();
                    if (answer == "True")
                    {
                        StudentAnswers[i] = true;
                    } else if (answer == "False")
                    {
                        StudentAnswers[i] = false;
                    }
                } else if (QuestionList[i] is ChooseOneQuestion COQ)
                {
                    string answer = Console.ReadLine();
                    StudentAnswers[i] = new Answer(answer);
                } else if (QuestionList[i] is ChooseAllQuestion CAQ)
                {
                    string[] answers = Console.ReadLine().Split(",");
                    Answer[] answersList = new Answer[answers.Length];

                    for (int ans = 0; ans < answers.Length; ans++)
                    {
                        answersList[ans] = new Answer(answers[ans]);
                    }

                    StudentAnswers[i] = new AnswerList(answersList);
                }
            }
        }
        public int ExamCorrection()
        {
            for (int i = 0; i < QuestionList.Length; i++)
            {
                TotalMark += QuestionList[i].Marks;
                StudentGrade += QuestionList[i].CorrectQuestion(StudentAnswers[i]);
            }
            return StudentGrade;
        }

        public void GenerateExam(Question[] TFQuestions, Question[] ChooseOneQuestions, Question[] ChooseAllQuestions)
        {
            Question[] newQuestionList = new Question[NumOfTFQuestions + NumOfChooseOneQuestions + NumOfChooseAllQuestions];

            int counter = 0;
            Random random = new Random();

            while (counter < NumOfTFQuestions)
            {
                int randIndex = random.Next(0, TFQuestions.Length);
                if (!newQuestionList.Contains(TFQuestions[randIndex]))
                    newQuestionList[counter++] = TFQuestions[randIndex];
            }

            while (counter < NumOfChooseOneQuestions + NumOfChooseOneQuestions)
            {
                int randIndex = random.Next(0, ChooseOneQuestions.Length);
                if (!newQuestionList.Contains(ChooseOneQuestions[randIndex]))
                    newQuestionList[counter++] = ChooseOneQuestions[randIndex];
            }

            while (counter < NumOfChooseAllQuestions + NumOfChooseOneQuestions + NumOfChooseAllQuestions)
            {
                int randIndex = random.Next(0, ChooseAllQuestions.Length);
                if (!newQuestionList.Contains(ChooseAllQuestions[randIndex]))
                    newQuestionList[counter++] = ChooseAllQuestions[randIndex];
            }

            QuestionList = newQuestionList;
        }
    }
}
