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
            ConsoleHelper.Center("Play again? (Y/N)", y);
            Console.CursorVisible = true;
            string playAgain = Console.ReadKey().KeyChar.ToString();
            if (playAgain.ToLower() == "y") return false;
            else if (playAgain.ToLower() == "n") return true;
            else return GameOver();
        }
    }
}
