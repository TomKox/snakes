using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakes
{
    class UI
    {

        public static bool GameOver()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleHelper.Center("G A M E   O V E R");
            int y = Console.CursorTop += 2;
            ConsoleHelper.Center("Play again? (Y/N) ", y);
            string playAgain = Console.ReadLine();
            if (playAgain.ToLower() == "y") return false;
            else return true;
        }
    }
}
