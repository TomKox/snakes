using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakes
{
    class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();
            arena.addBorder();
            arena.Draw();

            Console.ReadKey();
        }
    }
}
