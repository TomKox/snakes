using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            arena.AddSnake(10, 10);
            arena.NewTarget();
        
            while(arena.Next())
            {
                arena.ReadKey();
                Thread.Sleep(100);
            }
            Console.ReadKey();
        }
    }
}
