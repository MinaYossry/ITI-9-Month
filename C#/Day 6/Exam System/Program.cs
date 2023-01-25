using Exam_System;

//Answer True = new Answer("True");
//Answer False = new Answer("FALSE");
ChooseOneQuestion CreateChooseOneQuestion(string body, int marks, string header, string[] choices, string correctChoice)
{
    Answer[] answers = new Answer[choices.Length];

    Answer modelAnswer = default;

    for (int i = 0; i < choices.Length; i++)
    {
        answers[i] = new Answer(choices[i]);
        if (correctChoice == choices[i])
            modelAnswer = answers[i];
    }

    AnswerList answerList = new AnswerList(answers);

    return new ChooseOneQuestion(body, marks, header, answerList, modelAnswer);
}

ChooseAllQuestion CreateChooseAllQuestion(string body, int marks, string header, string[] choices, string[] correctChoices)
{
    Answer[] answers = new Answer[choices.Length];
    Answer[] modelAnswers = new Answer[correctChoices.Length];

    int counter = 0;

    for (int i = 0; i < choices.Length; i++)
    {
        answers[i] = new Answer(choices[i]);
        if (correctChoices.Contains(choices[i]))
            modelAnswers[counter++] = answers[i];
    }

    AnswerList answerList = new AnswerList(answers);
    AnswerList modelAnswerList = new AnswerList(modelAnswers);

    return new ChooseAllQuestion(body, marks, header, answerList, modelAnswerList);
}

Question[] TFquestions= new Question[] {
    new TFQuestion("C# is a programming language", false, "C# and its Development",  1),
    new TFQuestion("C# was developed by Microsoft", true, "C# and its Development",  1),
    new TFQuestion("C# is primarily used for web development", false, "C# and its Applications",  1),
    new TFQuestion("C# is an object-oriented language", true, "C# and its Paradigms",  1),
    new TFQuestion("C# can only be used on Windows operating systems", true, "C# and its Platform",  1),
    new TFQuestion("C# supports functional programming", true, "C# and its Paradigms",  1),
    new TFQuestion("C# is not case-sensitive", false, "C# and its Syntax",  1),
    new TFQuestion("C# requires the use of pointers", false, "C# and its Memory Management",  1),
    new TFQuestion("C# is a popular choice for game development", true, "C# and its Applications",  1)
};

Question[] ChooseOneQuestions = new Question[]
{
    CreateChooseOneQuestion("Which of the following is not a C# access modifier?", 1, "C# Access Modifiers", new string[] {"public", "private", "protected", "transient"}, "transient"),
    CreateChooseOneQuestion("Which of the following is not a C# looping construct?", 1, "C# Looping Constructs", new string[] { "for", "while", "do-while", "repeat-until" }, "repeat-until"),
    CreateChooseOneQuestion("Which of the following is not a C# collection type?", 1, "C# Collection Types", new string[] { "List", "Dictionary", "Queue", "Set" }, "Set"),
    CreateChooseOneQuestion("Which of the following is a C# Language feature?", 1, "C# Language Features", new string[] { "Linq", "Lambda", "XML", "JSON" }, "Linq"),
    CreateChooseOneQuestion("Which of the following is a C# operator?", 1, "C# Operators", new string[] { "is", "as", "sizeof", "typeof" }, "is"),
};

Question[] ChooseAllQuestions = new Question[]
{
    CreateChooseAllQuestion("Which of the following are value types in C#?", 2, "C# Value Types", new string[] {"int", "float", "bool", "decimal"}, new string[] {"int", "float", "bool"}),
    CreateChooseAllQuestion("Which of the following are access modifiers in C#?", 2, "C# Access Modifiers", new string[] { "public", "private", "protected", "internal" }, new string[] { "public", "private", "protected" }),
    CreateChooseAllQuestion("Which of the following are C# collection types?", 2, "C# Collection Types", new string[] { "List", "Dictionary", "Queue", "Stack" }, new string[] { "List", "Dictionary" }),
    CreateChooseAllQuestion("Which of the following are C# generics?", 2, "C# Generics", new string[] { "List<T>", "Array<T>", "Queue<T>", "Stack<T>" }, new string[] { "List<T>" }),
    CreateChooseAllQuestion("Which of the following are C# exception types?", 2, "C# Exception Types", new string[] { "ArgumentNullException", "InvalidOperationException", "TimeoutException", "ArgumentOutOfRangeException" }, new string[] { "ArgumentNullException", "InvalidOperationException" }),
    CreateChooseAllQuestion("Which of the following are C# comparison operators?", 2, "C# Comparison Operators", new string[] { "<", ">", "<=", ">=" }, new string[] { "<", ">" })
};


PracticeExam PE;
FinalExam FE;

Console.WriteLine("=====================================================");
Console.WriteLine("Enter Exam Type: ");
Console.WriteLine("1- Practice Exam ");
Console.WriteLine("2- Final Exam ");
Console.WriteLine("3- Exit ");
Console.WriteLine("=====================================================");
int choice;
do
{
    Console.Write("Choice: ");
} while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3);

switch (choice)
{
    case 1:
        PE = new(new Subject("C#"));
        PE.GenerateExam(TFquestions, ChooseOneQuestions, ChooseAllQuestions);
        PE.ShowExam();
        PE.TakeInput();
        PE.ExamCorrection();
        PE.ShowExamWithAnswers();
        break;
    case 2:
        FE = new(new Subject("C#"));
        FE.GenerateExam(TFquestions, ChooseOneQuestions, ChooseAllQuestions);
        FE.ShowExam();
        FE.TakeInput();
        FE.ExamCorrection();
        FE.ShowExamWithAnswers();
        break;
    case 3:
    default:
        return;
}