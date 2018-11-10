using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakes
{
    class ConsoleHelper
    {
        public static void Center(string text, int y)
        {
            int width = Console.WindowWidth;
            int length = text.Length;
            Console.SetCursorPosition(width / 2 - length / 2, y);
            Console.Write(text);
        }

        public static void Center(string text)
        {
            int height = Console.WindowHeight;
            Center(text, height / 2);
        }
    }
}
