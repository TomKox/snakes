using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snakes
{
    class Arena
    {
        private char obstacleChar;
        private List<Cell> obstacles;
        private int height, width;
        private ConsoleColor color;
        public Arena() : this('X')
        {

        }

        public Arena(char obstacleChar)
        {
            this.ObstacleChar = obstacleChar;
            obstacles = new List<Cell>();
            this.height = Console.WindowHeight-1;
            this.width = Console.WindowWidth-1;
            Console.CursorVisible = false;
            this.color = ConsoleColor.White;
        }

        public char ObstacleChar { get => obstacleChar; set => obstacleChar = value; }
        public int Height { get => height;  }
        public int Width { get => width; }
        public ConsoleColor Color { get => color; set => color = value; }

        public void addBorder()
        {
            for (int i = 1; i < Width; i++)
            {
                obstacles.Add(new Cell(ObstacleChar, i, 0));
                obstacles.Add(new Cell(ObstacleChar, i, Height));
            }
            for (int i = 0; i < Height; i++)
            {
                obstacles.Add(new Cell(ObstacleChar, 1, i));
                obstacles.Add(new Cell(ObstacleChar, Width-1, i));
            }
            
        }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            foreach(Cell obstacle in obstacles)
            {
                Console.SetCursorPosition(obstacle.X, obstacle.Y);
                Console.Write(obstacle);
            }
        }
    }
}
