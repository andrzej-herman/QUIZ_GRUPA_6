using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public static class Frontend
    {
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

        public static int DisplayQuestion(Question question)
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
            return  int.Parse(Console.ReadLine());
        }
    }
}
