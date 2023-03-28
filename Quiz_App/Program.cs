using System;
using System.Globalization;

namespace ConsoleApp
{
    class Question
    {
        public Question(string text, string[] choices, string answer)
        {
            this.Text = text;
            this.Choices = choices;
            this.Answer = answer;
        }
        public string Text { get; set; }
        public string[] Choices { get; set; }
        public string Answer { get; set; }

        public bool checkAnswer(string answer)
        {
            return this.Answer.ToLower() == answer.ToLower();
        }
    }

    class Quiz
    {
        public Quiz(Question[] questions)
        {
            this.Questions = questions;
            this.QuestionIndex = 0;
        }
        private Question[] Questions { get; set; }
        public int QuestionIndex { get; set; }

        public Question GetQuestion()
        {
            return this.Questions[this.QuestionIndex];
        }

        public void DisplayQuestion()
        {
            var question = this.GetQuestion();
            Console.WriteLine($"question {this.QuestionIndex + 1}: {question.Text}");

            foreach (var c in question.Choices)
            {
                Console.WriteLine($"-{c}");
            }

            Console.Write("Answer: ");
            var ans = Console.ReadLine();
            this.Guess(ans);
        }

        public void Guess(string answer)
        {
            var question = this.GetQuestion();
            Console.WriteLine(question.checkAnswer(answer));
            this.QuestionIndex++;

            if (this.Questions.Length == this.QuestionIndex)
            {

                return;
            }
            else
            {
                this.DisplayQuestion();
            }

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var q1 = new Question("Which is the best programming language?", new string[] { "C#", "C++", "Java", "Python" }, "C#");
            var q2 = new Question("What is the most popular programming language", new string[] { "C#", "C++", "Java", "Python" }, "Python");
            var q3 = new Question("Which programming language is the most profitable ?", new string[] { "C#", "C++", "Java", "Python" }, "Java");

            var questions = new Question[] { q1, q2, q3 };
            var quiz = new Quiz(questions);

            quiz.DisplayQuestion();

        }
    }
}
