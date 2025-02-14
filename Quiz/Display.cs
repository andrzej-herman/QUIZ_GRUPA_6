﻿using QuizData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public static class Display
    {
        private static List<string> acceptedKeys = ["1", "2", "3", "4"];
        
        public static void ShowWelcomeScreen()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(" Witaj w Quzie Wiedzy");
            Console.WriteLine(" Spróbuj odpowiedzieć na 7 pytań");
            Console.WriteLine(" Powodzenia !!!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Naciśnij ENTER, aby rozpoczać grę ... ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static int DisplayQuestionAndGetAnswer(Question question)
        {
            var userAnswer = DisplayQuestion(question);
            while(userAnswer is null || !acceptedKeys.Contains(userAnswer))
            {
                userAnswer = DisplayQuestion(question);
            }

            return int.Parse(userAnswer);
        }

        private static string DisplayQuestion(Question question)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($" Pytanie za {question.Category} pkt.");
            Console.WriteLine();
            Console.WriteLine($" {question.Content}");
            Console.WriteLine();
            foreach (var answer in question.Answers)
            {
                Console.WriteLine($" {answer.Id}. {answer.Content}");
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Naciśnij 1, 2, 3 lub 4, aby wybrać odpowiedź ... ");
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine();
        }

        public static void GameOver()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Niestety, to nie jest prawidłowa odpowiedź");
            Console.WriteLine();
            Console.WriteLine(" KONIEC GRY");
        }

        public static void GoodAnswer(int kategoria)
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Brawo, to prawidłowa odpowiedź");
            Console.WriteLine($" Zdobywasz {kategoria} pkt.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.Write(" Naciśnij ENTER, aby zobaczyć następne pytanie...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static void Winner()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Brawo, to prawidłowa odpowiedź");
            Console.WriteLine();
            Console.WriteLine(" Udało Ci się ukończyć cały quiz.");
            Console.WriteLine();
            Console.WriteLine(" GRATULACJE !!!");
        }
    }
}
