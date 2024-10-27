using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Test
    {



        // metoda która zwraca wartosć
        public int AddTwoNumbers(int x, int y)
        {
            return x + y;
        }

        public string ChangeTextToCapitalLetters(string text)
        {
            return text.ToUpper();
        }


        // nie zwraca
        public void DisplaySomething()
        {
            Console.WriteLine("SOMETHING");
        }

    }
}
