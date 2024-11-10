using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Backend
    {
        public Backend()
        {
            CreateAllQuestions();
            CurrentCategory = 100;
        }


        public List<Question> AllQuestions { get; set; }
        public int CurrentCategory { get; set; }
        public Question CurrentQuestion { get; set; }

        public void CreateAllQuestions()
        {
            AllQuestions = new List<Question>();
            var q1 = new Question();
            q1.Id = 1;
            q1.Category = 100;
            q1.Content = "Jakiego koloru jest niebo?";
            q1.Answers = new List<Answer>();
            var a1 = new Answer();
            a1.Id = 1;
            a1.Content = "niebieskie";
            a1.IsCorrect = true;
            q1.Answers.Add(a1);

            var a2 = new Answer();
            a2.Id = 2;
            a2.Content = "zielone";
            q1.Answers.Add(a2);

            var a3 = new Answer();
            a3.Id = 3;
            a3.Content = "czarne";
            q1.Answers.Add(a3);

            var a4 = new Answer();
            a4.Id = 4;
            a4.Content = "czerwone";
            q1.Answers.Add(a4);

            AllQuestions.Add(q1);
        }

        public void GetQuestion()
        {
            // symulujemy, że losujemy
            // a po prostu bieżemy pierwsze pytanie z brzegu
            CurrentQuestion = AllQuestions[0];
        }

        public bool CheckPlayerChoice(int playerChoice)
        {
            var anyAnswer = CurrentQuestion.Answers
                .FirstOrDefault(a => a.Id == playerChoice);

            if (anyAnswer != null)
            {
                return anyAnswer.IsCorrect;
            }

            return false;  
        }
    }
}
