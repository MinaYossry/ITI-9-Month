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
        public Dictionary<Question, AnswerList> QuestionsAnswers { get; set; }
        public QuestionList Questions { get; set; }
        public int TotalMark { get; set; }
        public int StudentGrade { get; set; }


        public Exam(Subject subject, int time, int numOfTFQuestions, int numOfChooseOneQuestions, int numOfChooseAllQuestions)
        {
            Time = time;
            NumOfTFQuestions = numOfTFQuestions;
            NumOfChooseOneQuestions = numOfChooseOneQuestions;
            NumOfChooseAllQuestions = numOfChooseAllQuestions;
            Subject = subject;
            QuestionsAnswers = new Dictionary<Question, AnswerList>();
        }
        public abstract void ShowExamWithAnswers();
        public void ShowExam()
        {
            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"{i + 1}) {Questions[i]}");
                Console.WriteLine($"{Questions[i].Answers}");
                Console.WriteLine();
            }
        }

        public void TakeInput()
        {
            for (int i = 0; i < Questions.Count; i++)
            {
                

                if (Questions[i] is TFQuestion)
                {
                    int choice;
                    do
                    {
                        Console.Write($"Answer of Question {i + 1}: ");
                    } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice >= Questions[i].Answers.Count);
                    switch(choice)
                    {
                        case 0:
                            QuestionsAnswers.TryAdd(Questions[i], TFQuestion.ModelTrue);
                            break;
                        case 1:
                            QuestionsAnswers.TryAdd(Questions[i], TFQuestion.ModelFalse);
                            break;
                        default:
                            break;
                    }
                } 
                else if (Questions[i] is ChooseOneQuestion)
                {
                    int choice;
                    do
                    {
                        Console.Write($"Answer of Question {i + 1}: ");
                    } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice >= Questions[i].Answers.Count);

                    AnswerList studentAns = new AnswerList();
                    studentAns.Add(Questions[i].Answers[choice]);
                    QuestionsAnswers.TryAdd(Questions[i], studentAns);

                } 
                else if (Questions[i] is ChooseAllQuestion)
                {
                    List<int> ans = new();
                    bool allGood;
                    do
                    {
                        ans.Clear();
                        allGood = true;
                        Console.Write($"Answer of Question {i + 1}: ");
                        string[] answers = Console.ReadLine().Split(",");
                        for (int j = 0; j < answers.Length && allGood; j++)
                        {
                            if(int.TryParse(answers[j], out int temp) && temp >= 0 && temp < Questions[i].Answers.Count)
                                ans.Add(temp);
                            else
                                allGood= false;
                        } 

                    } while (!allGood);

                    AnswerList answersList = new AnswerList();

                    for (int index = 0; index < ans.Count; index++)
                    {
                        answersList.Add(Questions[i].Answers[index]);
                    }

                    QuestionsAnswers.TryAdd(Questions[i], answersList);
                }
            }
        }
        public int ExamCorrection()
        {
            foreach (KeyValuePair<Question, AnswerList> answer in QuestionsAnswers) {
                TotalMark += answer.Key.Marks;
                StudentGrade += answer.Key.CorrectQuestion(answer.Value);
            }
            return StudentGrade;
        }

        public void GenerateExam(QuestionList TFQuestions, QuestionList ChooseOneQuestions, QuestionList ChooseAllQuestions)
        {
            QuestionList newQuestionList = new("ExamQuestions");

            int counter = 0;
            Random random = new Random();

            while (counter < NumOfTFQuestions)
            {
                int randIndex = random.Next(0, TFQuestions.Count);
                if (!newQuestionList.Contains(TFQuestions[randIndex]))
                {
                    newQuestionList.Add(TFQuestions[randIndex]);
                    counter++;
                }
            }

            while (counter < NumOfChooseOneQuestions + NumOfChooseOneQuestions)
            {
                int randIndex = random.Next(0, ChooseOneQuestions.Count);
                if (!newQuestionList.Contains(ChooseOneQuestions[randIndex]))
                {
                    newQuestionList.Add(ChooseOneQuestions[randIndex]);
                    counter++;
                }
            }

            while (counter < NumOfChooseAllQuestions + NumOfChooseOneQuestions + NumOfChooseAllQuestions)
            {
                int randIndex = random.Next(0, ChooseAllQuestions.Count);
                if (!newQuestionList.Contains(ChooseAllQuestions[randIndex]))
                {
                    newQuestionList.Add(ChooseAllQuestions[randIndex]);
                    counter++;
                }
            }

            Questions = newQuestionList;
        }
    }
}
